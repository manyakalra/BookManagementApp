namespace ConceptArchitect.Utils
{
    public static class PrimeUtils
    {
        public static bool IsPrime(this int value)
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
            for(int i = min; i < max; i++) 
                if(IsPrime(i))
                    primes.Add(i);  
            return primes;
        }

        public static void FindPrimesCb(int min, int max, 
                            Action<int,bool> primeNotification)
        {
            for (int i = min; i < max; i++)
                if (IsPrime(i))
                    primeNotification(i, false);

            primeNotification(0, true); //job is over
        }
    }
}