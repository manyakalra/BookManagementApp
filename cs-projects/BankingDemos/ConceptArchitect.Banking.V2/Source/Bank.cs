using System;

namespace ConceptArchitect.Finance.Core
{
    public class Bank
    {

        BankAccount[] accounts = new BankAccount[100];

        public Bank(string bankName, double rate)
        {
            Name = bankName;
            Rate = rate;
        }

        string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        double rate;
        public double Rate
        {
            get
            {
                return rate;
            }
            set
            {
                rate = value;
            }
        }

        int lastId = 0;
        public int OpenAccount(string name, string validPassword, double amount)
        {
            var accountNumber = ++lastId;

            var account = new BankAccount(accountNumber, name, validPassword, amount);
            accounts[accountNumber] = account;


            return accountNumber;
        }


        private BankAccount GetAccount(int accountNumber)
        {
            if (accountNumber < 0 || accountNumber > lastId || accounts[accountNumber].InActive)
            {
                throw new InvalidAccountException(accountNumber);
            }
            else
            {
                
                return accounts[accountNumber]; 
            }
            
                
        }

        public string GetInfo(int accountNumber, string password)
        {
            var account=GetAccount(accountNumber);
            if (account == null)
                return null;
            
            account.Authenticate(password);
            return account.ToString();
            
        }

        public double CloseAccount(int accountNumber, string password)
        {
            var account = GetAccount(accountNumber);
            account.Authenticate(password);

            if (account.Balance < 0)
                throw new InsufficientBalanceException(accountNumber,-account.Balance, $"You must not have pending dues before closing the account");

            
            account.InActive = true;
            return account.Balance;
        }

        internal string[] GetAccountsInfo()
        {
            var accountsInfo = new String[lastId+1];
            for (int i = 1; i <= lastId; i++)
                accountsInfo[i] = accounts[i].ToString();

            return accountsInfo;
        }

        public void Deposit(int accountNumber, double amount)
        {
            var account=GetAccount(accountNumber);

            account.Deposit(amount);
        }

        public double GetBalance(int accountNumber, string password)
        {
            var account= GetAccount(accountNumber);
            account.Authenticate(password);
            return account.Balance;
          }

        public void CreditInterest()
        {
            for (int i = 1; i <= lastId; i++)
                if(!accounts[i].InActive)
                    accounts[i].CreditInterest(Rate);
        }

        public void Withdraw(int accountNumber, double amount, string password)
        {
            var account = GetAccount(accountNumber);
            account.Withdraw(amount,password);
        }

        public void Transfer(int sourceAccountNumber, double amount, string password, int targetAccountNumber)
        {
            var sourceAccount=GetAccount(sourceAccountNumber);
            var targetAccount = GetAccount(targetAccountNumber);

            sourceAccount.Withdraw(amount, password);
            targetAccount.Deposit(amount);
        }
    }
}