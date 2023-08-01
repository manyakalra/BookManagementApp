using System;

namespace ConceptArchitect.Finance.Core
{
    public class CurrentAccount:BankAccount
    {
        public CurrentAccount(int accountNumber, string name, string password, double amount) : base(accountNumber, name, password, amount)
        {
        }

        public override void CreditInterest(double rate)
        {
            //do nothing   
        }
    }
}