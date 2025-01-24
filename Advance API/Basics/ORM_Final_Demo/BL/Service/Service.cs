using ORM_Final_Demo.Extension;
using ORM_Final_Demo.Models;
using ORM_Final_Demo.Models.DTO;
using ORM_Final_Demo.Models.Enum;
using ORM_Final_Demo.Models.POCO;
using ORM_Final_Demo.ServiceProvicer.Interface;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System.Data;

namespace ORM_Final_Demo.ServiceProvicer.Service
{
    internal class BLService : IHelper<DTOEMP01>
    {
        private int _id;

        private readonly IDbConnectionFactory _dbfactory;

        private EMP01 _objEMP01;

        private Response _objResponse;

        public Op Type { get; set; }

        public BLService()
        {
            _objResponse = new();
            _dbfactory = new OrmLiteConnectionFactory("Server=localhost;Database=demo_mj_ormfinal;User=Admin;Password=gs@123;", MySqlDialect.Provider);

            if (_dbfactory == null)
            {
                throw new Exception("Db connection not established");
            }
            using(IDbConnection db = _dbfactory.Open())
            {
                db.CreateTableIfNotExists<EMP01>();
            }
        }

        // Get a employee by id
        public Response GetById(int id)
        {
            using(IDbConnection db = _dbfactory.Open())
            {
                EMP01 employee = db.SingleById<EMP01>(id);
                ReadDTOEMP01 readDTOEMP01 = employee.Convert<ReadDTOEMP01>();
                _objResponse.Data = readDTOEMP01;
                _objResponse.IsError = false;
                _objResponse.ErrorMessage = "Success";
                return _objResponse;
            }
        }

        // GET all employee
        public Response GetAll()
        {
            using (IDbConnection db = _dbfactory.Open())
            {
                List<EMP01> employee = db.Select<EMP01>();
                List<ReadDTOEMP01> _dtolist = new();
                foreach(EMP01 emp in employee)
                {
                    _dtolist.Add(emp.Convert<ReadDTOEMP01>());
                }
                _objResponse.Data = _dtolist;
                _objResponse.IsError = false;
                _objResponse.ErrorMessage = "Success";
                return _objResponse;
            }
        }

        // Private method to check if your exists
        private bool ISEMP01Exists(int id)
        {
            using (IDbConnection db = _dbfactory.Open())
            {
                return db.Exists<EMP01>(x => x.P01F01 == id);
            }
        }

        public void PreSave(DTOEMP01 dtoobj)
        {
            if (dtoobj == null || dtoobj.P01F01 <= 0)
            {
                throw new ArgumentNullException("proivde vallid dto");
            }

            _objEMP01 = dtoobj.Convert<EMP01>();
            _id = dtoobj.P01F01;
        }



        public Response Validate()
        {
            bool isEMP01 = ISEMP01Exists(_id);
            
            if (Type == Op.Update && !isEMP01)
            {
                _objResponse.IsError = true;
                _objResponse.ErrorMessage = "User Not Found";
            }
            else if (Type == Op.Add && isEMP01)
            {
                _objResponse.IsError = true;
                _objResponse.ErrorMessage = "User already Exists !";
            }
            return _objResponse;
        }

        public Response Save()
        {
            try
            {
                using (IDbConnection db = _dbfactory.OpenDbConnection())
                {
                    if (Type == Op.Add)
                    {
                        db.Insert(_objEMP01);
                        _objResponse.ErrorMessage = "Data Added";
                    }
                    if (Type == Op.Update)
                    {
                        db.Update(_objEMP01);
                        _objResponse.ErrorMessage = "Data Updated";
                    }
                }
            }
            catch (Exception ex)
            {
                _objResponse.IsError = true;
                _objResponse.ErrorMessage = ex.Message;
            }
            return _objResponse;
        }



    }
}
