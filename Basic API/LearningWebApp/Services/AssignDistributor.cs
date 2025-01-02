using LearningWebApp.Data.Models;
using LearningWebApp.Data.Repositories.Repositories;

namespace LearningWebApp.Services
{
    public static class AssignDistributor
    {
        static public bool assign(Order o) // returns true if printer assigned successfully
        {
            int flag = 0;
            int startLocation = o.LocationId;
            List<PrintingDistributor> printers = Printers.GetAllPrinters();
            Queue<int> q = new();
            List<int> visited = new();

            q.Enqueue(startLocation);

            while(q.Count > 0)
            {
                int currentLocation = q.Dequeue();
                if(!visited.Contains(currentLocation))
                {
                    visited.Add(currentLocation);

                    List<PrintingDistributor> suitablePrinters = printers.Where(p => p.PrintingSpecifications == o.PrintingSpecifications && p.LocationId == o.LocationId).ToList();
                    if (suitablePrinters.Any())
                    {
                        PrintingDistributor selectedPrinter = suitablePrinters.OrderBy(v => v.OrderCount).First();
                        o.PrinterId = selectedPrinter.Id;
                        Console.WriteLine("The selected vendor is"+selectedPrinter.Name);
                        flag = 1; break;
                    }
                    foreach( int neighbour in Location.GetNeighbors(currentLocation))
                    {
                        q.Enqueue(neighbour);
                    }
                }
            }

            return flag == 1;

        }
    }
}
