using System;

namespace CalculatorApp01
{
    public  class ArithmeticCalculator
    {
        public ArithmeticCalculator()
        {
        }

        public int Result { get; private set; }

        public void DisplayResult(int v1, string opr, int v2)
        {
            

            switch(opr)
            {
                case "plus":
                    Result = v1 + v2;               
                    break;
                case "minus":
                    Result = v1 - v2;
                    break;
                case "multiply":
                    Result = v1 * v2;
                    break;
                case "divide":
                    Result = v1 / v2;
                    break;

                case "mod":
                    Result=v1 % v2;
                    break;

                default:
                    Console.WriteLine($"Invalid operator: '{opr}'");
                    return;
            }

            var output=$"{opr}({v1},{v2})={Result}";

            Console.WriteLine(output);

        }
    }
}