using ConceptArchitect.Collections;
using ConceptArchitect.Utils;

class Program
{
    static void Main()
    {
        var list = new ConceptArchitect.Collections.LinkedList<int>();

        int size = 100000;

        var timeTakenToAdd = PerformanceMonitor.Measure(() =>
        {
            for(int i=1;i<=size;i++)
                list.Add(i);
        });


        Console.WriteLine($"Total Time taken to add {size} items to list is {timeTakenToAdd} ms");


        var result = PerformanceMonitor.Measure(() => {
            var sum = 0;
            for (int i = 0; i < list.Length; i++)
                sum += list[i];

            return sum;
        
        });

        Console.WriteLine($"sum={result.Return} \n Time Taken = {result.TimeTaken} ms");
    

    }
}