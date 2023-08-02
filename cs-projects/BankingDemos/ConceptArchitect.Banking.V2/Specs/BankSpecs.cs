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

        int account1,account2, account3, closedAccount;
        int savingsAccount, currentAccount, overDraftAccount;

        public BankSpecs()
        {
            bank = new Bank(bankName, rate);
            
            account1 = bank.OpenAccount("savings","Sanjay Mall", validPassword, amount);
            account2 = bank.OpenAccount("current","Amit Singh", validPassword, amount);
            closedAccount = bank.OpenAccount("current", "Amit Singh", validPassword, amount);
            account3 = bank.OpenAccount("overdraft","Prabhat Singh", validPassword, amount);

            savingsAccount = account1;
            currentAccount = account2;
            overDraftAccount = account3;

            bank.CloseAccount(closedAccount, validPassword);
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
            bank.OpenAccount("savings",name, validPassword, amount);
        }

        [Fact]
        public void OpenAccountShouldHaveAccountNumberInIncreasingSequence()
        {
            int first = bank.OpenAccount("savings", "First", validPassword, amount);

            for(int i = 1;i<=3; i++)
            {
                int newAccount = bank.OpenAccount("savings", "New Account", "p@ssword", 20000);
                Assert.Equal(first+i, newAccount);
            }
        }

        [Fact]
        public void CloseAccountShouldFailForInvalidAccountNumber()
        {
            Assert.Throws<InvalidAccountException>(()=> bank.CloseAccount(-1,validPassword));

        }

        [Fact]
        public void CloseAccountShouldFailForInvalidPassword()
        {
          
            //Act
            try
            {
                bank.CloseAccount(account1, "wrong password");

                //We shouldn't have reached here
                AssertFail($"Excpected Exception 'InvalidCredentialsException' wasn't thrown");
            }
            catch(InvalidCredentialsException ex)
            {
                //We Passed!!!
            }
            

            
        }

        [Fact]
        public void CloseAccountShouldFailForAlreadyClosedAccount()
        {
            

            //ACT + Assert
            Assert.Throws<InvalidAccountException>(()=> bank.CloseAccount(closedAccount, validPassword));

        }

        [Fact()]

        public void CloseAccountShouldFailForBalanceBelowZero()
        {
            //Arrange
            bank.Withdraw(overDraftAccount, amount + 1, validPassword);

            //ACT
            Assert.Throws<InsufficientBalanceException>(()=> bank.CloseAccount(overDraftAccount, validPassword));

        }


        [Fact]
        public void CloseAccountOnSuccessShouldReturnTheRemainingBalance()
        {
           

            //ACT
            double balance= bank.CloseAccount(account1,validPassword);

            //Assert
            Assert.Equal(amount, balance);
        }

        [Fact]
        public void Deposit_FailsForInvalidAccountNumber()
        {
            int accountNumber = -1;
            Assert.Throws<InvalidAccountException>(()=> bank.Deposit(accountNumber, amount));

            
            
        }

        [Fact]
        public void Deposit_FailsForClosedAccount()
        {

            Assert.Throws<InvalidAccountException>(()=> bank.Deposit(closedAccount, 1));
            
        }

        [Fact]
        public void GetBalance_FailsForInvalidAccountNumber()
        {
            
            Assert.Throws<InvalidAccountException>(()=> bank.GetBalance(-1, validPassword));

        }

        [Fact]
        public void GetBalance_FailsForInvalidPassword()
        {
            
            Assert.Throws<InvalidCredentialsException>(()=> bank.GetBalance(account1, "invalid password"));           

            
        }

        [Fact]
        public void GetBalance_FailsForClosedAccountNumber()
        {
            Assert.Throws<InvalidAccountException>(()=> bank.GetBalance(closedAccount, validPassword));

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
            Assert.Throws<InvalidDenominationException>(()=> bank.Deposit(account1, -1));

            AssertBalanceUnchanged(account1);

        }

        [Fact]
        public void Deposit_OnSuccessUpdatesTheBalance()
        {
            bank.Deposit(account1, 1);

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
            Assert.Throws<InvalidAccountException>(()=> bank.Withdraw(100, 1, validPassword));
        }
        [Fact]
        public void WithdrawFailsForClosedAccountNumber()
        {
            Assert.Throws<InvalidAccountException>(()=> bank.Withdraw(closedAccount, 1, validPassword));
        }

        [Fact]
        public void WithdrawFailsForInvalidCredentials()
        {
            Assert.Throws<InvalidCredentialsException>(()=> bank.Withdraw(account1, 1, "invalid password"));

            AssertBalanceUnchanged(account1);
        }

        [Fact]
        public void WithdrawFailsForInvalidAmount()
        {
            Assert.Throws<InvalidDenominationException>(()=> bank.Withdraw(account1, -1, validPassword));
            AssertBalanceUnchanged(account1);

        }

        [Fact]
        public void WithdrawFailsForInsufficientBalance()
        {
            Assert.Throws<InsufficientBalanceException>(()=> bank.Withdraw(account1, amount+1, validPassword));
            AssertBalanceUnchanged(account1);
        }

        [Fact]
        public void WithdrawUpdatesBalanceOnSuccess()
        {
            bank.Withdraw(currentAccount, amount - 1, validPassword);
            AssertBalance(currentAccount, 1);
        }



        [Fact]
        public void TransferFailsForInvalidSourceAccountNumber()
        {
            
            Assert.Throws<InvalidAccountException>(()=> bank.Transfer(-1, amount, validPassword, account1));

            AssertBalanceUnchanged(account1);

        }
        [Fact]
        public void TransferFailsForClosedSourceAccountNumber()
        {
            Assert.Throws<InvalidAccountException>(() => bank.Transfer(closedAccount, amount, validPassword, account1));
            
            AssertBalanceUnchanged(account1);
        }

        [Fact]
        public void TransferFailsForInvalidTargetAccountNumber()
        {
            Assert.Throws<InvalidAccountException>(() => bank.Transfer(account1, amount, validPassword, 1000));
            AssertBalanceUnchanged(account1);
        }
        [Fact]
        public void TransferFailsForClosedTargetAccountNumber()
        {
            Assert.Throws<InvalidAccountException>(() => bank.Transfer(account1, amount, validPassword, closedAccount));
            AssertBalanceUnchanged(account1); 
        }

        [Fact]
        public void TransferFailsForInvalidCredentials()
        {
            Assert.Throws<InvalidCredentialsException>(() => bank.Transfer(account1, amount, "invalid password", account3));
            AssertBalanceUnchanged(account1);
            AssertBalanceUnchanged(account3);
        }

        [Fact]
        public void TransferFailsForInvalidAmount()
        {
            Assert.Throws<InvalidDenominationException>(() => bank.Transfer(account1, -1,validPassword, account3));
            
            AssertBalanceUnchanged(account1);
            AssertBalanceUnchanged(account3);
        }

        [Fact]
        public void TransferFailsForInsufficientBalance()
        {


            Assert.Throws<InsufficientBalanceException>(() => bank.Transfer(account1, amount+1, validPassword, account3));
            AssertBalanceUnchanged(account1);
            AssertBalanceUnchanged(account3);
            
        }

        [Fact]
        public void TransferSUpdatesBalancesOnSuccess()
        {
            bank.Transfer(account1,  1, validPassword, account3);
            AssertBalance(account1, amount-1);
            AssertBalance(account3, amount+1);
        }


        [Fact]
        public void GetInfoFailsForInvalidCredentials()
        {

            Assert.Throws<InvalidCredentialsException>(() => bank.GetInfo(account1, "invalid password"));
        }

        [Fact]
        public void GetInfoFailsForInvalidAccountNumber()
        {
            Assert.Throws<InvalidAccountException>(() => bank.GetInfo(-1, validPassword));
        }


        [Fact]
        public void GetInfoReturnsInfoAboutValidAccountOnSuccess()
        {
            var data = bank.GetInfo(account1, validPassword);
            Assert.Contains($"Account Number={account1}", data);
        }


        [Fact]
        public void AuthenticationFailsReturnsInvalidAttemptCount()
        {
            var ex = Assert.Throws<InvalidCredentialsException>(()=>bank.GetInfo(account1, "invalid-password"));

            Assert.Equal(1, ex.InvalidAttempts);
        }

        [Fact]
        public void AuthenticationWhenFailedIncreasesInvalidAttemptCount()
        {
            for(int i=1;i<=5;i++)
            {
                var ex = Assert.Throws<InvalidCredentialsException>(() => bank.GetInfo(account1, "invalid-password"));
                Assert.Equal(i, ex.InvalidAttempts);
            }
        }


        [Fact]
        public void AuthenticationSuccessResetsInvalidAttemptCount()
        {
            //Arrange
            Assert.Throws<InvalidCredentialsException>(() => bank.GetInfo(account1, "invalid-password"));
            var ex = Assert.Throws<InvalidCredentialsException>(() => bank.GetInfo(account1, "invalid-password"));
            Assert.Equal(2, ex.InvalidAttempts); //pre condition assert

            //Act
            bank.GetInfo(account1, validPassword); //this should reset invalid attempt count 0

            ex = Assert.Throws<InvalidCredentialsException>(() => bank.GetInfo(account1, "invalid-password")); //this should set it to 1


            //Assert
            Assert.Equal(1,ex.InvalidAttempts);


        }

        [Fact]
        public void WithdrawFailingForInsufficientBalanceIncludesDeficitInErrorMessage()
        {
            var ex = Assert.Throws<InsufficientBalanceException>(() => bank.Withdraw(account1, amount + 1, validPassword));

            Assert.Equal(1, ex.Deficit);
        }

    }
}
