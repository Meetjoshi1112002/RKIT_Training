using LearningWebApp.Data.Models;

namespace LearningWebApp.Data.Repositories.Repositories
{
    public static class Printers
    {
        public static readonly List<PrintingDistributor> PDs = new ();

        static Printers()
        {
            Printers.AddPrinter(new PrintingDistributor()
            {
                Name="Meet Joshi",
                LocationId = 6,
                PrintingSpecifications = "ColorPrinting",
                OrderCount = 1,
            });
            Printers.AddPrinter(new PrintingDistributor()
            {
                Name = "Keyur sir",
                LocationId = 2,
                PrintingSpecifications = "BlackAndWhitePrinting",
                OrderCount = 2
            });
            Printers.AddPrinter(new PrintingDistributor()
            {
                Name = "Rohanshu",
                LocationId = 6,
                PrintingSpecifications = "ColorPrinting",
                OrderCount = 10
            });
            Printers.AddPrinter(new PrintingDistributor()
            {
                Name = "Jayeeta",
                LocationId = 2,
                PrintingSpecifications = "BlackAndWhitePrinting",
                OrderCount = 5
            });
            
        }

        static public void AddPrinter(PrintingDistributor p)
        {
            PDs.Add(p);
        }

        static public List<PrintingDistributor> GetAllPrinters()
        {
            return PDs;
        }

        static public PrintingDistributor GetById(string Id)
        {
            return PDs.FirstOrDefault(p => p.Id == Id);
        }

        static public void RemovePrinter(String Id)
        {
            int num = PDs.RemoveAll(propa => propa.Id == Id);

            if(num == 0)
            {
                throw new Exception("No sucgh printer fouden");
            }
        }

    }
}
