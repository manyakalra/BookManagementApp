using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Utils
{
    public class PrimeFinder : IEnumerator<int>, IEnumerable<int>
    {
        int min;
        int max;
        int current;
        public PrimeFinder(int min,int max)
        {
            this.min = min;
            this.max = max;
            this.current = min - 1;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return this; //I am my own Enumerator
        }


        public int Current
        {
            get
            {
                return current;
            }
        }
        public bool MoveNext()
        {

            do
            {
                current++;
            } while (!current.IsPrime());
            Console.WriteLine($"Found Prime {current}");
            return current < max;
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        

        public void Reset()
        {
            current = min - 1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
    }
}
