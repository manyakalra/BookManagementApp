using ConceptArchictect.Finance;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountTests
{
    [TestClass]
    public class BankAccountTests
    {
        string name ;
        string firstName = "Sanjay";
        string lastName = "Mall";
        int accountNumber = 1;
        int balance = 20000;
        string validPassword = "p@ss";
        double interestRate = 12;
        BankAccount account;

        //Arrange
        [TestInitialize]
        public void Setup()
        {
             name = firstName+" " + lastName;
             account = new BankAccount( name, validPassword, balance);
             
        }


        [TestMethod]
        public void Deposit_ShouldFailForNegativeAmount()
        {
            
            var result = account.Deposit(-1);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Deposit_ShouldSucceedInHappyPath()
        {
            //Arrange

            //Act
            var result = account.Deposit(1);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        
        public void Withdraw_ShouldFailForNegativeAmount()
        {
            //Act
            var result = account.Withdraw(-1, validPassword);

            //Assert
            Assert.AreEqual(Status.INVALID_AMOUNT, result);
        }


        [TestMethod]
        public void Withdraw_ShouldFailForInvalidCredentials()
        {
            //Arrange
            var result = account.Withdraw(1, "wrong password");

            //Assert
            Assert.AreEqual(Status.INVALID_CREDENTIALS, result);
        }

        [TestMethod]
        public void Withdraw_ShouldFailForInsufficientBalance()
        {
            var result= account.Withdraw(balance+1, validPassword);

            Assert.AreEqual(Status.INSUFFICIENT_BALANCE, result);
        }
        
        [TestMethod()]
        [Ignore]
        public void AllWithdrawTests()
        {

            var result = account.Withdraw(balance, validPassword);
            Assert.AreEqual(Status.SUCCESS, result);
            Assert.AreEqual(0, account.Balance);

             result=account.Withdraw(-1, validPassword);
            Assert.AreEqual(Status.INVALID_AMOUNT, result);

            result = account.Withdraw(1, "wrong-password");
            Assert.AreEqual(Status.INVALID_CREDENTIALS, result);

            result = account.Withdraw(balance+1, validPassword);
            Assert.AreEqual(Status.INSUFFICIENT_BALANCE, result);

           

        }


        [TestMethod]
        public void Withdraw_ShouldSuccedForValidPasswordAndAmount()
        {
            var result=account.Withdraw(balance-1, validPassword);

            Assert.AreEqual(Status.SUCCESS, result);
            Assert.AreEqual(1, account.Balance);
        }

        [TestMethod]
        public void Name_ChangeIsRejectedForDifferentLastName()
        {
            //Arrange
            var newName = firstName + " Different";

            //Act
            account.Name = newName;

            //Assert
            Assert.AreEqual(name, account.Name); //Name remains unchanged

        }

        [TestMethod]
        public void Name_ChangeIsAcceptedWithSameLastName()
        {
            var newName = "Different " + lastName;

            account.Name = newName;

            Assert.AreEqual(newName, account.Name);
        }

        [TestMethod]
        public void Authenticate_ShouldReturnTrueForValidPassword()
        {
            Assert.IsTrue(account.Authenticate(validPassword));
        }

        [TestMethod]
        public void Authenticate_ShouldReturnFalseForInvalidPassword()
        {
            Assert.IsFalse(account.Authenticate("wrong-password"));
        }

        [TestMethod]
        public void ChangePassword_FailsForInvalidCurrentPassword()
        {
            var newPassword = "new-password";
            account.ChangePassword("wrong-password", newPassword);
            
            Assert.IsFalse( account.Authenticate(newPassword) );
        }

        [TestMethod]
        public void ChangePassword_SucceedsForValidCurrentPassword()
        {
            var newPassword = "new-pass";
            account.ChangePassword(validPassword, newPassword);

            Assert.IsTrue( account.Authenticate(newPassword) );
        }

        [TestMethod]
        public void Change_PasswordFailsForNewPasswordSizeLessThan5()
        {
            var newPassword = "Hi"; //less than 5

            account.ChangePassword(validPassword, newPassword);

            Assert.IsFalse ( account.Authenticate(newPassword) );
        }

        [TestMethod]
        public void Change_PasswordFailsForNewPasswordSizeLessGreaterThan10()
        {
            var newPassword = "You Password shoudle be Big"; //> 10

            account.ChangePassword(validPassword, newPassword);

            Assert.IsFalse(account.Authenticate(newPassword));
        }

        [TestMethod]
        public void CreditIneterst_ShouldCreditOneMonthsInterest()
        {
            //Arrange
            var expectedNewBalance = balance + balance * interestRate / 1200;
            //Act
            account.CreditInterest();

            //Assert
            Assert.AreEqual(expectedNewBalance, account.Balance,0.001);
        }

        [TestMethod]
        public void TestADoubleEquals()
        {
            var result = 10.0 / 3; //3.33333

            Assert.AreEqual(3.333, result,0.001);
        }


        [TestMethod]
        public void Show_ShouldNotIncludePassword()
        {
            var output = account.GetInfo();

            Assert.IsFalse(output.Contains("Password"));
        }


        [TestMethod]
        public void Show_ShouldIncludeBalance()
        {
            var output = account.GetInfo();

            Assert.IsTrue(output.Contains(account.Balance.ToString()));
        }

        [TestMethod]
        public void InterestRate_EachNewObjectGetsSameInterestRate()
        {
            var account2= new BankAccount("New Account",validPassword, balance);

            Assert.AreEqual( account.AccountInterestRate, account2.AccountInterestRate);
        }

        [TestMethod]
        public void InerestRate_ChangedByOneObjectChangesForOtherObjects()
        {
            var account2=new BankAccount( "New Account", validPassword, balance);

            BankAccount.InterestRate += 1;

            Assert.AreEqual(account.AccountInterestRate, account2.AccountInterestRate);

        }

        [TestMethod]
        public void AccountsNumberIsAllocatedInAscendingSequnence()
        {
            //Arrange
            var lastAccountNumber = account.AccountNumber;

            for(int i = 1; i <= 10; i++)
            {
                //Act
                var newAccount = new BankAccount("Name", validPassword, balance);
                //Assert
                Assert.AreEqual(lastAccountNumber + i, newAccount.AccountNumber);
            }



        }
    }
}
