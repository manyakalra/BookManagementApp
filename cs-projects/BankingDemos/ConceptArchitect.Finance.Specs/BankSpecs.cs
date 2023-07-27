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

        private void AssertBalance(int accountNumber, double expectedBalance)
        {
            Assert.Equal(expectedBalance, bank.GetBalance(accountNumber, validPassword));
        }

        private void AssertBalanceUnchanged(int accountNumber)
        {
            AssertBalance(accountNumber, amount);
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
            AssertBalanceUnchanged(account1);

        }

        [Fact]
        public void Deposit_OnSuccessUpdatesTheBalance()
        {
            var status = bank.Deposit(account1, 1);

            Assert.Equal(Status.SUCCESS, status);
            //Assert.Equal(amount + 1, bank.GetBalance(account1,validPassword));
            AssertBalance(account1, amount + 1);

        }

        [Fact]
        public void CreditInterestCreditsOneMonthInterestToAllAccounts()
        {
            var newBalance = amount + amount * rate / 1200;

            bank.CreditInterest();

            //Assert.Equal(newBalance, bank.GetBalance(account1, validPassword));
            //Assert.Equal(newBalance, bank.GetBalance(account3, validPassword));

            AssertBalance(account1, newBalance);
            AssertBalance(account3, newBalance);
        }


        [Fact]
        public void WithdrawFailsForInvalidAccountNumber()
        {
            Status status = bank.Withdraw(100, 1, validPassword);
            Assert.Equal(Status.INVALID_ACCOUNT_NUMBER, status);
        }
        [Fact]
        public void WithdrawFailsForClosedAccountNumber()
        {
            var status = bank.Withdraw(closedAccount, 1, validPassword);
            Assert.Equal(Status.INVALID_ACCOUNT_NUMBER, status);
        }

        [Fact]
        public void WithdrawFailsForInvalidCredentials()
        {
            var status = bank.Withdraw(account1, 1, "invalid password");

            Assert.Equal(Status.INVALID_CREDENTIALS, status);
            AssertBalanceUnchanged(account1);
        }

        [Fact]
        public void WithdrawFailsForInvalidAmount()
        {
            var status = bank.Withdraw(account1, -1, validPassword);
            Assert.Equal(Status.INVALID_AMOUNT, status);
            AssertBalanceUnchanged(account1);

        }

        [Fact]
        public void WithdrawFailsForInsufficientBalance()
        {
            var status = bank.Withdraw(account1, amount+1, validPassword);
            Assert.Equal(Status.INSUFFICIENT_BALANCE, status);
            AssertBalanceUnchanged(account1);
        }

        [Fact]
        public void WithdrawUpdatesBalanceOnSuccess()
        {
            var status = bank.Withdraw(account1, amount - 1, validPassword);
            Assert.Equal(Status.SUCCESS, status);
            AssertBalance(account1, 1);
        }



        [Fact]
        public void TransferFailsForInvalidSourceAccountNumber()
        {
            
            Status status = bank.Transfer(-1, amount, validPassword, account1);
            Assert.Equal(Status.INVALID_ACCOUNT_NUMBER, status);
            AssertBalanceUnchanged(account1);

        }
        [Fact]
        public void TransferFailsForClosedSourceAccountNumber()
        {
            Status status = bank.Transfer(closedAccount, amount, validPassword, account1);
            Assert.Equal(Status.INVALID_ACCOUNT_NUMBER, status);
            AssertBalanceUnchanged(account1);
        }

        [Fact]
        public void TransferFailsForInvalidTargetAccountNumber()
        {
            Status status = bank.Transfer(account1, amount, validPassword, 1000);
            Assert.Equal(Status.INVALID_ACCOUNT_NUMBER, status);
            AssertBalanceUnchanged(account1);
        }
        [Fact]
        public void TransferFailsForClosedTargetAccountNumber()
        {
            Status status = bank.Transfer(account1, amount, validPassword, closedAccount);
            Assert.Equal(Status.INVALID_ACCOUNT_NUMBER, status);
            AssertBalanceUnchanged(account1); 
        }

        [Fact]
        public void TransferFailsForInvalidCredentials()
        {
            Status status = bank.Transfer(account1, amount, "invalid password", account3);
            Assert.Equal(Status.INVALID_CREDENTIALS, status);
            AssertBalanceUnchanged(account1);
            AssertBalanceUnchanged(account3);
        }

        [Fact]
        public void TransferFailsForInvalidAmount()
        {
            Status status = bank.Transfer(account1, -1,validPassword, account3);
            Assert.Equal(Status.INVALID_AMOUNT, status);
            AssertBalanceUnchanged(account1);
            AssertBalanceUnchanged(account3);
        }

        [Fact]
        public void TransferFailsForInsufficientBalance()
        {
            Status status = bank.Transfer(account1, amount+1, validPassword, account3);
            Assert.Equal(Status.INSUFFICIENT_BALANCE, status);
            AssertBalanceUnchanged(account1);
            AssertBalanceUnchanged(account3);
        }

        [Fact]
        public void TransferSUpdatesBalancesOnSuccess()
        {
            Status status = bank.Transfer(account1,  1, validPassword, account3);
            Assert.Equal(Status.SUCCESS, status);
            AssertBalance(account1, amount-1);
            AssertBalance(account3, amount+1);
        }


        [Fact]
        public void GetInfoFailsForInvalidCredentials()
        {
            Assert.Null(bank.GetInfo(account1, "invalid password"));
        }

        [Fact]
        public void GetInfoFailsForInvalidAccountNumber()
        {
            Assert.Null(bank.GetInfo(-1, "invalid password"));
        }


        [Fact]
        public void GetInfoReturnsInfoAboutValidAccountOnSuccess()
        {
            var data = bank.GetInfo(account1, validPassword);

            Assert.NotNull(data);
            Assert.Contains($"Account Number={account1}", data);
        }

    }
}
