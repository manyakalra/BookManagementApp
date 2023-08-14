
using ConceptArchitect.Utils;
using System.Diagnostics;

class Program
{
    static void TestFindPrimes(int max)
    {
        Console.WriteLine($"Finding Primes under {max}");
        var watch = new Stopwatch();
        watch.Start();
        var primes = PrimeUtils.FindPrimes(0, max);
        watch.Stop();
        Console.WriteLine($"Total Time Taken is {watch.ElapsedMilliseconds}\tTotal Primes Under {max}:{primes.Count}");
              
    }

    static void TestFindPrimesAsync(int max)
    {
        Console.WriteLine($"Finding Primes under {max}");
        var watch = new Stopwatch();
        watch.Start();

        Task
            .Factory
            .StartNew(() => PrimeUtils.FindPrimes(0, max))
            .ContinueWith(task =>
            {
                watch.Stop();
                Console.WriteLine($"Total Time Taken is {watch.ElapsedMilliseconds}\tTotal Primes Under {max}:{task.Result.Count}");
            });
    }

    static void TestFindPrimesAsync2(int max)
    {
        Console.WriteLine($"Finding Primes under {max}");
        var watch = new Stopwatch();
        watch.Start();

        var result = Task
                        .Factory
                        .StartNew(()=>PrimeUtils.FindPrimesAsync(0, max))
                        .ContinueWith(task =>
                        {
                            watch.Stop();
                            Console.WriteLine($"Total Time Taken is {watch.ElapsedMilliseconds}\tTotal Primes Under {max}:{task.Result.Count}");
                        });
    }





    static void Main()
    {
        //TestSyncrhonousPrimes();
        TestFindPrimesAsync2(500000);
        TestFindPrimesAsync2(50000);
        TestFindPrimesAsync2(100);

        Console.WriteLine("Hit Enter to Exit");
        Console.ReadLine();
    }

    private static void TestSyncrhonousPrimes()
    {
        TestFindPrimes(100000);
        TestFindPrimes(50000);
        TestFindPrimes(100);
    }
}