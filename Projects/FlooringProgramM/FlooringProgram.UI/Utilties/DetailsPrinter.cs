using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.BLL;
using FlooringProgram.Models;

namespace FlooringProgram.UI.Utilties
{
    public class DetailsPrinter
    {
        public static void PrintOrderDetails(Order order)
        {

            Console.WriteLine("------------------------------------");
            Console.WriteLine("Order Number: {0}", order.OrderNumber);
            Console.WriteLine("=======================================");
            Console.WriteLine("Customer Name: {0}", order.CustomerName);
            Console.WriteLine("State: {0}", order.StateAbbreviation);
            Console.WriteLine("State Tax Rate: {0:C}", order.TaxRate);
            Console.WriteLine("Product type: {0}", order.ProductType);
            Console.WriteLine("Cost per square foot: {0:C}", order.CostPerSquareFoot);
            Console.WriteLine("Labor cost per square foot: {0:C}", order.LaborCostPerSquareFoot);
            Console.WriteLine("Total Floor Area: {0:F}", order.Area);
            Console.WriteLine("Material Cost: {0:C}", order.MaterialCost);
            Console.WriteLine("Labor Cost: {0:C}", order.LaborCost);
            Console.WriteLine("Total Tax: {0:C}", order.Tax);
            Console.WriteLine("Total: {0:C}", order.Total);
            Console.WriteLine("\n\n");

        }

        public static void PrintOrdersSpecificDate(DateTime date)
        {
            var manager = ManagerFactory.CreateOrderManager();
            var orders = manager.GetOrders(date);
            var orderList = orders.Data.OrderByDescending(o => o.OrderNumber);
            foreach (var order in orderList)
            {
                Console.WriteLine("Order from {0}:", date);
                Console.WriteLine(order);
                Console.WriteLine("-----------");
            }
        }
    }
}
