namespace LearningWebApp.Data.Models
{
    public class PrintingDistributor
    {
        public string Id { get; private set; } // Id of this PDs must be logical
        public string Name { get; set; }
        public int OrderCount { get; set; }
        public int LocationId { get; set; } // Location of the vendor (as an int)
        public string PrintingSpecifications { get; set; }

        public PrintingDistributor(string name, int locationId, string printingSpecifications)
        {
            Id = Guid.NewGuid().ToString(); // Generate unique ID;
            Name = name;
            LocationId = locationId;
            PrintingSpecifications = printingSpecifications;
        }
    }
}
