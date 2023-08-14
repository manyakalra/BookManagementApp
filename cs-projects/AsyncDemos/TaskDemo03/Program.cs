class Program
{
    static void CountDown(int taskId, int max)
    {
        var id = Thread.CurrentThread.ManagedThreadId;
        Console.WriteLine($"[{id}]: task {taskId} starts");
        while(max>=0)
        {
            Console.WriteLine($"[{id}]: task {taskId} counts {max}");
            max--;
        }

        Console.WriteLine($"[{id}]: task {taskId} stops");
    }

    static void Main()
    {
        var t1 = new Task(() => CountDown(1, 200));
        t1.Start();

        var t2 = Task.Factory.StartNew(() => CountDown(2, 150));
        //no need to start

        var t3 = Task.Factory.StartNew(() => CountDown(3, 100));

        //t1.Wait();
        //t2.Wait();
        //t3.Wait();

        Task.WaitAll(t1, t2, t3);

        


        Console.WriteLine("Program Ends"); 

    }
}