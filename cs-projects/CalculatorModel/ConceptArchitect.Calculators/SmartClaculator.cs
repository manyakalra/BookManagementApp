using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Calculators
{
    public delegate int Operator(int x, int y);
    public delegate string ResultFormatter(int v1, int v2, string operationName, int result);
    public delegate void Screen(string output);

    public class SmartClaculator
    {

        public ResultFormatter Formatter { get;   set; } = ResultFormatters.MethodStyle;
        public Screen Screen { get; set; } = Screens.SimpleConsole;

        Operator[] operators = new Operator[100];
        int operatorCount = 0;

        public SmartClaculator()
        {
            AddOperator(Calculations.Plus);
            AddOperator(Calculations.Minus);
            AddOperator(Calculations.Multiply);
            AddOperator(Calculations.Divide);
        }

        public void AddOperator(Operator opr)
        {
            operators[operatorCount++] = opr;
        }

        public Operator GetOperator(string name)
        {
            for(int i = 0; i < operatorCount; i++)
            {
                if(operators[i].Method.Name.ToLower() == name.ToLower())
                    return operators[i];
            }

            //default case
            return null;
        }

        public void PrintResult(int v1, string oprName, int v2)
        {
            var opr = GetOperator(oprName);

            if (opr == null)
            {
                Screen($"Invalid Operator :{oprName}");
                return;
            }
                

            var result = opr(v1, v2);

            var output = Formatter(v1, v2, oprName, result);

            Screen(output);

        }
    }
}
