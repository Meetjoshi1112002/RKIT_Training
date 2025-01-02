using LearningWebApp.Data.Models;

namespace LearningWebApp.Data.Repositories.Repositories
{
    public static class Printers
    {
        public static readonly List<PrintingDistributor> PDs = new ();

        static Printers()
        {
            Printers.AddPrinter(new PrintingDistributor("Meet joshi", 1, "ColorPrinting"));
            Printers.AddPrinter(new PrintingDistributor("Keyur sir", 2, "BlackAndWhitePrinting"));
            Printers.AddPrinter(new PrintingDistributor("Rohanshu", 3, "ColorPrinting"));
            Printers.AddPrinter(new PrintingDistributor("Jayeeta", 4, "ColorPrinting"));
        }

        static public void AddPrinter(PrintingDistributor p)
        {
            PDs.Add(p);
        }

        static public List<PrintingDistributor> GetAllPrinters()
        {
            return PDs;
        }

    }
}
