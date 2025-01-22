using CRUD_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Demo.BL
{
    public interface IUserService<T> where T : class
    {
        // we need presave , validdate and save and same for delete

        Response GetAll();

        Response GetById(int id);
        void PreDelete(int _id);
        void PreSave(T obj);

        Response Validate();

        Response Save();


    }
}
