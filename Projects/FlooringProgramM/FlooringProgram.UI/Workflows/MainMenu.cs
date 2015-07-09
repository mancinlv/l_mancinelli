using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FlooringProgram.UI.Workflows
{
    public class MainMenu
    {
        public void Execute()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("*************************************************************");
                Console.WriteLine("*");
                Console.WriteLine("*        Welcome to the SWC Corp. Flooring Program");
                Console.WriteLine("*");
                Console.WriteLine("* 1. Display Orders");
                Console.WriteLine("* 2. Add an Order");
                Console.WriteLine("* 3. Edit an Order");
                Console.WriteLine("* 4. Remove an Order");
                Console.WriteLine("* 5. (Q)uit");
                Console.WriteLine("*");
                Console.WriteLine("*************************************************************");

                Console.Write("\n\nEnter Choice: ");
                string input = Console.ReadLine().ToUpper().Trim();

                if (input == "Q")
                    break;

                ProcessChoice(input);

            } while (true);

        }

        private void ProcessChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    var displayOrderWorkflow = new DisplayOrderWorkflow();
                    displayOrderWorkflow.Execute();
                    break;
                case "2":
                    var addOrderWorkflow = new AddOrderWorkflow();
                    addOrderWorkflow.Execute();
                    break;
                case "3":
                    var editOrderWorkflow = new EditOrderWorkflow();
                    editOrderWorkflow.Execute();
                    break;
                case "4":
                    var deleteOrderWorkflow = new DeleteOrderWorkflow();
                    deleteOrderWorkflow.Execute();
                    break;


            }
        }


    }
}
