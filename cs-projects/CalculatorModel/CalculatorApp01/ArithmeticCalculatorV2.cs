using System;

namespace ConceptArchitect.Calculators
{
    public  class ArithmeticCalculatorV2
    {
        public ICalculatorScreen Screen { get; set; } = new ConsoleCalculatorScreen();
        ResultFormatter resultFormatter = new ResultFormatter();
        

        public void DisplayResult(int v1, IBinaryOperator opr, int v2)
        {

            //Step #1
            int result = opr.Calculate(v1, v2);

            //Step #2
            string output = resultFormatter.FormatResult(v1, opr.GetType().Name, v2, result);

            //Step #3.GetType
            Screen.Show(output);

        }
        

        int Calculate(int v1, string opr, int v2)
        {
            int result = 0;

            switch (opr)
            {
                case "plus":
                    result = v1 + v2;
                    break;
                case "minus":
                    result = v1 - v2;
                    break;
                case "multiply":
                    result = v1 * v2;
                    break;
                case "divide":
                    result = v1 / v2;
                    break;

                case "mod":
                    result = v1 % v2;
                    break;

                default:
                    Console.WriteLine($"Invalid operator: '{opr}'");
                    return 0;
            }

            return result;
        }

      
    }
}