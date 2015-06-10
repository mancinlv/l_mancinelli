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
    public class TransferWorkflow
    {
       
        public void Execute(Account account)
        {
            
            var accountOps = new TransferOperation();

            decimal amount = GetDepositAmount();
            Account recipent = GetRecipentFromUser();

            var response = accountOps.Transfer(account, amount, recipent);

            if (response.Success)
            {
                Console.Clear();
                Console.WriteLine(" Account {0} deposited to Account {1}, New Balance: {2:c}",
                    response.Data.AccountNumber, recipent.AccountNumber, response.Data.NewBalance);
                UserInteractions.KeyToContinue();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("An error occurred: {0}", response.Message);
                UserInteractions.KeyToContinue();
            }
        }

        private Account GetRecipentFromUser()
        {
            while (true)
            {
                var recipentID = UserInteractions.GetAccountNumber();
                var ops = new AccountOperations();
                var response = ops.GetAccount(recipentID);
                if (response.Success)
                {
                    return response.Data;
                }
                else
                {
                    Console.WriteLine("Account not found. Try again.");

                }
            }
        }

        private decimal GetDepositAmount()
        {
            do
            {
                 
                Console.Write("Enter a deposit amount: ");
                var input = Console.ReadLine();
                decimal amount;

                if (decimal.TryParse(input, out amount))
                    return amount;

                Console.WriteLine("That was not a valid amount.  Please enter in ##.## format");
                UserInteractions.KeyToContinue();
            } while (true);
        }
    }
}
