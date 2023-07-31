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
                return null;
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
            if (account.Authenticate(password))
                return account.ToString();
            else
                return null;
        }

        public Status CloseAccount(int accountNumber, string password, out double balance)
        {
            balance = 0;
            var account = GetAccount(accountNumber);

            if (account == null)
                return Status.INVALID_ACCOUNT_NUMBER;

            if(!account.Authenticate(password))
                return Status.INVALID_CREDENTIALS;

            if (account.Balance < 0)
                return Status.INSUFFICIENT_BALANCE;

            balance = account.Balance;
            //accounts[accountNumber] = null;
            account.InActive = true;
            return Status.SUCCESS;
        }

        internal string[] GetAccountsInfo()
        {
            var accountsInfo = new String[lastId+1];
            for (int i = 1; i <= lastId; i++)
                accountsInfo[i] = accounts[i].ToString();

            return accountsInfo;
        }

        public Status Deposit(int accountNumber, double amount)
        {
            var account=GetAccount(accountNumber);
            if(account==null)
                return Status.INVALID_ACCOUNT_NUMBER;

            if(amount<=0)
                return Status.INVALID_AMOUNT;

            account.Deposit(amount);
            return Status.SUCCESS;
        }

        public double GetBalance(int accountNumber, string password)
        {
            var account= GetAccount(accountNumber);

            if (account == null)
                return -1;

            if (!account.Authenticate(password))
                return -1;

            return account.Balance;
          }

        public void CreditInterest()
        {
            for (int i = 1; i <= lastId; i++)
                if(!accounts[i].InActive)
                    accounts[i].CreditInterest(Rate);
        }

        public Status Withdraw(int accountNumber, double amount, string password)
        {
            var account = GetAccount(accountNumber);
            if(account==null)
                return Status.INVALID_ACCOUNT_NUMBER;

            if (!account.Authenticate(password))
                return Status.INVALID_CREDENTIALS;

            return account.Withdraw(amount,password);
        }

        public Status Transfer(int sourceAccountNumber, double amount, string password, int targetAccountNumber)
        {
            var sourceAccount=GetAccount(sourceAccountNumber);
            var targetAccount = GetAccount(targetAccountNumber);
            if(sourceAccount==null || targetAccount==null)
                return Status.INVALID_ACCOUNT_NUMBER;

            var status= sourceAccount.Withdraw(amount, password);

            if (status == Status.SUCCESS)
                return targetAccount.Deposit(amount) ? Status.SUCCESS : Status.INVALID_AMOUNT;
            else
                return status;
        }
    }
}