using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCGBank.Data;
using SCGBank.Models;

namespace SCGBank.BLL
{
    public class TransferOperation
    {
        public Response<TransferReceipt> Transfer(Account account, decimal amount, Account account2)
        {
            var transferResponse = new Response<TransferReceipt>();

            var withdraw = new WithdrawOperation(); // inst new class
            var withdrawResponse = withdraw.Withdraw(account, amount);

            if (!withdrawResponse.Success)
            {
                transferResponse.Success = false;
                transferResponse.Message = withdrawResponse.Message;
                return transferResponse;

            }

            var deposit = new DepositOperation(); // inst new class
            var depositResponse = deposit.Deposit(account2, amount); // public method of class and params
            if (!depositResponse.Success)
            {
                transferResponse.Success = false;
                transferResponse.Message = depositResponse.Message;
                return transferResponse;
            }

            transferResponse.Success = true;
            transferResponse.Data = new TransferReceipt(); // inst of this class & output 
            transferResponse.Data.AccountNumber = account.AccountNumber;
            transferResponse.Data.NewBalance = account.Balance;
            return transferResponse;
        }
    }
}
