using LearningWebApp.Data.Models;

namespace LearningWebApp.Data.Repositories.Repositories
{
    public static class Location
    {
        private static readonly Dictionary<int, List<int>> adjacencyList = new(); // readonly that basicaly stores 

        static Location()
        {
            // add some dommy data quicky
            Location.AddLocation(1, new List<int> { 2, 4, 5 });
            Location.AddLocation(2, new List<int> { 1, 4, 5 });
            Location.AddLocation(3, new List<int> { 1, 4, 5 });
            Location.AddLocation(4, new List<int> { 5, 1, 2 });
            Location.AddLocation(5, new List<int> { 4, 3, 2 });
            Location.AddLocation(6, new List<int> { 5, 4, 3 });

        }

        // Add some PDs

        // Add a location and its neighbors to the adjacency list
        public static void AddLocation(int locationId, List<int> neighbors)
        {
            adjacencyList[locationId] = neighbors;
        }

        // Get the neighbors for a specific location
        public static List<int> GetNeighbors(int locationId)
        {
            // we return the negihtbours or emplty list in case of no key found
            return adjacencyList.ContainsKey(locationId) ? adjacencyList[locationId] : new List<int>();
        }
    }
}
