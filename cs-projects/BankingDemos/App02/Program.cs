using ConceptArchictect.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String password = "pass#1";
            String newPassword = "pass#2";

            BankAccount a1 = new BankAccount(1, "Vivek",password, 20000, 12);


            a1.Deposit(-1);
            Console.WriteLine("Amount Deposited");

           
        }
    }
}
