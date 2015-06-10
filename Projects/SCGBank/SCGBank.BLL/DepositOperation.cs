using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCGBank.Data;
using SCGBank.Models;

namespace SCGBank.BLL
{
    public class DepositOperation
    {
        public Response<DepositReceipt> Deposit(Account account, decimal amount)
        {
            var response = new Response<DepositReceipt>();

            try
            {
                if (amount <= 0)
                {
                    response.Success = false;
                    response.Message = "Can not deposit a negative amount";
                }
                else
                {
                    account.Balance += amount;
                    var repo = new AccountRepository();
                    repo.UpdateAccount(account);
                    response.Success = true;

                    response.Data = new DepositReceipt();
                    response.Data.AccountNumber = account.AccountNumber;
                    response.Data.NewBalance = account.Balance;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
