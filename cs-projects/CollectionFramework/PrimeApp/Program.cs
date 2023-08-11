

using ConceptArchitect.Utils;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        int min = 2, max = 10000;
        //PrimeFinderWithWhileLoop(min, max);
        //PrimeFinderUsingForEach(min, max);
        //PrimeFinderUsingLINQ(min, max);

        //FindPrimesUsingEvents(min, max);

        //LinqAggregate(min, max);

        var primes = (from prime in new PrimeFinder(2, 100)


                      select prime).ToList();



        Console.WriteLine("Lets begin Printing");
        foreach(var prime in primes)
            Console.WriteLine(prime);



    }

    private static void LinqAggregate(int min, int max)
    {
        var value = (from p in new PrimeFinder(min, max)
                     where p % 10 == 7
                     select p).Max();

        //Console.WriteLine($"Total Primes between {min}-{max} ending with 7 is {count}");
        Console.WriteLine($"Largest Primes  under {max} ending with 7 is {value}");
    }

    private static void FindPrimesUsingEvents(int min, int max)
    {
        var notifier = new PrimePublisher(min, max);

        int primes = 0;

        notifier.Primes += prime =>
        {
            int pc = (prime - min) * 100 / (max - min);
            Console.Write($"\r{pc} %");
            primes++;
        };

        notifier.Completed += () =>
        {
            Console.WriteLine($"\nTotal Primes {primes}");
        };

        notifier.Start();
    }

    private static void PrimeFinderUsingLINQ(int min, int max)
    {
        var primes7 = (from prime in new PrimeFinder(min, max)
                       where prime % 10 == 7
                       select prime)
                      .Skip(2)
                      .Take(5);


        Console.WriteLine("Let's Print the Results");
        foreach (var prime in primes7)
            Console.WriteLine(prime);
    }

    private static void PrimeFinderUsingForEach(int min, int max)
    {
        int count = 0;
        foreach (var prime in new PrimeFinder(min, max))
        {
            if (prime >= max)
                break;

            if (prime % 10 == 7)
            {
                Console.WriteLine(prime);
                count++;
                if (count == 5)
                    break;
            }
        }
    }

    private static void PrimeFinderWithWhileLoop(int min, int max)
    {
        var finder = new PrimeFinder(min, max);
        int count = 0;
        while (finder.MoveNext())
        {
            var prime = finder.Current;
            if (prime >= max)
                break;

            if (prime % 10 == 7)
            {
                Console.WriteLine(prime);
                count++;
                if (count == 5)
                    break;
            }


        }
    }

    private static void FindPrimesCbTest()
    {
        

        PrimeUtils.FindPrimesCb(2, 100, (prime, done) =>
        {
            if (done)
                Console.WriteLine();
            else
                Console.Write($"{prime}\t");
        });

        int count = 0;
        int min = 50;
        int max = 500000;
        PrimeUtils.FindPrimesCb(min, max, (prime, done) =>
        {
            if (!done)
            {
                count++;
                var pc = (prime - min) * 100 / (max - min);
                Console.Write($"\r{pc}%");

            }
            else
                Console.WriteLine($"\nTotal Primes is {count}");
        });
    }

    private static void FindPrimesSync()
    {
        Console.WriteLine("Please wait...");

        var result = PerformanceMonitor.Measure(() => PrimeUtils.FindPrimes(2, 500000));

        //now we can start to process the results

        Console.WriteLine($"Total Primes = {result.Return.Count}");
        Console.WriteLine($"Total Time taken = {result.TimeTaken}");
    }
}