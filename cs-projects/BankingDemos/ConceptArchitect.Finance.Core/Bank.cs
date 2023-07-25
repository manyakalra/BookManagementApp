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
            var accountNumber= ++lastId;
            
            var account = new BankAccount(accountNumber,name,validPassword,amount);
            accounts[accountNumber] = account;


            return accountNumber;
        }

        public Status CloseAccount(int accountNumber, string password,out double balance)
        {
            balance = 0;
            if (accountNumber <= 0)
                return Status.INVALID_ACCOUNT_NUMBER;
            else
                return Status.INVALID_CREDENTIALS;
        }

        public Status Deposit(int accountNumber, double amount)
        {
            return Status.SUCCESS;
        }

        public double GetBalance(int accountNumber, string password)
        {
            return -1;
        }
    }
}