class Program
{
    static void TaskInfoPrinter(int taskId, int info)
    {
        Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] : " +
                    $"starts task #{taskId} starts with info {info}");
    }

    static void Main()
    {
        for(int i=1;i<=10;i++)
        {
            var id = i;
            var task1 = new Task(()=>TaskInfoPrinter(id,i));
            task1.Start();
        }
        

        TaskInfoPrinter(0,0); //Main

    }
}