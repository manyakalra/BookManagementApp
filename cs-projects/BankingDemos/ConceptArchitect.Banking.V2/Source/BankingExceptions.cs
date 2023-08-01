using System;
using System.Collections.Generic;
using System.Linq;
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

        public InvalidCredentialsException(int accountNumber, int invalidAttempts, string message = "Banking Exception") : base(accountNumber, message)
        {
        }
    }
     
    public class InsufficientBalanceException : Exception { }


}
