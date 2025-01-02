namespace Web_API.Models
{
    public static class OrderPrinterData
    {
        public static List<Order> currentOrders = new List<Order>() {
            {new Order("Magzine","x") },
            {new Order("Album","y") },
            {new Order("Photo Book","z") },
            {new Order("Magzine","y") }
        };

    }
}
