using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Finance.Core
{

    public class BankingException : Exception
    {
        public int AccountNumber { get; private set; }

        public BankingException(int accountNumber, string message="Banking Exception"):base(message)
        {
            AccountNumber = accountNumber;
        }
    }

    public class InvalidCredentialsException : BankingException
    {
        public int InvalidAttempts { get; set; }

        public bool AllowRetry
        {
            get { return InvalidAttempts <= 3; }
        }

        public InvalidCredentialsException(int accountNumber, int invalidAttempts, string message = "Invalid Credentials") : base(accountNumber, message)
        {
        }
    }

    public class InsufficientBalanceException : BankingException
    {
        public double Deficit { get; private set; }
        public InsufficientBalanceException(int accountNumber,double deficit, string message = "Insufficient Balance") : base(accountNumber, message)
        {
        }
    }

    public class InvalidAccountException : BankingException
    {
        public InvalidAccountException(int accountNumber, string message = $"Invalid Account Number") : base(accountNumber, message)
        {
        }
    }

    public class InvalidDenominationException : BankingException
    {
        public InvalidDenominationException(int accountNumber, string message = "Invalid Denomination") : base(accountNumber, message)
        {
        }
    }


}

namespace ConceptArchitect.Finance.Core
{
    [Serializable]
    public class InvalidPasswordException : BankingException
    {
        public InvalidPasswordException(int accountNumber, string message = "Invalid Password") 
            : base(accountNumber, message)
        {
        }
    }
}