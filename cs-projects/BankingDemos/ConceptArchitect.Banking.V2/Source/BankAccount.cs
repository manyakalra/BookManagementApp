using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Finance.Core
{
   

    public class BankAccount
    {
        int accountNumber;
        string name;
        string password;
        double balance;
       

        public BankAccount(int accountNumber, string name, string password, double amount)
        {
            ValidateAmount(amount);
            this.accountNumber = accountNumber;
            this.name = name;
            //this.password = password;
            //SetPassword(password);
            Password = password; //calls Password set
            balance = amount;
        

        }

        private void ValidateAmount(double amount)
        {
            if (amount < 0)
                throw new InvalidDenominationException(accountNumber, "Amount Must be greater than 0");
        }

        public void Deposit(double amount)
        {
            ValidateAmount(amount);
            balance += amount;
            
        }

        public void Withdraw(double amount, string password)
        {

            ValidateAmount(amount);
            Authenticate(password);

            if(amount> balance)
            {
                throw new InsufficientBalanceException(AccountNumber, amount-balance);
            }
            
            balance -= amount;
        }

        public void CreditInterest(double interestRate)
        {
            balance += balance * interestRate / 1200;

        }

        public override string ToString()
        {
            return $"Account Number={accountNumber}\tName={name}\tBalance={balance}";
                
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


      
        //public string GetPassword() { return password; }    
        private string Password
        {
            set
            {
                CheckPasswordRule(value);
                Encryptor encryptor = new Encryptor();
                this.password = encryptor.Encrypt(value);
            }            
        }

        public bool InActive { get; internal set; }

        public void Authenticate(string password)
        {
            Encryptor matcher = new Encryptor();

            if (!matcher.Match(this.password, password))
                throw new InvalidCredentialsException(AccountNumber, 1, "Invalid Credentials");
        }

        private void CheckPasswordRule(string newPassword)
        {
            if (newPassword.Length < 5 && newPassword.Length > 10)
                throw new InvalidPasswordException(accountNumber, $"Password must be between 5-10 chars");
        }

        public void  ChangePassword(string confirmPassword, string newPassword)
        {
            Authenticate(confirmPassword);            
            Password = newPassword;            
        }

    }
}
