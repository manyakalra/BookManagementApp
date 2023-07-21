using App01;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountTests
{
    [TestClass]
    public class App1BankAccountTests
    {
        string name;
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
            name = firstName + " " + lastName;
            account = new BankAccount(accountNumber, name, validPassword, balance, interestRate);
        }

        [TestMethod]
        public void Withdraw_FailsForInvalidPassword()
        {
            account.Withdraw(1, "wrong password");

            Assert.AreEqual(balance, account.GetBalance());
        }

        [TestMethod]
        public void Withdraw_SucceedsInHappyPath()
        {
            account.Withdraw(balance - 1, validPassword);

            Assert.AreEqual(1, account.GetBalance());
        }
    }
}
