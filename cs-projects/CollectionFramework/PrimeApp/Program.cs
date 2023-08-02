

using ConceptArchitect.Utils;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Console.WriteLine("Please wait...");

        var result = PerformanceMonitor.Measure(() =>  PrimeUtils.FindPrimes(2, 100000));


        Console.WriteLine($"Total Primes = {result.Return.Count}");
        Console.WriteLine($"Total Time taken = {result.TimeTaken}");
    }
}