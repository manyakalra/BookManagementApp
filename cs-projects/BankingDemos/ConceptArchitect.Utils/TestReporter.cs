using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Utils
{
    public class TestReporter
    {
        public static void ReportSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("PASSED:\t{0}",message);
            Console.ResetColor();
        }
        public static void ReportFailure(string message, string expected, string actual)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("FAILED:\t{0}\n\tExpected:'{1}'\tActual:'{2}'",message,expected,actual );
            Console.ResetColor();
        }

        public static void Report(string message, string expected, string actual)
        {
            if(expected==actual)
                ReportSuccess(message);
            else
                ReportFailure(message,expected,actual);

            
        }
    }
}
