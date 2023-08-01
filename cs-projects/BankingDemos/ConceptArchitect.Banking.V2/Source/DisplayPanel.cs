using System;

namespace ConceptArchitect.Finance.Core
{
    public class DisplayPanel
    {
        public void Show(string message, ConsoleColor color=ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}