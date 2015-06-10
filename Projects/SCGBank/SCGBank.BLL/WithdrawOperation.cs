using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCGBank.Data;
using SCGBank.Models;

namespace SCGBank.BLL
{
    public class WithdrawOperation
    {
        public Response<WithdrawReceipt> Withdraw(Account account, decimal amount)
        {
            var WithdrawResponse = new Response<WithdrawReceipt>();
            try
            {
                if (account.Balance < amount)
                {
                    WithdrawResponse.Success = false;
                    WithdrawResponse.Message =
                        string.Format("Withdraw amount greater than balance amount. Must be less than ${0}",
                            account.Balance);
                }
                else
                {
                    account.Balance -= amount;
                    var repo = new AccountRepository();
                    repo.UpdateAccount(account);
                    WithdrawResponse.Success = true;

                    WithdrawResponse.Data = new WithdrawReceipt();
                    WithdrawResponse.Data.AcccountNumber = account.AccountNumber;
                    WithdrawResponse.Data.NewBalance = account.Balance;
                }
            }
            catch (Exception ex)
            {
                WithdrawResponse.Success = false;
                WithdrawResponse.Message = ex.Message;
            }
            return WithdrawResponse;
        }
    }
}
