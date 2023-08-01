using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ConceptArchitect.Finance.Core.V2.Specs
{
    public  class CurrentAccountSpecs
    {
        string password = "p@ssword";
        double amount = 20000;
        double minBalance = 5000;
        CurrentAccount account;

        public CurrentAccountSpecs()
        {
            account = new CurrentAccount(1, "Name", password, amount);
        }

        [Fact]
        public void CurrentAccountIsATypeOfBankAccount()
        {
            Assert.True(account is BankAccount);    
                
        }
        [Fact]
        public void CreditInterestShouldntCreditInterest()
        {
            account.CreditInterest(12);

            Assert.Equal(amount, account.Balance);
            
        }
    }
}
