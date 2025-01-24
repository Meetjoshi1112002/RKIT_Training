using ORM_Demo.Models.Enum;

namespace ORM_Demo.Models.DTO
{
    public class AdminDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public AdminRole Role { get; set; }
    }
}
