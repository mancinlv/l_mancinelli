using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SCGBank.BLL;
using SCGBank.Data;
using SCGBank.Models;

namespace SCGBank.Tests
{
    [TestFixture]
    public class AccountOperationsTests
    {
        [Test]
        public void NotFoundAccountReturnsFail()
        {
            var manager = new AccountOperations();

            var response = manager.GetAccount(105);

            Assert.IsFalse(response.Success);
        }

        [Test]
        public void FoundAccountReturnsSuccess()
        {
            var manager = new AccountOperations();

            var response = manager.GetAccount(1);

            Assert.IsTrue(response.Success);
            Assert.AreEqual(1, response.Data.AccountNumber);
            Assert.AreEqual("Mary", response.Data.FirstName);
            Assert.AreEqual("Jones", response.Data.LastName);
            Assert.AreEqual(347.00M, response.Data.Balance);
        }

        [Test]
        public void CanDepositMoney()
        {
            var manager = new AccountOperations();
            var deposit = new DepositOperation();

            var accountLoadResponse = manager.GetAccount(1);
            var depositResponse = deposit.Deposit(accountLoadResponse.Data, 50.00M);

            Assert.IsTrue(depositResponse.Success);

            var reloadAccountResponse = manager.GetAccount(1);

            Assert.AreEqual(1, reloadAccountResponse.Data.AccountNumber);
            Assert.AreEqual("Mary", reloadAccountResponse.Data.FirstName);
            Assert.AreEqual("Jones", reloadAccountResponse.Data.LastName);
            Assert.AreEqual(397.00M, reloadAccountResponse.Data.Balance);
        }

        [Test]
        public void RejectDepositNegativeMoney()
        {
            var manager = new AccountOperations();
            var deposit = new DepositOperation();

            var accountLoadResponse = manager.GetAccount(1);
            var depositResponse = deposit.Deposit(accountLoadResponse.Data, -50.00M);

            Assert.IsFalse(depositResponse.Success);
        }

        [Test]
        public void CanWithdrawMoney()
        {
            var withdraw = new WithdrawOperation();
            var manager = new AccountOperations();

            var accountLoadResponse = manager.GetAccount(2);
            var withdrawResponse = withdraw.Withdraw(accountLoadResponse.Data, 40.00M);

            Assert.IsTrue(withdrawResponse.Success);

            var reloadAccountResponse = manager.GetAccount(2);
            Assert.AreEqual(2, reloadAccountResponse.Data.AccountNumber);
            Assert.AreEqual("Bob", reloadAccountResponse.Data.FirstName);
            Assert.AreEqual("Elk", reloadAccountResponse.Data.LastName);
            Assert.AreEqual(83.00M, reloadAccountResponse.Data.Balance);

        }

        [Test]
        public void RejectWithdrawMoreThanBalance()
        {
            var withdraw = new WithdrawOperation();
            var manager = new AccountOperations();

            var accountLoadResponse = manager.GetAccount(2);
            var withdrawResponse = withdraw.Withdraw(accountLoadResponse.Data, 200.00M);

            Assert.IsFalse(withdrawResponse.Success);
        }

        [Test]
        public void CanTransferMoney()
        {
            var transfer = new TransferOperation();
            var manager = new AccountOperations();
            var account1LoadReponse = manager.GetAccount(1);
            var account2LoadReponse = manager.GetAccount(2);
            var transferResponse = transfer.Transfer(account1LoadReponse.Data, 50.00M, account2LoadReponse.Data);

            Assert.IsTrue(transferResponse.Success);

        }

        [Test]
        public void CanOpenAccount()
        {
            var manager = new AccountOperations();

            var account = new Account
            {
                AccountNumber = 0,
                FirstName = "Joe",
                LastName = "Smith",
                Balance = 10.00M
            };

            var response = manager.OpenAccount(account);

            Assert.IsTrue(response.Success);
            Assert.AreEqual(5, response.Data.AccountNumber);
            Assert.AreEqual("Joe", response.Data.FirstName);
            Assert.AreEqual("Smith", response.Data.LastName);
            Assert.AreEqual(10.00M, response.Data.Balance);
        }

        [Test]
        public void RejectAccountWithNoBalance()
        {
            var manager = new AccountOperations();

            var account = new Account
            {
                AccountNumber = 0,
                FirstName = "Amy",
                LastName = "Smith",
                Balance = 00.00M
            };

            var response = manager.OpenAccount(account);

            Assert.IsFalse(response.Success);

        }

        [Test]
        public void RejectAccountWithNoName()
        {
            var manager = new AccountOperations();

            var account = new Account
            {
                AccountNumber = 0,
                FirstName = "",
                LastName = "Smith",
                Balance = 10.00M
            };

            var response = manager.OpenAccount(account);

            Assert.IsFalse(response.Success);
        }
    }
}
