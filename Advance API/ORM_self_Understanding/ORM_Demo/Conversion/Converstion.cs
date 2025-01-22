using ORM_Demo.Models.DTO;
using ORM_Demo.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Demo.Conversion
{
    public static class Converstion
    {
        public static Admin DtoToPoco(AdminDTO _obj)
        {
            Admin _adminobj = new Admin() { 
                Name = _obj.Name,
                Role = _obj.Role
            };

            if (_obj.Id != 0) 
            {
                _adminobj.Id = _obj.Id;
            }

            return _adminobj;
        }

        public static AdminDTO PocoToDto(Admin _obj)
        {
            return new AdminDTO() 
            { 
                Id= _obj.Id,
                Role= _obj.Role,
                Name= _obj.Name
            };
        }
    }
}
