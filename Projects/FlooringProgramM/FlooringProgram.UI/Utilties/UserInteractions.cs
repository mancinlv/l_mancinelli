using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FlooringProgram.BLL;
using FlooringProgram.Models;

namespace FlooringProgram.UI.Utilties
{
    public class UserInteractions
    {

        public static int GetOrderNumber()
        {
            do
            {
                Console.Clear();
                Console.Write("Enter an order number: ");
                string input = Console.ReadLine();
                int orderNumber;

                if (int.TryParse(input, out orderNumber))
                    return orderNumber;

               Console.WriteLine("That was not a valid Order number. Press any key to continue...");
               Console.ReadKey();

            } while (true);

        }


        public static DateTime GetUserDate()
        {
            do
            {
                Console.Clear();
                Console.Write("Enter the date from which you wish to see an order (MM-DD-YYYY): ");
                string input = Console.ReadLine();
                DateTime userDate;

                if (DateTime.TryParse(input, out userDate))
                    return userDate;

                Console.WriteLine("That was not a valid Date. Press any key to continue...");
                Console.ReadKey();

            } while (true);
        }


        public static UserInputRequest GetOrderNumberAndDate()
        {
            var request = new UserInputRequest();

            request.RequestOrder = new Order();

            request.Date = UserInteractions.GetUserDate();

            DetailsPrinter.PrintOrdersSpecificDate(request.Date);

            request.RequestOrder.OrderNumber = UserInteractions.GetOrderNumber();

            return request;
        }


        public static string GetUserString(string prompt)
        {
            do
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                bool validInput = IsAlpha(input);

                if (validInput)
                {
                    return input;
                }
             
                Console.WriteLine("That was not a valid input. Press any key to continue...");
                Console.ReadKey();

            } while (true);

        }

        public static decimal GetUserDecimal(string prompt)
        {
            return GetUserDecimal(prompt, decimal.MinValue);
        }

        public static decimal GetUserDecimal(string prompt, decimal originalValue)
        {
            do
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();

                // if they entered nothing, return the current value
                if (string.IsNullOrEmpty(input) && originalValue != decimal.MinValue)
                {
                    return originalValue;
                }


                if (!decimal.TryParse(input, out originalValue))
                {
                    Console.WriteLine("That was not a valid number. Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    if (originalValue < 0)
                    {
                        Console.WriteLine("Number must be greater than zero. Press any key to continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        return originalValue;
                    }                   
                }                             
            } while (true);
        }

        public static bool IsAlpha(string str)
        {
            
            for (int i = 0; i < str.Length; i++)
            {
                if (!(char.IsLetter(str[i])))
                {
                    return false;
                }


            }
            return true;
        }

        public static string GetUserName(string defaultValue = "")
        {
            do
            {
                Console.Write("Enter the customer's name: ");
                string name = Console.ReadLine();

                if (name.Length != 0 || defaultValue != "")
                    return name;


            } while (true);
        }


        
        public static string GetUserState(string prompt, string originalState = "")
        {
            var manager = ManagerFactory.CreateTaxManager();
            do
            {
 
                Console.Write(prompt);
                string input = Console.ReadLine().ToUpper().Trim();
                bool validInput = manager.IsValidState(input);

                if (string.IsNullOrEmpty(input))
                {
                    return originalState;
                }

                if (!validInput)
                {
                    Console.WriteLine("That was not a valid State Abbreviation. Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    return input;
                }

                

            } while (true);
        }

        public static string GetProduct(string prompt)
        {
            var manager = ManagerFactory.CreateProductManager();
            do
            {

                Console.Write(prompt);
                string input = Console.ReadLine().ToUpper().Trim();
                bool validInput = manager.IsValidProduct(input);

                if (validInput)
                {
                    return input;
                }

                Console.WriteLine("That was not a valid Product. Press any key to continue...");
                Console.ReadKey();

            } while (true); 
        }

        public static void KeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
