using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Calculators
{
    public class ResultFormatter
    {
        public  string FormatResult(int v1, string opr, int v2, int result)
        {
            return $"{opr}({v1},{v2})={result}";
        }
    }
}
