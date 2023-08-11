
class Program
{ 

    static void CountDown(int max)
    {
        var t=Thread.CurrentThread;
        Console.WriteLine($"[#{t.ManagedThreadId}] starts");
        while(max>=0)
        {
            Console.WriteLine($"[#{t.ManagedThreadId}] {max}");
            max--;
        }
        Console.WriteLine($"[#{t.ManagedThreadId}] stops");
    }

    static void Main()
    {
        var t1 = new Thread(() => CountDown(200));
        var t2 = new Thread(() => CountDown(2500));
        var t3 = new Thread(() => CountDown(300));

        t2.IsBackground = true;

        t1.Start(); //Will Print ThreadInfo of new Thread
        t2.Start();
        t3.Start();
        //BusyMain();

        //Thread.Sleep(5000); //make main thread sleep for 5 seconds

        //CheckIsAlive(t1, t3);

        t1.Join(); //I (Current Thread) will sleep till t1. finishes (and Joins)
        //t2.Join(); //I (Current Thread) will sleep till t2. finishes (and Joins)
        t3.Join(); //I (Current Thread) will sleep till t2. finishes (and Joins)

        Console.WriteLine("Program Ends");
    }

    private static void CheckIsAlive(Thread t1, Thread t3)
    {
        while (t1.IsAlive || t1.IsAlive || t3.IsAlive)
        {
            Console.WriteLine("+");
            Thread.Sleep(10);
        }
    }

    private static void BusyMain()
    {
        for (int i = 0; i < 1000; i++)
            Console.Write("+");
    }
}
