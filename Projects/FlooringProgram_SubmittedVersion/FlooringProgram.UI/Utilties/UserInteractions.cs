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

                Console.WriteLine("That was not a valid Order number.");
                KeyToContinue();

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

                Console.WriteLine("That was not a valid Date.");
                KeyToContinue();

            } while (true);
        }


        public static UserInputRequest GetOrderNumberAndDate()
        {
            var request = new UserInputRequest();

            request.RequestOrder = new Order();

            request.Date = GetUserDate();
            request.RequestOrder.OrderNumber = GetOrderNumber();

            return request;
        }


        public static string GetUserString(string prompt)
        {
            do
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                bool validInput = IsValidString(input);

                if (validInput)
                {
                    return input;
                }

                Console.WriteLine("That was not a valid Input.");
                KeyToContinue();

            } while (true);

        }

        public static bool IsValidString(string str)
        {
            
            for (int i = 0; i < str.Length; i++)
            {
                if (str.Length > 40)
                {
                    return false;
                }


            }
            return true;
        }



        public static string GetUserState(string prompt)
        {
            var manager = ManagerFactory.CreateTaxManager();

            do
            {

                Console.Write(prompt);
                string input = Console.ReadLine().ToUpper().Trim();
                bool validInput = manager.IsValidState(input);

                if (validInput)
                {
                    return input;
                }

                Console.WriteLine("That was not a valid State Abbreviation.");
                KeyToContinue();

            } while (true);
        }

        public static string GetProductType(string prompt)
        {
            var manager = ManagerFactory.CreateProductManager();

            do
            {
                Console.Write(prompt);
                string input = Console.ReadLine().Trim();
                bool validInput = manager.IsValidProduct(input);

                if (validInput)
                {
                    return input;
                }

                Console.WriteLine("That was not a valid State Abbreviation.");
                KeyToContinue();

            } while (true);

        }

        

        public static decimal GetFloorArea(string prompt)
        {
            do
            {
                
                Console.Write(prompt);
                string input = Console.ReadLine();
                decimal floorArea;

                if (decimal.TryParse(input, out floorArea) || input == "")
                    return floorArea;

                Console.WriteLine("That was not a valid decimal.");
                KeyToContinue();

            } while (true);
        }

        public static void KeyToContinue()
        {
            Console.Write(" Press any key to continue...");
            Console.ReadKey();
        }
    }
}
