using ConceptArchitect.Async;
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

        public static int PermutationAsyncV1(this int n, int r)
        {
            int fn = 1;
            var fnThread = new Thread(() =>fn= n.Factorial());
            fnThread.Start();
            
            int fn_r = 1;
            var fn_rThread = new Thread(() => fn_r = (n - r).Factorial());
            fn_rThread.Start();

            fnThread.Join();
            fn_rThread.Join();
           


            return fn / fn_r;
        }

        public static int PermutationAsync(this int n, int r)
        {

            var fn = new AsyncFunction<int>(() => n.Factorial());

            var fn_r = new AsyncFunction<int>(() => (n - r).Factorial());

           
            return fn.Result / fn_r.Result;
        }




    }
}
