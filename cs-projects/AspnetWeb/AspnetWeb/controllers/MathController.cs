namespace AspnetWeb.controllers
{
    public class MathController
    {

        public string Index()
        {
            return "Supported Operations: Plus, Minus, Mulitply, Divide, Factorial";
        }

        //Controller shouldn't ahve business logic
        //This code is just to explain routing
        //and shouldn't be considered as a good practice for controller design
        public int Plus(int x,int y)
        {
            return x + y;
        }

        public int Factorial(int x)
        {
            int fx = 1;
            while (x > 1)
                fx *= x--;
            return fx;
        }


        public int Minus(int x,int y)
        {
            return x - y;
        }

        public int Multiply(int x, int y)
        {
            return x * y;
        }
        public int Divide(int x, int y)
        {
            return x - y;
        }

       
    }
}
