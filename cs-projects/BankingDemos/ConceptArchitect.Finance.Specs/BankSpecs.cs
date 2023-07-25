using ConceptArchitect.Finance.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ConceptArchitect.Finance.Specs
{
    public class BankSpecs
    {
        string bankName = "ICICI";
        double rate = 12;

        string validPassword = "p@ssword";
        double amount = 20000,balance;
        Bank bank;

        int account1, account3, closedAccount;

        public BankSpecs()
        {
            bank = new Bank(bankName, rate);
            
            account1 = bank.OpenAccount("Sanjay Mall", validPassword, amount);
            closedAccount = bank.OpenAccount("Amit Singh", validPassword, amount);
            account3 = bank.OpenAccount("Prabhat Singh", validPassword, amount);
            

            bank.CloseAccount(closedAccount, validPassword, out balance);
        }

        private void AssertFail(string reason="Not Yet Implemented")
        {
            Assert.True(false, reason);
        }

        [Fact]
        public void BankShouldHaveAName()
        {
            
            Bank bank = new Bank(bankName,rate);

            Assert.Equal(bankName, bank.Name);
        }

        [Fact]
        public void BankShouldHaveAnInterestRate()
        {
            Bank bank = new Bank(bankName,rate);

            Assert.Equal((double)rate, bank.Rate);
        }

        [Fact]
        public void OpenAccountShouldAcceptNamePasswordAndBalance()
        {
            string name = "Name";
            bank.OpenAccount(name, validPassword, amount);
        }

        [Fact]
        public void OpenAccountShouldHaveAccountNumberInIncreasingSequence()
        {
            int first = bank.OpenAccount("First", validPassword, amount);

            for(int i = 1;i<=3; i++)
            {
                int newAccount = bank.OpenAccount("New Account", "p@ssword", 20000);
                Assert.Equal(first+i, newAccount);
            }
        }

        [Fact]
        public void CloseAccountShouldFailForInvalidAccountNumber()
        {
            Status status= bank.CloseAccount(-1,validPassword, out balance);

            Assert.Equal(Status.INVALID_ACCOUNT_NUMBER, status);
        }

        [Fact]
        public void CloseAccountShouldFailForInvalidPassword()
        {
            //Arrange
            var accountNumber=bank.OpenAccount("Name", validPassword, amount);
            //Act
            var status = bank.CloseAccount(accountNumber, "wrong password", out balance);

            //Assert
            Assert.Equal(Status.INVALID_CREDENTIALS, status);
        }

        [Fact]
        public void CloseAccountShouldFailForAlreadyClosedAccount()
        {
            //Arrange
            var accountNumber=bank.OpenAccount("Name", validPassword, amount);
            bank.CloseAccount(accountNumber, validPassword, out balance);

            //ACT
            var status = bank.CloseAccount(accountNumber, validPassword, out balance);

            //Assert
            Assert.Equal(Status.INVALID_ACCOUNT_NUMBER, status);
        }

        [Fact]
        public void CloseAccountShouldFailForBalanceBelowZero()
        {
            //Arrange
            var accountNumber = bank.OpenAccount("Name", validPassword, -1);

            //ACT
            var status = bank.CloseAccount(accountNumber, validPassword, out balance);

            //Assert
            Assert.Equal(Status.INSUFFICIENT_BALANCE, status);
        }


        [Fact]
        public void CloseAccountOnSuccessShouldReturnTheRemainingBalance()
        {
            //Arrange
            var accountNumber = bank.OpenAccount("Name", validPassword, amount);

            //ACT
            double balance;
            Status success= bank.CloseAccount(accountNumber,validPassword, out balance);

            //Assert
            Assert.Equal(Status.SUCCESS, success);
            Assert.Equal(amount, balance);
        }

        [Fact]
        public void Deposit_FailsForInvalidAccountNumber()
        {
            int accountNumber = -1;
            Status status = bank.Deposit(accountNumber, amount);

            Assert.Equal(Status.INVALID_ACCOUNT_NUMBER, status);
            
        }

        [Fact]
        public void Deposit_FailsForClosedAccount()
        {
            var status = bank.Deposit(closedAccount, 1);

            Assert.Equal(Status.INVALID_ACCOUNT_NUMBER, status);
        }

        [Fact]
        public void GetBalance_FailsForInvalidAccountNumber()
        {
            int accountNumber = -1;
            double balance = bank.GetBalance(accountNumber, validPassword);

            Assert.Equal(-1, balance);
        }

        [Fact]
        public void GetBalance_FailsForInvalidPassword()
        {
            double balance = bank.GetBalance(account1, "wrong password");

            Assert.Equal(-1, balance);
        }

        [Fact]
        public void GetBalance_FailsForClosedAccountNumber()
        {
            double balance = bank.GetBalance(closedAccount, validPassword);

            Assert.Equal(-1, balance);
        }

        [Fact]
        public void GetBalance_ShouldReturnBalanceOnSuccess()
        {
            double balance = bank.GetBalance(account1, validPassword);

            Assert.Equal(amount, balance);
        }

        [Fact]
        public void Deposit_FailsForInvalidAmount()
        {
            var status = bank.Deposit(account1, -1);

            Assert.Equal(Status.INVALID_AMOUNT, status);

        }

        [Fact]
        public void Deposit_OnSuccessUpdatesTheBalance()
        {
            var status = bank.Deposit(account1, 1);

            Assert.Equal(Status.SUCCESS, status);
            Assert.Equal(amount + 1, bank.GetBalance(account1,validPassword));
        }

        [Fact]
        public void CreditInterestCreditsOneMonthInterestToAllAccounts()
        {
            var newBalance = amount + amount * rate / 1200;

            bank.CreditInterest();

            Assert.Equal(newBalance, bank.GetBalance(account1, validPassword));
            Assert.Equal(newBalance, bank.GetBalance(account3, validPassword));
        }
    }
}
