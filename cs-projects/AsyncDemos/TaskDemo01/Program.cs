class Program
{
    static void ThreadInfoPrinter()
    {
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}");
    }

    static void Main()
    {
        for(int i=0;i<3;i++)
        {
            var task1 = new Task(ThreadInfoPrinter);
            task1.Start();
        }
        

        ThreadInfoPrinter();

    }
}