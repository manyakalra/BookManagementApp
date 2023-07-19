using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = "pass#1";
            BankAccount a1 = new BankAccount(1, "Sanjay Mall", password, 20000, 12);

            a1.Show();

            a1.Deposit(2000);

            a1.Deposit(-2);

            a1.Withdraw(1000, password);

            a1.Withdraw(-1, password);

            a1.Withdraw(1000, "wrong password");

            a1.CreditInterest();

            a1.Show();

            a1.SetName("Sanjay Singh"); //shouldn't change
            Console.WriteLine(a1.GetName());

            a1.SetName("Sanjeev Mall");
            Console.WriteLine(a1.GetName());


            

        }
    }
}
