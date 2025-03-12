using FinalDemo.Models;
using FinalDemo.Models.DTO.Admin_DTOs;
using FinalDemo.Models.Enum;
using FinalDemo.Models.POCO;
using ORM_Final_Demo.Extension;
using FinalDemo.Security;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Data;
using System.Web;
using System.Linq;
using Google.Protobuf.WellKnownTypes;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Diagnostics;

namespace FinalDemo.BL
{
    public class ServiceProvicer {
        private ADM01 _admobj;
        private ODR01 _odrobj;
        private PD01 _pdobj;

        private readonly IDbConnectionFactory _dbfactory;

        private Response _objResponse; 

        private int _id;
        public OpTpye Type { get; set; }
        public EnityType Etype { get; set; }

        public ServiceProvicer()
        {
            _objResponse = new Response();
            _dbfactory = new OrmLiteConnectionFactory("Server=localhost;Database=demo_mj_ormfinal;User=Admin;Password=gs@123;", MySqlDialect.Provider);
            if (_dbfactory == null)
            {
                throw new Exception("IDbConnectionFactory not found");
            }
            using (IDbConnection db = _dbfactory.Open())
            {
                db.CreateTableIfNotExists(typeof(ADM01), typeof(PD01), typeof(ODR01));
            }
        }

        private bool IsExists()
        {
            using (IDbConnection db = _dbfactory.Open())
            {
                if(Etype == EnityType.Admin)
                {
                    return db.Exists<ADM01>(x => x.M01F01 == _id);
                }
                if(Etype == EnityType.Order)
                {
                    return db.Exists<ODR01>(x => x.R01F01 == _id);
                }
                if (Etype == EnityType.Order)
                {
                    return db.Exists<PD01>(x => x.D01F01 == _id);
                }
                return false;
            }
        }
        public void PreSave<T>(T obj) 
        {
            if (Etype == EnityType.Admin)
            {
                _admobj = obj.Convert<ADM01>();
                _id = _admobj.M01F01;
            }
            if (Etype == EnityType.Order)
            {
                _odrobj = obj.Convert<ODR01>();
                _odrobj.R01F05 = DateTime.Now;
                _id = _odrobj.R01F01;
            }
            if(Etype == EnityType.PD)
            {
                _pdobj = obj.Convert<PD01>();
                _id = _pdobj.D01F01;
            }

        }

        public void Validate()
        {
            if(Type == OpTpye.Add && Etype == EnityType.Admin && IsExists())
            {
                throw new ArgumentException("Admin already exists");
            }
            if (Type == OpTpye.Add && Etype == EnityType.Order && IsExists())
            {
                throw new ArgumentException("Order already exists");
            }
            if (Type == OpTpye.Add && Etype == EnityType.PD && IsExists())
            {
                throw new ArgumentException("PD already exists");
            }

        }

        public void Save()
        {
            using(IDbConnection db = _dbfactory.Open())
            {
                if (Type == OpTpye.Add && Etype == EnityType.Admin)
                {
                    _admobj.M01F03 = Rjindial_Crypto_Service.Encrypt(_admobj.M01F03);  // we dont store password dirctly
                    db.Insert<ADM01>(_admobj);
                }
                if (Type == OpTpye.Add && Etype == EnityType.Order)
                {
                    db.Insert<ODR01>(_odrobj);
                }
                if(Type == OpTpye.Add && Etype == EnityType.PD)
                {
                    db.Insert<PD01>(_pdobj);
                }
            }
        }


        public Response AddEntity<T>(T obj)
        {
            try
            {
                PreSave<T>(obj);
                Validate();
                Save();
                _objResponse.IsError = false;
                _objResponse.Message = "Added successfully";
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                _objResponse.IsError = true;
                _objResponse.Message = e.Message;
            }
            return _objResponse;
        }


        public Response GetEntityById(int id)
        {
            try
            {
                using(IDbConnection db = _dbfactory.Open())
                {
                    if(Etype == EnityType.Admin)
                    {
                        ADM01 adm = db.Select<ADM01>(x => x.M01F01 == id).FirstOrDefault();
                        if (adm == null) throw new ArgumentException("No user found");
                        _objResponse.Data = adm.Convert<DTOADM01>();
                    }
                    _objResponse.IsError = false;
                    _objResponse.Message = "Get successfull";
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                _objResponse.IsError = true;
                _objResponse.Message = e.Message;
            }
            return _objResponse;
        }

        public Response GetAdminDetails()   // we will use linq here
        {
            try
            {
                using(IDbConnection db = _dbfactory.Open())
                {
                    List<ADM01> _admlist = db.Select<ADM01>();
                    List<ODR01> _odrlist = db.Select<ODR01>();
                    List<PD01> _pdlist = db.Select<PD01>();
                    var result1 = db.Select<DTOADM01>(db.From<ADM01>().Join<ADM01, PD01>((a,p)=>a.M01F01==p.D05F05)); // Do by linq
                    Debug.WriteLine(result1.Count);
                    List<DTOVIEW01> result = (from a in _admlist
                                 join o in _odrlist on a.M01F01 equals o.R01F03 into orders_group
                                 join p in _pdlist on a.M01F01 equals p.D05F05 into pd_group
                                 select new DTOVIEW01
                                 {
                                     Admin = a.M01F02,
                                     Orders_Created = orders_group.ToList(),
                                     Printers_Created = pd_group.ToList()
                                 }).ToList();
                    var opiton = new JsonSerializerOptions
                    {
                        WriteIndented = true,
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    };
                    string content = JsonSerializer.Serialize<List<DTOVIEW01>>(result, opiton);
                    string path = "C:\\Users\\meet.j\\Desktop\\RKIT_Training\\Advance API\\FinalDemo\\BL\\data1.txt";
                    //string path2 = @"C:\Users\meet.j\Desktop\RKIT_Training\Advance API\FinalDemo\Models\DTO\Admin_DTOs\DTOADM01.cs";

                    using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        //fs.Seek(0, SeekOrigin.Begin);
                        sw.WriteLine(content);
                    }

                    _objResponse.Data = "Check this URL : "+path;
                    _objResponse.IsError = false;
                    _objResponse.Message = "success in writre";
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                _objResponse.IsError = true;
                _objResponse.Message = e.Message;
            }
            return _objResponse;
        }

        public Response GetOrdersDetails(int id)
        {
            try
            {
                using (IDbConnection db = _dbfactory.Open())
                {
                    var query = db.From<ODR01>()
                    .Where(o => o.R01F04 == id)  
                    .Select(o => new
                    {
                        Order_ID = o.R01F01,  // Order ID
                        Creation_Time = o.R01F05, // Order creation time
                        PrintingSpec = o.R01F02 //Printing spec
                    });

                    var result = db.Select<OrderDetails>(query);




                    //Debug.WriteLine(JsonSerializer.Serialize<List<dynamic>>(result));
                    //List<DTOVIEW02> res = new List<DTOVIEW02>();
                    //foreach (var records in result)
                    //{
                    //    res.Add(new DTOVIEW02
                    //    {
                    //        Creation_Time = records.Order.R01F05,
                    //        Order_ID = records.Order.R01F01,
                    //        Creator = records.Admin ?? new ADM01 { M01F01 = 0, M01F02 = "Unknown", M01F03 = "N/A", M01F04 = 0 },
                    //        Printer = records.Printer ?? new PD01 { D01F01 = 0, D02F02 = "No Printer", D03F03 = "N/A", D04F04 = 0, D05F05 = 0 }
                    //    });
                    //}

                    //var options = new JsonSerializerOptions
                    //{
                    //    WriteIndented = true,
                    //    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    //};
                    //string content = JsonSerializer.Serialize(res, options);

                    //string path = "C:\\Users\\meet.j\\Desktop\\RKIT_Training\\Advance API\\FinalDemo\\BL\\data2.txt";
                    //File.WriteAllText(path, content);

                    _objResponse.Data = result;
                    _objResponse.IsError = false;
                    _objResponse.Message = "Success in write";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                _objResponse.IsError = true;
                _objResponse.Message = e.Message;
            }
            return _objResponse;
        }

        public Response GetSuperAdminView()
        {
            try
            {
                using (IDbConnection db = _dbfactory.Open())
                {
                    List<ADM01> _admlist = db.Select<ADM01>();
                    List<ODR01> _odrlist = db.Select<ODR01>();
                    List<PD01> _pdlist = db.Select<PD01>();

                    List<OrderDetails2> result = (from order in _odrlist
                                                  join admin in _admlist on order.R01F03 equals admin.M01F01
                                                  join printer in _pdlist on order.R01F04 equals printer.D01F01
                                                  select new OrderDetails2
                                                  {
                                                      OrderId = order.R01F01,
                                                      CreatedAt = order.R01F05,
                                                      Creator = admin.M01F02, // Admin name
                                                      CreatorRole = admin.M01F04, // Admin role
                                                      Printer = printer.D02F02, // Printer name
                                                      PrintingSpec = order.R01F02 // Printing spec of the order
                                                  }).ToList();

                    string path = "C:\\Users\\meet.j\\Desktop\\RKIT_Training\\Advance API\\FinalDemo\\BL\\data2.txt";

                    var options = new JsonSerializerOptions
                    {
                        WriteIndented = true,
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    };

                    File.WriteAllText(path, JsonSerializer.Serialize<List<OrderDetails2>>(result, options));

                    _objResponse.Data = "Url :" + path;
                    _objResponse.IsError = false;
                    _objResponse.Message = "Success in write";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                _objResponse.IsError = true;
                _objResponse.Message = e.Message;
            }
            return _objResponse;
            
        }

    }
}