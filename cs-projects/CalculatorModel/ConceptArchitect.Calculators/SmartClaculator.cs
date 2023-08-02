using ConceptArchitect.Collections;
using System;
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

        //Operator[] operators = new Operator[100];
        //LinkedList<Operator> operators = new LinkedList<Operator>();

        LinkedList<Pair<string, Operator>> operators = new LinkedList<Pair<string, Operator>>();

        //int operatorCount = 0;

        public SmartClaculator()
        {
            AddOperator(Calculations.Plus,"plus","add","sum","+");
            AddOperator(Calculations.Minus, "minus","-");
            AddOperator(Calculations.Multiply,"multiply","*");
            AddOperator(Calculations.Divide, "divide","/");
        }

        public void AddOperator(Operator opr, params string[] names)
        {
            if (names.Length == 0)
            {
                names = new string[] { opr.Method.Name };
            }


            foreach (var name in names)
                operators.Add(new Pair<string, Operator>() { Key = name, Value = opr } );
        }

        public Operator GetOperator(string name)
        {
            for(int i = 0; i < operators.Length; i++)
            {
                var oprName = operators.Get(i).Key;
                var opr = operators.Get(i).Value;

                if(oprName.ToLower() == name.ToLower())
                    return opr;
            }

            //default case
            throw new ArgumentException($"Invalid Operator:{name}");
        }

        public void PrintResult(int v1, string oprName, int v2)
        {
            try
            {
                var opr = GetOperator(oprName);
                var result = opr(v1, v2);

                var output = Formatter(v1, v2, oprName, result);
                Screen(output);
            }
            catch
            {
                Screen($"Invalid Operator :{oprName}");
            }

            
                

            

            

        }
    }
}
