namespace ConceptArchitect.Utils
{
    public class PrimeUtils
    {
        public static bool IsPrime(int value)
        {
            if (value < 2)
                return false;

            for (int i = 2; i < value; i++)
                if (value % i == 0)
                    return false;

            return true;
        }
        
        public static List<int> FindPrimes(int min,int max)
        {
            var primes=new List<int>();
            for(int i = min; i <= max; i++) 
                if(IsPrime(i))
                    primes.Add(i);  
            return primes;
        }
    }
}