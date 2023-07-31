using System;

namespace ConceptArchitect.Finance.Core
{
    public class CashDispenser
    {
        public void Dispense(int amount)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[Dispensing {amount}]");
            Console.ResetColor();
        }
    }
}