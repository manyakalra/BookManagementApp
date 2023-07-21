using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchictect.Finance
{
    public enum Status
    {
        SUCCESS, //=0
        INVALID_CREDENTIALS, //=1
        INSUFFICIENT_BALANCE, //=2
        INVALID_AMOUNT //=3
    }

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
            //SetPassword(password);
            Password = password; //calls Password set
            balance = amount;
            this.interestRate = interestRate;

        }

        public bool Deposit(double amount)
        {
            if (amount >0)
            {
                balance += amount;
                return true;

            }
            else
            {
                // Console.WriteLine("Invalid Amount");
                return false;
            }
            
        }

        public Status Withdraw(double amount, string password)
        {
            if (amount < 0)
            {
                return Status.INVALID_AMOUNT;
            } 
            else if(amount> balance)
            {
                return Status.INSUFFICIENT_BALANCE;
            }
            else if(!Authenticate(password))
            {
                return Status.INVALID_CREDENTIALS;
            }
            else
            {
                balance -= amount;
                return Status.SUCCESS;
            }
        }

        public void CreditInterest()
        {
            balance += balance * interestRate / 1200;
            
        }

        public string GetInfo()
        {
            return string.Format("Account Number ={0}\tName={1}\tBalance={2}\tInterestRate={3}",
                accountNumber,
                name,
                balance,
                interestRate); //password not shown
        }

        public int AccountNumber
        {
            get{return accountNumber;}
        }

        public string Name
        {
            get { return name; }
            set //(string value)
            {
                if (LastName(name) == LastName(value))
                {
                    name = value;
                }
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

        public double Balance 
        { 
            get 
            { 
                return balance; 
            }
        }

        //Can't set the Balance
        //public void SetBalance(double newBalance) { balance = newBalance; }


        public double InterestRate
        {
            get { return interestRate; }
            set { interestRate = value; }
        }


        //public string GetPassword() { return password; }    
        private string Password
        {
            set
            {
                Encryptor encryptor = new Encryptor();
                this.password = encryptor.Encrypt(value);
            }            
        }

        public bool Authenticate(string password)
        {
            Encryptor matcher = new Encryptor();

            return  matcher.Match(this.password, password);
        }

        public void  ChangePassword(string confirmPassword, string newPassword)
        {
            if (Authenticate(confirmPassword) && newPassword.Length>5 && newPassword.Length<10)
            {
                Password = newPassword;
            }
        }

    }
}
