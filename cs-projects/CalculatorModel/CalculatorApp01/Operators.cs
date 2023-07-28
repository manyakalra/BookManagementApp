using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Calculators
{
    public interface IBinaryOperator
    {
        int Calculate(int v1, int v2);
    }

    public class Plus : IBinaryOperator
    {        
        public int Calculate(int v1, int v2)
        {
            return v1 + v2;
        }
    }

    public class Minus : IBinaryOperator
    { 
        public int Calculate(int v1,int v2)
        {
            return v1 - v2;
        }
    }



}
