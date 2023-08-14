
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadingDemos04_Permutation
{
    public static  class MathUtils
    {
        public static int Factorial(this int n)
        {
            int fn = 1;
            for(int i=1;i<=n;i++)
            {
                fn *= i;

                Thread.Sleep(1000);
            }

            return fn;
        }
   
        public static int Permutation(this int n, int r)
        {
            var fn = n.Factorial();
            var fn_r = (n - r).Factorial();

            return fn / fn_r;
        }

       

        public static int PermutationAsync(this int n, int r)
        {
            //var fn = new Task<int>(() => n.Factorial());
            //fn.Start();

            var fn = Task.Factory.StartNew(() => n.Factorial());
            var fn_r = Task.Factory.StartNew(() => (n - r).Factorial());

            //Task.WaitAll(fn, fn_r);

            return fn.Result / fn_r.Result;

        }




    }
}
