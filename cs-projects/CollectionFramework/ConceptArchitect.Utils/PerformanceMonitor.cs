using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Utils
{
    public class PerformanceResult<T>
    {
        public long TimeTaken { get; set; }
        public T Return { get; set; }
    }

    public delegate T LongTask<T>();

    public class PerformanceMonitor
    {
        public static PerformanceResult<T> Measure<T>(LongTask<T> task)
        {
            var watch = new Stopwatch();
            
            watch.Start();

            var result = task();

            watch.Stop();

            return new PerformanceResult<T>()
            {
                TimeTaken = watch.ElapsedMilliseconds,
                Return=result

            };
        }

        public static long Measure(Action task)
        {
            var watch = new Stopwatch();

            watch.Start();

            task();

            watch.Stop();

            return watch.ElapsedMilliseconds;
        }


    }
}
