using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Finance.Core
{
    public class OverdraftAccount : BankAccount
    {
        public double OdLimit { get; private set; }

        public OverdraftAccount(int accountNumber, string name, string password, double amount) : base(accountNumber, name, password, amount)
        {
            AdjustOdLimit();
        }

        public override void Deposit(double amount)
        {
            base.Deposit(amount);
            AdjustOdLimit();

        }

        public override double SufficientBalance
        {
            get
            {
                return Balance + OdLimit + OdLimit / 10;
            }
        }

        public override void Withdraw(double amount,  string password)
        {
            //base.Withdraw(amount, password);

            if(amount > Balance)
            {
                var od = amount - Balance;
                var odFee = od / 10;
                amount += odFee;
            }

            base.Withdraw(amount, password);

        }

        public override void CreditInterest(double interestRate)
        {
            base.CreditInterest(interestRate);
            AdjustOdLimit();
        }

        private void AdjustOdLimit()
        {
            if (Balance  > OdLimit * 10)
                OdLimit = Balance / 10;
        }
    }
}
