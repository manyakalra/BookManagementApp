using ConceptArchictect.Finance;
using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App02
{
    internal class Program
    {
        
        private static void TestMain()
        {
            string password = "pass#1";
            int amount = 2000;
            var interestRate = 12.1;
            var originalFirstName = "Sanjay";
            var originalLastName = "Mall";
            var originalName=originalFirstName+" " + originalLastName;

            var account = new BankAccount(1, originalName, password, amount, interestRate);

            TestDeposit(account, -1, false, "Should reject negative deposit");
            TestDeposit(account, 1, true, "Should allow positive deposit");

            string newPassword = "newPass";
            TestChangePassword(account, password, newPassword, true, "Password changes after validating old password");
            TestChangePassword(account, "wrong password", newPassword, false, "Password changes are rejected if authentication fails for current password");


            TestWithdraw(account, -1,  password, Status.INVALID_AMOUNT, "Negative Withdrawal not allowed");
            TestWithdraw(account, amount + 1, password, Status.INSUFFICIENT_BALANCE, "Over Withdrawal not allowed");
            TestWithdraw(account, amount - 1, "wrong password", Status.INVALID_CREDENTIALS, "Withdrawal fails for invalid password");
            TestWithdraw(account, amount - 1, password, Status.SUCCESS, "Withdrawal succeeds for happy path");

           
            TestNameChange(account, originalFirstName+" NewLastName", originalName, "Last Name change not allowed");
            
            var newName = "Sanjeev " + originalLastName;
            TestNameChange(account, newName , newName, "First Name change is allowed");            
        }

        private static void TestChangePassword(BankAccount account, string challengePassword, string newPassword, bool expectedResult, string testDescription)
        {
            account.ChangePassword(challengePassword, newPassword);

            TestReporter.Report(testDescription, expectedResult.ToString(), account.Authenticate(newPassword).ToString());
               
        }

        private static void TestWithdraw(BankAccount account, int amount, string password, Status expectedResult, string testDescription)
        {
            var actualResult = account.Withdraw(amount, password);

            TestReporter.Report(testDescription, expectedResult.ToString(), actualResult.ToString());
        }

        private static void TestDeposit(BankAccount account, int amount, bool expectedResult, string testDescription)
        {
          
            var actualResult = account.Deposit(amount);
            TestReporter.Report(testDescription, expectedResult.ToString(), actualResult.ToString());

            Console.WriteLine();          
           
        }

        public static void TestNameChange(BankAccount account, string newName, string expectedResult, string testDescription)
        {
            account.Name= newName;

            TestReporter.Report(testDescription, expectedResult, account.Name);

            Console.WriteLine();
        }



        static void Main()
        {
            TestMain();
        }

        
        static void AppMain(string[] args)
        {
            String password = "pass#1";
            String newPassword = "pass#2";
            Input input = new Input();
            BankAccount a1 = new BankAccount(
                1, "Vivek", "pass#1", 50000, 12
                );

            int choice;
            do
            {
                choice = input.ReadInt("1. Deposit\t2.Withdraw\t3.View\t0. Exit\nchoose:");
                double amount;
                switch (choice)
                {
                    case 1:
                        amount = input.ReadInt("Amount?");
                        if (a1.Deposit(amount))
                        {
                            Console.WriteLine("Amount Deposited");
                        }
                        else
                        {
                            Console.WriteLine("Amount Deposit Failed");
                        }
                        break;
                    case 2:
                        amount = input.ReadInt("Amount?");
                        password = input.ReadString("Password?");
                        if (a1.Withdraw(amount, password)==Status.SUCCESS)
                        {
                            Console.WriteLine("Please collect your cash");
                            
                        }
                        else
                        {
                            Console.WriteLine("Failed to Withdraw");
                        }
                        break;
                    case 3:
                        //a1.Show();
                        Console.WriteLine(a1.GetInfo());
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Retry");
                        break;


                }
                Console.WriteLine();
            } while (choice != 0);
            

           
        }
    }
}
