using ORM_Demo.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Demo.Data_Access.Reporitory
{
    public interface IAdminInterface
    {
        List<AdminDTO> GetAll();
        AdminDTO GetById(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
