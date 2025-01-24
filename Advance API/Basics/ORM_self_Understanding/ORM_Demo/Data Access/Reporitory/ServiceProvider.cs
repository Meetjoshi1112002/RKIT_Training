using Mysqlx.Crud;
using ORM_Demo.Conversion;
using ORM_Demo.Models;
using ORM_Demo.Models.DTO;
using ORM_Demo.Models.Enum;
using ORM_Demo.Models.POCO;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * This object basically provides abtract view to the database
 * 
 * We use this object to interact with database by some speicific view
 * 
 * This object uses ORMlite to 
 
 
 */

namespace ORM_Demo.Data_Access.Reporitory
{
    public class ServiceProvider:IAdminInterface<AdminDTO>
    {
        private readonly IDbConnectionFactory _dbfactory; //pointer to connection pool


        private Response _responseObj;

        public ServiceProvider() // -- Here we set the connection object and the reponse and create admin table
        {
            _dbfactory = DBFactory.GetConnection();
            if(_dbfactory == null)
            {
                throw new Exception("Conneciton pool pointer object not found");
            }
            // Create the tables if they do not exist
            using (var db = _dbfactory.Open())
            {
                db.CreateTableIfNotExists<Admin>();  // Creates the Admin table if it doesn't exist
            }
            _responseObj = new Response();
        }


        // implement get all admin
        public Response GetAll()
        {
            using(var db = _dbfactory.Open())
            {
                List<Admin> data = db.Select<Admin>();
                List<AdminDTO> res_data = new();
                foreach(var item in data)
                {
                    res_data.Add(Converstion.PocoToDto(item));
                }
                _responseObj.Data = res_data;
                _responseObj.IsError = false;
                _responseObj.Message = "List of all admin to you";
                return _responseObj;
            }
        }

        public Response GetById(int Id)
        {
            using (var db = _dbfactory.Open())
            {
                Admin data = db.SingleById<Admin>(Id);
                _responseObj.Data = Converstion.PocoToDto(data);
                _responseObj.IsError = false;
                _responseObj.Message = "Your admin to you";
                return _responseObj;
            }
        }

        public Response AddAdmin(AdminDTO dto, string passw)
        {
            using (var db = _dbfactory.Open())
            {
                Admin ojb = Converstion.DtoToPoco(dto);
                ojb.Password = passw;
                long data = db.Insert<Admin>(ojb);
                Console.WriteLine(data + "Obtained to me during the insewrt operation");
                _responseObj.Data = data;
                _responseObj.IsError = false;
                _responseObj.Message = "Successfuly added";
                return _responseObj;
            }
        }

        public Response UpdateAdmin(AdminDTO dto, string passw = null)
        {
            using (var db = _dbfactory.Open())
            {
                Admin ob = Converstion.DtoToPoco(dto);
                if(passw != null)
                {
                    ob.Password = passw;
                }
                db.Update<Admin>(ob);
                
                _responseObj.Data = ob;
                _responseObj.IsError = false;
                _responseObj.Message = "success update";
                return _responseObj;
            }
        }

        public Response DeleteAdmin(int Id)
        {
            using (var db = _dbfactory.Open())
            {
                int rs = db.Delete<Admin>(x => x.Id == Id);
                Console.WriteLine(rs + "Obtained to me during the insewrt operation");
                _responseObj.Data = rs;
                _responseObj.IsError = false;
                _responseObj.Message = "Deleted successfully";
                return _responseObj;
            }
        }


    }
}
