using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Calculators
{
    public class ResultFormatters
    {
        public static string MethodStyle(int v1,int v2, string methodName, int result)
        {
            return $"{methodName}({v1},{v2}) = {result}";
        }

        public static string Raw(int v1, int v2, string methodName, int result)
        {
            return result.ToString();
        }
    }
}
