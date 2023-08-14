using ConceptArchitect.Utils;
using System;
using Xunit;

namespace MultithreadingDemos04_Permutation
{
    public class MathTests
    {
        [Fact]
        public void FactorialTakesNSeconds()
        {
            var n = 5;

            var result = PerformanceMonitor.Measure(()=> n.Factorial());

            Assert.Equal(5, result.TimeTaken/1000.0, 0 );

        }

        [Fact]
        public void PermutationTakes2N_RSecondsInSynchronousCalculation()
        {
            var n = 7;
            int r = 2;

            var result = PerformanceMonitor.Measure(() => n.Permutation(r));

            Assert.Equal(2 * n - r, result.TimeTaken / 1000);
        }

        
        [Fact]
        public void PermutationTakesN_RSecondsInSyncCalculation()
        {
            var n = 7;
            int r = 2;

           

            var result = PerformanceMonitor.Measure(() => n.PermutationAsync(r));

            Assert.Equal(42, result.Return);
            Assert.Equal(n, result.TimeTaken / 1000);
            
        }
    }
}