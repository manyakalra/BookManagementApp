using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Finance.Core
{
    public class CurentAccount : BankAccount
    {
        public CurentAccount(int accountNumber, string name, string password, double amount) : base(accountNumber, name, password, amount)
        {
        }

        public int MinBalance
        {
            get
            {
                return 5000;
            }
        }

        public override void Withdraw(double amount, string password)
        {
            if (amount > Balance - MinBalance)
                throw new InsufficientBalanceException(AccountNumber, amount - Balance - MinBalance);

            //let base withdraw do it's magic
            base.Withdraw(amount, password);    
            
        }
    }
}
