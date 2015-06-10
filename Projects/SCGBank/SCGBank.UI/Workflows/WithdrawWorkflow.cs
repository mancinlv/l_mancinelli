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
    public class WithdrawWorkflow
    {
        public void Execute(Account account)
        {
            decimal amount = GetWithDrawAmount();
            var accountOps = new WithdrawOperation();

            var response = accountOps.Withdraw(account, amount);

            if (response.Success)
            {
                Console.WriteLine("Withdraw from Account {0}, New Balance: {1:c}", response.Data.AcccountNumber, response.Data.NewBalance);
                UserInteractions.KeyToContinue();
            }
            else
            {
                Console.WriteLine("An error has occurred: {0}", response.Message);
                UserInteractions.KeyToContinue();
            }
        }

        private decimal GetWithDrawAmount()
        {
            do
            {
                Console.WriteLine("Enter an amount to withdraw?: ");
                var input = Console.ReadLine();
                decimal amount;

                if (decimal.TryParse(input, out amount))
                    return amount;

                else
                {
                    Console.WriteLine("That was not a valid amount.  Please enter in ##.## format");
                    UserInteractions.KeyToContinue();
                }
            } while (true);
        }
    }
}
