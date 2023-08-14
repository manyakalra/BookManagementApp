using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadingDemo06_WorkerBasket01
{
    public class Basket
    {
        public long Items { get; private set; }



        public void AddItem()
        {

            lock (this)   
            {
                var i = Items;
                i++;
                Items = i;
            } 

        }

        public void AddItemV2()
        {
            try
            {
                Monitor.Enter(this); //only one thread can enter montior for Items
                var i = Items;
                i++;
                Items = i;
               
            }
            finally
            {
                Monitor.Exit(this); //once one thread exists other can enter.
            }
            

            
        }

        public void AddItemV1()
        {
            Monitor.Enter(this); //only one thread can enter montior for Items
            var i = Items;
            i++;
            Items = i;
            if (Items == 100)
                return;

            Monitor.Exit(this); //once one thread exists other can enter.
        }
    }
}
