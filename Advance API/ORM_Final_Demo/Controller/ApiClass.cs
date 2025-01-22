using ORM_Final_Demo.Models.DTO;
using ORM_Final_Demo.ServiceProvicer.Service;
using ORM_Final_Demo.Models.Enum;
using ORM_Final_Demo.Models;

namespace ORM_Final_Demo.Controller
{
    public static class ApiClass
    {
        private readonly static BLService _objService;
        
        static ApiClass()
        {
            _objService = new BLService();
        }
        public static ReadDTOEMP01 GetById(int id)
        {
            return _objService.GetById(id).Data;
        }

        public static List<ReadDTOEMP01> GetAll()
        {
            return _objService.GetAll().Data;
        }

        public static void CreateEmployee(DTOEMP01 dto)
        {
            _objService.Type = Op.Add;
            _objService.PreSave(dto);

            Response res = _objService.Validate();
            if (res.IsError)
            {
                throw new ArgumentException(res.ErrorMessage);
            }
            _objService.Save();
        }

        public static void UpdateEmployee(DTOEMP01 dto)
        {
            _objService.Type = Op.Update;
            _objService.PreSave(dto);

            Response res = _objService.Validate();
            if (res.IsError)
            {
                throw new ArgumentException(res.ErrorMessage);
            }
            _objService.Save();
        }
    }
}
