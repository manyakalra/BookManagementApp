using MultiThreadingDemo06_WorkerBasket01;

class Program
{ 
    static void Main()
    {
        var manager = new WorkManager();

        manager.AssignWorks(1000, 100000, true);
    }
}

