
class Program
{ 

    static void CountDown()
    {
        var t=Thread.CurrentThread;
        int max = 100;
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
        var t1 =new Thread(CountDown);
        var t2 =new Thread(CountDown);
        var t3= new Thread(CountDown);

        t1.Start(); //Will Print ThreadInfo of new Thread
        t2.Start();
        t3.Start();

        Console.WriteLine("Program Ends");
    }
}
