using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCGBank.Data;
using SCGBank.Models;

namespace SCGBank.BLL
{
    public class AccountOperations
    {
        public Response<Account> GetAccount(int accountNumber)
        {
            var repo = new AccountRepository();
            var response = new Response<Account>();

            try
            {
                var account = repo.LoadAccount(accountNumber);

                if (account == null)
                {
                    response.Success = false;
                    response.Message = "Account not found!";
                }
                else
                {
                    response.Success = true;
                    response.Data = account;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;

        }

        public Response<Account> OpenAccount(Account accountToOpen)
        {
            var response = new Response<Account>();
            

            try
            {
                if (accountToOpen.Balance <= 0)
                {
                    response.Success = false;
                    response.Message = "Must provide a positive balance to open an account.";
                }
                else if ((accountToOpen.FirstName.Trim().Length == 0) || (accountToOpen.LastName.Trim().Length == 0))
                {
                    response.Success = false;
                    response.Message = "Must provide both a first and a last name to open an account";
                }
                else
                {
                    var repo = new AccountRepository();
                    var allAccounts = repo.GetAllAcounts();

                    var accountNumber = allAccounts.Max(a => a.AccountNumber);
                    accountNumber++;

                    accountToOpen.AccountNumber = accountNumber;

                    repo.AddAccount(accountToOpen);

                    response.Success = true;
                    response.Data = accountToOpen;
                }
                
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;

        }

        public Response<Account> DeleteAccount(Account accountToDelete)
        {
            var response = new Response<Account>();
            
            try
            {
                if (response.Success)
                {
                    var repo = new AccountRepository();
                    var allAccounts = repo.GetAllAcounts();

                    var accountNumber = allAccounts.RemoveAll(a => a.AccountNumber);
                    accountToDelete.AccountNumber = accountNumber;
                    
                    repo.DeleteAccount(accountToDelete);
                    

                    response.Success = true;
                    response.Data = accountToDelete;
                }
            }
            

        }
    }
}
