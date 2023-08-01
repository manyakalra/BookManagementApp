using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ConceptArchitect.Finance.Core.V2.Specs
{
    public  class SavingsAccountSpecs
    {
        string password = "p@ssword";
        double amount = 20000;
        double minBalance = 5000;
        CurentAccount account;

        public SavingsAccountSpecs()
        {
            account = new CurentAccount(1, "Name", password, amount);
        }
        
        [Fact]
        public void SavingsAccountShouldHaveMinBalance()
        {
            Assert.Equal(minBalance, account.MinBalance);
                
        }
        [Fact]
        public void WithdrawalFailsForBalanceLessThanAmountPlusMinBalance()
        {
           var ex= Assert.Throws<InsufficientBalanceException>(() => account.Withdraw(amount - account.MinBalance + 1, password));

            Assert.Equal(amount, account.Balance);
            
        }
    }
}
