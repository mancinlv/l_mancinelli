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
            

            do
            {
                var stateFormat = String.Format("Enter the State Abbreviation ({0}) : ", order.StateAbbreviation);
                Console.Write(stateFormat);
                var state = Console.ReadLine();
                
                String states =
                    "|AL|AK|AS|AZ|AR|CA|CO|CT|DE|DC|FM|FL|GA|GU|HI|ID|IL|IN|IA|KS|KY|LA|ME|MH|MD|MA|MI|MN|MS|MO|MT|NE|NV|NH|NJ|NM|NY|NC|ND|MP|OH|OK|OR|PW|PA|PR|RI|SC|SD|TN|TX|UT|VT|VI|VA|WA|WV|WI|WY|";

                state = "|" + state + "|";

                if ((state != "||") && (state.Length == 4 && states.IndexOf(state) > 0))
                {
                    state = state.Substring(1, 2);
                    request.RequestOrder.StateAbbreviation = state;
                    break;
                }
                else if (state == "||")
                {
                    request.RequestOrder.StateAbbreviation = order.StateAbbreviation;
                    break;
                }

                Console.WriteLine("That was not a valid state. Press any key to re-enter your state.");
                Console.ReadKey();
            } while (true); 

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

            #region Area
            do
            {
                var areaFormat = String.Format("Enter the total Area of the floor ({0}) : ", order.Area);
                Console.Write(areaFormat);

                string input = Console.ReadLine();

                if (input == "")
                {
                    request.RequestOrder.Area = order.Area;
                    break;
                }

                decimal floorArea;

                if (decimal.TryParse(input, out floorArea) || input == "")
                {
                    request.RequestOrder.Area = floorArea;
                    break;

                }
                    
                Console.WriteLine("That was not a valid decimal. Press any key to re-enter a valid value...");
                Console.ReadKey();

            } while (true);

            #endregion Area

            #region MaterialCostPerSquareFoot
            do
            {
                var costFormat = string.Format("Enter the Material Cost Per Square Foot ({0}) : ",
                    order.CostPerSquareFoot);
                Console.Write(costFormat);

                string input = Console.ReadLine();

                if (input == "")
                {
                    break;
                }

                decimal materialCostPerSquareFoot;
                if (decimal.TryParse(input, out materialCostPerSquareFoot)) //|| input == "")?
                {
                    request.RequestOrder.CostPerSquareFoot = materialCostPerSquareFoot;
                    break;

                }
                    
                Console.WriteLine("That was not a valid decimal value. Press any key to re-enter a valid value...");
                Console.ReadKey();

            } while (true);

            #endregion MaterialCostPerSquareFoot

            #region LaborCostPerSquareFoot

            do
            {
                var laborFormat = string.Format("Enter the Labor Cost Per Square Foot ({0}) : ",
                    order.CostPerSquareFoot);
                Console.Write(laborFormat);

                string input = Console.ReadLine();

                if (input == "")
                {
                    break;
                }

                decimal laborCostPerSquareFoot;
                if (decimal.TryParse(input, out laborCostPerSquareFoot)) //|| input == "")?
                {
                    request.RequestOrder.LaborCostPerSquareFoot = laborCostPerSquareFoot;
                    break;
                }

                Console.WriteLine("That was not a valid decimal value. Press any key to re-enter a valid value...");
                Console.ReadKey();

            } while (true);

#endregion LaborCostPerSquareFoot



            return request;

        }


    }
}
