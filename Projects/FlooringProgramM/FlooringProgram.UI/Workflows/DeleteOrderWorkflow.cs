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
    public class DeleteOrderWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Delete an Order");
            Console.WriteLine("\n - - - - - - - - - - - - - - - - - - - - -");
            while (true)
            {
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
                    Console.WriteLine("Order to Delete");
                    Console.WriteLine("- - - - - - - - - - - - ");

                    DetailsPrinter.PrintOrderDetails(response.Data);

                    Console.WriteLine("Are you certain that you want to delete order number {0}? " +
                                      "If yes, push \"Y\", otherwise push enter to escape operation.", response.Data.OrderNumber);
                    var confirmationInput = Console.ReadLine().ToUpper();

                    if (confirmationInput == "Y")
                    {
                        var deleteResponse = manager.DeleteOrder(request);

                        if (deleteResponse.Success == false)
                        {
                            Console.WriteLine("There was an error saving your order; See below for details:");
                            Console.WriteLine("\t\n" + deleteResponse.Message);
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Order number {0} was successfully deleted.", deleteResponse.Data.OrderNumber);
                            Console.ReadKey();
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nothing was done to order number {0}. Press any key to go back to the main menu.", response.Data.OrderNumber);
                        Console.ReadKey();
                        break;
                    }
                }
            }

        }

    }
}
