using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.BLL;
using FlooringProgram.Models;
using FlooringProgram.UI.Utilties;

namespace FlooringProgram.UI.Workflows
{
    public class EditOrderWorkflow
    {

        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Edit an Order");
            Console.WriteLine("\n - - - - - - - - - - - - - - - - - - - - -");
            var manager = ManagerFactory.CreateOrderManager();
            var request = UserInteractions.GetOrderNumberAndDate();

            var response = manager.GetOrder(request);
            if (response.Success == false)
            {
                Console.WriteLine("There was a problem finding that order; See below.");
                Console.WriteLine(response.Message);
                UserInteractions.KeyToContinue();
            }
            else
            {

                request.RequestOrder = response.Data;

                var editRequest = PromptUserForEditInformation(response.Data);
                editRequest.Date = request.Date;

                var promptResponse = manager.CompleteOrder(editRequest);


                if (promptResponse.Success == false)
                {
                    Console.WriteLine("There was a problem editing your order. See below for more information:  ");
                    Console.WriteLine(promptResponse.Message);
                    Console.ReadLine();
                    UserInteractions.KeyToContinue();
                }

                else
                {
                    var editResponse = manager.EditOrder(editRequest);

                    if (editResponse.Success == false)
                    {
                        Console.WriteLine("There was a problem editing your order. See below for more information: ");
                        Console.WriteLine(editResponse.Message);
                        UserInteractions.KeyToContinue();

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Your order was successfully edited!");

                        Console.WriteLine("\nEdited Order");

                        DetailsPrinter.PrintOrderDetails(response.Data);
                        UserInteractions.KeyToContinue();
                    }
                }


            }


        }

        private UserInputRequest PromptUserForEditInformation(Order order)
        {
            var request = new UserInputRequest();
            request.RequestOrder = new Order();
            request.RequestOrder.OrderNumber = order.OrderNumber;


            #region  CustomerName
            var nameFormat = String.Format("Enter the Customer Name ({0}) : ", order.CustomerName);
            var name = UserInteractions.GetUserString(nameFormat);
           
            if (name != "")
            {
                request.RequestOrder.CustomerName = name;
            }
            else
            {
                request.RequestOrder.CustomerName = order.CustomerName;
            }

            #endregion CustomerName

            #region State
            

            
                var promptState = String.Format("Enter the State Abbreviation ({0}) : ", order.StateAbbreviation);
                request.RequestOrder.StateAbbreviation = UserInteractions.GetUserState(promptState, order.StateAbbreviation);
              

            #endregion State

            #region Product

            var productFormat = String.Format("Enter the Product Abbreviation ({0}) : ", order.ProductType);
            var product = UserInteractions.GetUserString(productFormat);
            if (product != "")
            {
                request.RequestOrder.ProductType = product;
            }
            else
            {
                request.RequestOrder.ProductType = order.ProductType;
            }
            


            #endregion Product

 
            //area
                var promptArea = String.Format("Enter the total Area of the floor in square feet ({0}) : ", order.Area);             
                request.RequestOrder.Area = UserInteractions.GetUserDecimal(promptArea, order.Area);
 

            //materialCost
                var promptMaterial = string.Format("Enter the Material Cost per square foot ({0}) : ",
                    order.CostPerSquareFoot);
                request.RequestOrder.CostPerSquareFoot = UserInteractions.GetUserDecimal(promptMaterial, order.CostPerSquareFoot);

            
            //laborCost
                var promptLabor = string.Format("Enter the Labor Cost Per Square Foot ({0}) : ",
                    order.CostPerSquareFoot);
                request.RequestOrder.LaborCostPerSquareFoot = UserInteractions.GetUserDecimal(promptLabor, order.LaborCostPerSquareFoot);
              
            return request;

        }


    }
}
