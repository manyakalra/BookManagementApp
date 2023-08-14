using MultithreadingDemos04_Permutation;

class Program
{
    

    static void Main()
    {
        int n = 7;

        Task
            .Factory
            .StartNew(() => n.Factorial())
            .ContinueWith(t => Console.WriteLine($"Factorial of {n} is {t.Result}")) //is another task that will run when previous one finishes
            .Wait(); //wait for printing to be over



    }
}