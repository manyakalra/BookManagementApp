using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadingDemo06_WorkerBasket01
{
    public class WorkManager
    {
        public void AssignWorks(int workerCount, int itemsPerWorker, bool useSameBasket=false)
        {
            Worker [] workers = new Worker[workerCount];            
            var singleBasket = new Basket(); //It may not always be used.

            for(int i=0;i<workerCount;i++)
            {
                var basket = useSameBasket ? singleBasket : new Basket();
                workers[i] = new Worker(basket, itemsPerWorker);
            }

            var result =PerformanceMonitor.Measure(() =>
            {
                Console.WriteLine("Starting the workers...");
                foreach (var worker in workers)
                    worker.Start();

                Console.WriteLine("Waiting for workers to finish...");
                foreach (var worker in workers)
                    worker.Wait();

                return 0;
            });

            Console.WriteLine("checking the work done...");
            long totalWork = 0;
            if (useSameBasket)
                totalWork = singleBasket.Items;
            else
                foreach (var worker in workers)
                    totalWork += worker.Basket.Items;

            Console.WriteLine($"Total Time Taken is {result.TimeTaken} ms");
            Console.WriteLine($"Total Items added by {workerCount} is {totalWork}");

        }
    }
}
