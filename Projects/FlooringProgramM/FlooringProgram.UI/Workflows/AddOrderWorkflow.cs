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
    class AddOrderWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Add an Order");
            Console.WriteLine("\n - - - - - - - - - - - - - - - - - - - - -");
            while (true)
            {
                var request = RequestUserForInfo();

                request.Date = DateTime.Today;

                var manager = ManagerFactory.CreateOrderManager();

                var response = manager.CompleteOrder(request);



                if (response.Success == false)
                {
                    Console.Clear();
                    Console.WriteLine("\tThere was an error creating your order; See below for details:");
                    Console.WriteLine("\t\n" + response.Message);
                    Console.ReadLine();
                }
                else
                {
                    var confirmation = DisplayNewOrderConfirmation(response);

                    if (confirmation == "Y")
                    {                      
                        var addResponse = manager.AddOrder(request);
                        
                        if (addResponse.Success == false)
                        {
                            Console.WriteLine("There was an error saving your order; See below for details:");
                            Console.WriteLine("\t\n" + response.Message);
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Your order was successfully added! The number of your new order is {0}.", addResponse.Data.OrderNumber);
                            Console.ReadKey();
                            break;
                        }
                       
                    }
                    else
                    {
                        Console.WriteLine("The order was discarded.");
                        Console.ReadKey();
                        break;
                    }
                }
                
            }
        }

        private string DisplayNewOrderConfirmation(Response<Order> response)
        {
            Console.WriteLine("New Order Confirmation");
            Console.WriteLine("______________________________________________\n");
            
   
                Console.WriteLine("=======================================");
                Console.WriteLine("Customer Name: {0}", response.Data.CustomerName);
                Console.WriteLine("State: {0}", response.Data.StateAbbreviation);
                Console.WriteLine("State Tax Rate: {0:C}", response.Data.TaxRate);
                Console.WriteLine("Product type: {0}", response.Data.ProductType);
                Console.WriteLine("Cost per square foot: {0:C}", response.Data.CostPerSquareFoot);
                Console.WriteLine("Labor cost per square foot: {0:C}", response.Data.LaborCostPerSquareFoot);
                Console.WriteLine("Total Floor Area: {0:F}", response.Data.Area);
                Console.WriteLine("Material Cost: {0:C}", response.Data.MaterialCost);
                Console.WriteLine("Labor Cost: {0:C}", response.Data.LaborCost);
                Console.WriteLine("Total Tax: {0:C}", response.Data.Tax);
                Console.WriteLine("Total: {0:C}", response.Data.Total);
                Console.WriteLine("\n\n");
            
                var confirmation = UserInteractions.GetUserString("Would you like to save this order? (Y)es or (N)o?");
                Console.ReadLine().ToUpper().Trim();
                return confirmation;


        }

        private UserInputRequest RequestUserForInfo()
        {
            var request = new UserInputRequest();

            request.RequestOrder = new Order();

            request.RequestOrder.CustomerName = GetCustomerName();
            request.RequestOrder.StateAbbreviation = GetCustomerState();
            request.RequestOrder.ProductType = GetProductType();
            request.RequestOrder.Area = GetFloorArea();
            Console.Clear();

            return request;
        }

        private decimal GetFloorArea()
        {

            return UserInteractions.GetUserDecimal("Enter the total Area of the Floor in square feet: ");

        }

        private string GetProductType()
        {

            return UserInteractions.GetUserString("Enter the Product Type: ");
        }

        private string GetCustomerState()
        {
 
            return UserInteractions.GetUserState("Enter Two Character State Abbreviation [ex: NY]: ");
        }

        private string GetCustomerName()
        {

            return UserInteractions.GetUserString("Enter the Customer Name: ");
        }
    }
}
