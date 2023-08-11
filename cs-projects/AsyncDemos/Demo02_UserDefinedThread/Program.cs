
class Program
{ 

    static void PrintThreadInfo()
    {
        var t=Thread.CurrentThread;
        Console.WriteLine($"Current Thread has Id: {t.ManagedThreadId}");
    }

    static void Main()
    {
        var newThread =new Thread(PrintThreadInfo);

        newThread.Start(); //Will Print ThreadInfo of new Thread

        PrintThreadInfo(); //Will Print Thread info of current thread
    }
}
