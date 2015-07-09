using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.BLL;
using FlooringProgram.Models;
using FlooringProgram.UI.Utilties;

namespace FlooringProgram.UI.Workflows
{
    public class DisplayOrderWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Display an Order");
            Console.WriteLine("\n - - - - - - - - - - - - - - - - - - - - -");

            var userDate = UserInteractions.GetUserDate();
            
            DisplayOrderInformation(userDate);
        }

        private void DisplayOrderInformation(DateTime userDate)
        {
            var ops = ManagerFactory.CreateOrderManager();

            var response = ops.GetOrders(userDate);
            Console.Clear();

            if (response.Success)
            {
                //DisplayOrdersForDate(response);
                PrintOrdersDetails(response, userDate);

                Console.WriteLine("\n\nPress any key to go back to the Main Menu...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("A problem occured...");
                Console.WriteLine(response.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        

        private void PrintOrdersDetails(Response<List<Order>> response, DateTime date)
        {
            Console.WriteLine("All Orders for {0}", date);
            Console.WriteLine("______________________________________________\n");
            foreach (var order in response.Data)
            {
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

            
        }


    }
}
