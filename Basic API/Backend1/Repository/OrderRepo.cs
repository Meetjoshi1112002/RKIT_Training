using Backend1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend1.Repository
{
    static public class OrdersRepo
    {
        public static readonly List<Order> orders = new List<Order>();

        static OrdersRepo()
        {
            OrdersRepo.AddOrder(new Order()
            {
                Name = "Magzine",
                PrintingSpecifications = "ColorPrinting",
                LocationId = 1
            });

            OrdersRepo.AddOrder(new Order()
            {
                Name = "Photo Album",
                PrintingSpecifications = "BlackAndWhitePrinting",
                LocationId = 1
            });

        }
        public static void AddOrder(Order o)
        {
            orders.Add(o);
        }
        public static List<Order> GetAllOrder()
        {
            return orders;
        }
        public static Order GetOrderById(int id)
        {
            Order o = orders.FirstOrDefault(e => e.Id == id);
            if (o == null)
            {
                throw new Exception("Order not found bhai");
            }
            return o;
        }

        static public void RemoveOrder(int Id)
        {
            int num = orders.RemoveAll(propa => propa.Id == Id);

            if (num == 0)
            {
                throw new Exception("No sucgh printer fouden");


            }
        }
    }
}