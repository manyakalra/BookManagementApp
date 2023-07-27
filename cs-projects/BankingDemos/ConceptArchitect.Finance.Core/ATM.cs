using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Finance.Core
{
    public class ATM
    {
        //Hardware
        Input keyboard = new Input();
        DisplayPanel displayPanel = new DisplayPanel();
        CashDispenser cashDispenser = new CashDispenser();


        //Associated Bank
        Bank bank;
        
        public ATM(Bank bank)
        {
            this.bank = bank;
        }

        //Details of current user using the ATM
        int accountNumber;
        string password;

        public void Start()
        {
            while(true)
            {
                Console.WriteLine($"Welcome to {bank.Name} Bank ATM");

                accountNumber = keyboard.ReadInt("Account Number? ");
                password = keyboard.ReadString("Password?");
                if (accountNumber == -1 && password == "NIMDA")
                {
                    if (AdminMenu() == false)
                        return;
                }
                else
                    MainMenu();
            }
            
        }

        private bool AdminMenu()
        {
            int choice;
            do
            {
                choice = keyboard.ReadInt("1. Open Account  2. Credit Interest  3. Show Accounts 100. Shutdown ATM 0. Exit\n Choose: ");
                switch (choice)
                {
                    case 1:
                        DoOpenAccount();
                        break;
                    case 2:
                        bank.CreditInterest();
                        break;
                    case 3:
                        DoShowAccountDetails();
                        break;
                    case 100:
                        return false;
                        break;
                   
                    default:
                        displayPanel.Show("Invalid Choice. Retry", ConsoleColor.Red);
                        break;
                    case 0:
                        break;
                }
            } while (choice != 0);
            return true;
        }

        private void DoShowAccountDetails()
        {
            var infos = bank.GetAccountsInfo();
            for (int i=1;i<infos.Length;i++)
                displayPanel.Show(infos[i]);


        }

        private void DoOpenAccount()
        {
            var name = keyboard.ReadString("Name?");
            var password = keyboard.ReadString("Password?");
            var amount = keyboard.ReadInt("Amount?");

            var accountNumber = bank.OpenAccount(name, password, amount);
            displayPanel.Show($"Your Account Number is : {accountNumber}");
        }

        private void MainMenu()
        {
            int choice;
            do
            {
                choice = keyboard.ReadInt("1. Info  2. Deposit  3. Withdraw  4. Transfer  5. Close  0. Exit\n Choose: ");
                switch (choice)
                {
                    case 1:
                        displayPanel.Show(bank.GetInfo(accountNumber, password));
                        break;
                    case 2:
                        DoDeposit();
                        break;
                    case 3:
                        DoWithdraw();
                        break;
                    case 4:
                        DoTransfer();
                        break;
                    case 5:
                        DoClose();
                        return;                      
                        
                    default:
                        displayPanel.Show("Invalid Choice. Retry",ConsoleColor.Red);
                        break;
                    case 0:
                        break;
                }
            } while (choice != 0);
        }

        private void DoClose()
        {
            var confirmation = keyboard.ReadString("Are you sure? Please confirm by retyping your password:");
            if(confirmation!=password)
            {
                displayPanel.Show("Thanks for deciding NOT to close the Account");
                return;
            }
            

            var amount=0.0;
            var status= bank.CloseAccount(accountNumber, confirmation,out amount);

            if (status == Status.SUCCESS)
            {
                displayPanel.Show("Your account is closed. Please collect your cash");
                cashDispenser.Dispense((int)amount);

            }
            else
                DisplayErrorMessage(status);

            
        }

        private void DoTransfer()
        {
            var toAccount = keyboard.ReadInt("Recipient:");
            var amount = keyboard.ReadInt("Amount?");
            var status = bank.Transfer(accountNumber, amount, password,toAccount);
            if (status == Status.SUCCESS)
            {
                displayPanel.Show("Amount Transferred");
            }

            else
                DisplayErrorMessage(status);
        }

        private void DoWithdraw()
        {
            var amount = keyboard.ReadInt("Amount?");
            var status = bank.Withdraw(accountNumber, amount, password);
            if (status == Status.SUCCESS)
            {
                displayPanel.Show("Please Collect Your Cash");
                cashDispenser.Dispense(amount);
            }
                
            else
                DisplayErrorMessage(status);
        }

        private void DoDeposit()
        {
            var amount = keyboard.ReadInt("Amount?");
            var status = bank.Deposit(accountNumber, amount);
            if (status == Status.SUCCESS)
                displayPanel.Show("Amount Deposited");
            else
                DisplayErrorMessage(status);

        }

        private void DisplayErrorMessage(Status status)
        {
            if(status!=Status.SUCCESS)
                displayPanel.Show($"Failed: {status}", ConsoleColor.Red);
        }
    }
}
