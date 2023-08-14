﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadingDemo06_WorkerBasket01
{
    public class Worker
    {
        Thread thread;
        public Basket Basket { get; private set; }

        int workCount;

        public Worker(Basket basket, int workCount)
        {
            this.workCount=workCount;
            thread = new Thread(Work);
            Basket = basket;

        }

        public void Start()
        {
            thread.Start();
        }

        public void Wait()
        {
            thread.Join();
        }

        private void Work()
        {
            for (int i = 0; i < workCount; i++)
                Basket.AddItem();
        }
    }
}
