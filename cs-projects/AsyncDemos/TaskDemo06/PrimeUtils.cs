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


        public static List<int> FindPrimeAsyncV1(int min, int max)
        {
            var result = new List<int>();
            var tasks= new List<Task>();

            for(int i = min; i <= max; i++)
            {
                var x = i;
                var t=Task.Factory.StartNew(() =>
                {
                    if (IsPrime(x))
                    {
                        lock(result)
                        {
                            result.Add(x);
                        }
                        
                    }
                        
                });
                tasks.Add(t);
            }

            Task.WaitAll(tasks.ToArray());

            return result;
        }


        public static List<int> FindPrimesAsync(int min, int max)
        {
            var primes = new List<int>();

            Parallel.For(min, max, i =>
             {
                 //this will be a new task
                 if(IsPrime(i))
                 {
                     lock (primes)
                         primes.Add(i);
                 }
             });

            //no wait needed

            return primes;
        }
        
    }
}