using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App01
{
    public class BankAccount
    {
        int accountNumber;
        string name;
        string password;
        double balance;
        double interestRate;

        public BankAccount(int accountNumber, string name, string password, double amount, double interestRate)
        {
            this.accountNumber = accountNumber;
            this.name = name;
            //this.password = password;
            SetPassword(password);
            balance = amount;
            this.interestRate = interestRate;

        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine("Amount Deposited");
            }
            else
            {
                Console.WriteLine("Invalid Amount");
            }
            
        }

        public void Withdraw(double amount, string password)
        {
            if (amount < 0)
            {
                Console.WriteLine("Invalid Amount");
            } 
            else if(amount> balance)
            {
                Console.WriteLine("Insufficient Balance");
            }
            else if(this.password!=password)
            {
                Console.WriteLine("Invalid Credentials");
            }
            else
            {
                balance -= amount;
                Console.WriteLine("Please collect your cash");
            }
        }

        public void CreditInterest()
        {
            balance += balance * interestRate / 1200;
            Console.WriteLine("Inerest Credited");
        }

        public void Show()
        {
            Console.WriteLine("Account Number ={0}\tName={1}\tBalance={2}\tInterestRate={3}",
                accountNumber,
                name,
                balance,
                interestRate); //password not shown
        }

        public int GetAccountNumber()
        {
            return accountNumber;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string newName)
        {
            if (LastName(name) == LastName(newName))
            {
                name = newName;
            }
        }

        private string LastName(string name)
        {
            int index = name.LastIndexOf(' ');
            if (index == -1)
                return "";
            else
                return name.Substring(index + 1);
        }

        public double GetBalance() { return balance; }

        //Can't set the Balance
        //public void SetBalance(double newBalance) { balance = newBalance; }


        public double GetInterestRate() { return interestRate; }
        public void SetInterestRate(double rate) { interestRate = rate; }


        //public string GetPassword() { return password; }    
        private void SetPassword(string password) 
        {
            Encryptor encryptor = new Encryptor();
            this.password = encryptor.Encrypt(password); 
        }

        public bool Authenticate(string password)
        {
            Encryptor matcher = new Encryptor();

            return matcher.Match(this.password, password);
        }

        public void ChangePassword(string confirmPassword, string newPassword)
        {
            if(Authenticate(confirmPassword))   
                SetPassword(newPassword);
        }

    }
}
