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
                var i = Items;
                i++;
                Items = i;

        }

     
    }
}
