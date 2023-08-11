using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Utils
{
    public class PrimePublisher
    {
        int min, max;
        public event Action<int> Primes;
        public event Action Completed;

        public PrimePublisher(int min, int max)
        {
            this.min = min;
            this.max = max;
        }

        public void Start()
        {
            for (int i = min; i <= max; i++)
                if (i.IsPrime())
                    if(Primes != null)
                        Primes(i);

            if(Completed != null)
                Completed();
        }
    }
}
