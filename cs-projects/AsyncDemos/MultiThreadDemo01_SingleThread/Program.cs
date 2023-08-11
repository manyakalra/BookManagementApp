
class Program
{ 
    static void Main()
    {
        //Every Program has at least one thread
        //We can access the current thread

        Thread t = Thread.CurrentThread;
        Console.WriteLine(t);
        Console.WriteLine(t.ManagedThreadId);
        Console.WriteLine(t.Priority);

        t.Priority = ThreadPriority.AboveNormal;
        Console.WriteLine(t.Priority);
    }
}
