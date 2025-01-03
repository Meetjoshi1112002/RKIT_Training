using LearningWebApp.Data.Models;
using LearningWebApp.Data.Repositories.Repositories;

namespace LearningWebApp.Services
{
    public static class AssignDistributor
    {
        public static PrintingDistributor Assign(int order_id)
        {
            Order o = OrdersRepo.GetOrderById(order_id);
            if (o.PrinterId != null) throw new Exception("Your order has already a printer assigned so cannot be reassigned");
            int flag = 0;
            int startLocation = o.LocationId;
            List<PrintingDistributor> printers = Printers.GetAllPrinters();
            Queue<int> q = new();
            List<int> visited = new();

            q.Enqueue(startLocation);

            while (q.Count > 0)
            {
                int currentLocation = q.Dequeue();
                if (!visited.Contains(currentLocation))
                {
                    visited.Add(currentLocation);

                    // Debug: Log current location
                    Console.WriteLine($"Checking printers at location {currentLocation}");

                    List<PrintingDistributor> suitablePrinters = printers
                        .Where(p =>
                            (string.IsNullOrEmpty(o.PrintingSpecifications) || p.PrintingSpecifications == o.PrintingSpecifications) &&
                            p.LocationId == currentLocation)
                        .ToList();

                    if (suitablePrinters.Any())
                    {
                        PrintingDistributor selectedPrinter = suitablePrinters.OrderBy(v => v.OrderCount).First();
                        o.PrinterId = selectedPrinter.Id;
                        selectedPrinter.OrderCount++;

                        Console.WriteLine($"Selected vendor: {selectedPrinter.Name}");
                        flag = 1;
                        return selectedPrinter;
                    }

                    foreach (int neighbour in Location.GetNeighbors(currentLocation))
                    {
                        if (!visited.Contains(neighbour))
                        {
                            q.Enqueue(neighbour);
                        }
                    }
                }
            }

            Console.WriteLine("No suitable printer found.");
            return null;
        }

    }
}
