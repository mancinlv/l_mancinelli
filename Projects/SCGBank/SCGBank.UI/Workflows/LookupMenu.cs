using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCGBank.BLL;
using SCGBank.Models;
using SCGBank.UI.Utilities;

namespace SCGBank.UI.Workflows
{
    public class LookupMenu
    {
        private Account _currentAccount;
        

        public void Execute()
        {
            var userAccountNumber = UserInteractions.GetAccountNumber();

            DisplayAccountInformation(userAccountNumber);
        }

        private void DisplayAccountInformation(int accountNumber)
        {
            var ops = new AccountOperations();
            var response = ops.GetAccount(accountNumber);
            Console.Clear();

            if (response.Success)
            {
                _currentAccount = response.Data;
                PrintAccountDetails(response);
                DisplayLookupMenu();

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("A problem occurred...");
                Console.WriteLine(response.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private void DisplayLookupMenu()
        {
            do
            {
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Transfer");
                Console.WriteLine("\n(Q)uit");

                Console.Write("\n\nEnter choice: ");
                string input = Console.ReadLine().ToUpper();

                if (input == "Q")
                    break;

                ProcessChoice(input);
            } while (true);
        }

        private void ProcessChoice(string input)
        {
            switch (input)
            {
                case "1":
                    var depositFlow = new DepositWorkflow();
                    depositFlow.Execute(_currentAccount);
                    break;
                case "2":
                    var withdrawFlow = new WithdrawWorkflow();
                    withdrawFlow.Execute(_currentAccount);
                    break;
                case "3":
                    var transferWorkflow = new TransferWorkflow();
                    transferWorkflow.Execute(_currentAccount);
                    break;
            }
        }

        private void PrintAccountDetails(Response<Account> response)
        {
            Console.WriteLine("Account Information");
            Console.WriteLine("=======================================");
            Console.WriteLine("Account Number: {0}", response.Data.AccountNumber);
            Console.WriteLine("Account Name: {0} {1}", response.Data.FirstName, response.Data.LastName);
            Console.WriteLine("Account Balance: {0:c}", response.Data.Balance);
        }

    }
}
