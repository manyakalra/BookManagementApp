using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ConceptArchitect.Finance.Core.V2.Specs
{
    public  class OverdraftAccountSpecs
    {
        string password = "p@ssword";
        double amount = 20000;
        double minBalance = 5000;
        OverdraftAccount account;

        public OverdraftAccountSpecs()
        {
            account = new OverdraftAccount(1, "Name", password, amount);
        }
        private void AssertFailed()
        {
            Assert.True(false, "NOT Yet Implemented");
        }

        [Fact]
        public void OverdraftAccount_HasOdLimitSetTo10PCOfInitialBalance()
        {
            Assert.Equal(amount / 10, account.OdLimit,2);
        }

        [Fact]
        public void OdLimit_IncreasesDepositCrossingOnHistoricMaxBalance()
        {
            //Act
            int newDeposit = 10000;
            var newExpectedOdLimit = (amount + newDeposit) / 10;
            account.Deposit(newDeposit); //we have new historic max balanace

            //Assert
            Assert.Equal(newExpectedOdLimit, account.OdLimit,2);
            
        }


        [Fact]
        public void OdLimit_IncreasesONCreditInterestOnCrossingOnHistoricMaxBalance()
        {
            //Act
            account.CreditInterest(12);
            var newBalance = account.Balance;
            var expectedNewOdLimit = newBalance / 10;

            //Assert
            Assert.Equal(expectedNewOdLimit, account.OdLimit, 2);
        }


        [Fact]
        public void OdLimit_DoesntChangeWhenBalanceFallsLow()
        {
            //Arrange
            var originalOdLimit = account.OdLimit;

            //Act
            account.Withdraw(1000, password);
            //Precondition Test
            Assert.Equal(amount - 1000, account.Balance);


            //Assert
            Assert.Equal(originalOdLimit, account.OdLimit, 2);


        }


        [Fact]
        public void OdLimit_DoesntChangeOnDepositIfItDoesntCrossMaxHistroicBalance()
        {
            //Arrange ---> increase the balance to histroric max balance
            var newDeposit = 10000;
            account.Deposit(amount);  //Now balance is histroic max : amount+newDeposit
            var expectedOdLimit = account.OdLimit;
            var historicMaxBalance = account.Balance;
            account.Withdraw(newDeposit, password); //balance is reduced

            //ACT
            account.Deposit(newDeposit / 2);  //balance increases but not upto Histroic Max Balance


            //ACT

            Assert.True(historicMaxBalance > account.Balance);

            Assert.Equal(expectedOdLimit, account.OdLimit,2);

        }

        [Fact]
        public void OdLimit_DoesntChangeOnCreditInterstIfItDoesntCrossMaxHistroicBalance()
        {
            //Arrange
            var odLimitAtHistoricMaxBalance = account.OdLimit;
            account.Withdraw(amount / 2, password); //50% balance reduced

            account.CreditInterest(12);  //12% balance increased. doesn't reach Histroic Max Balance


            Assert.Equal(odLimitAtHistoricMaxBalance, account.OdLimit, 2);
            
        }

        [Fact]
        public void Withdraw_CanWithdrawUptoBalancePlusOdLimit()
        {
            account.Withdraw(amount + account.OdLimit, password);

            //if you reach here. Test passed.
        }

        [Fact]
        public void Withdraw_FailsForAmountGreaterThanBalancePlusOdLimit()
        {
            Assert.Throws<InsufficientBalanceException>(() => account.Withdraw(account.SufficientBalance +1, password));
        }

        [Fact]
        public void Withdraw_OverdraftAttracts10PcOdFee()
        {
            
            var odLimit = account.OdLimit;
            var od = odLimit / 2;
            var odFee = od / 10;

            var withdrawAmount = amount + od; //this is what I will withdraw
            var expectedNewBalance = -od - odFee;

            account.Withdraw(withdrawAmount, password);

            Assert.Equal(expectedNewBalance, account.Balance, 2);


        }

    }
}
