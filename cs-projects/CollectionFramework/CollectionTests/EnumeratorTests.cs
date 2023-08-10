using ConceptArchitect.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ConceptArchitect.Collections.Extensions;

namespace CollectionTests
{
    public class EnumeratorTests
    {
        [Fact]
        public void WeCanEnumerateDynamicArray()
        {
            var array = new DynamicArray<int>(20);

            array.AddAll(1,2,3,4,5);

            int count = 0;
            var en = array.GetEnumerator();
            while(en.MoveNext())
            {
                count++;
                Assert.Equal(count, en.Current);
            }

            Assert.Equal(5, count);
            

        }
        
        [Fact]
        public void WeCanEnumerateDynamicArrayUsingForEach()
        {
            var array = new DynamicArray<int>(20);

            array.AddAll(1, 2, 3, 4, 5);

            int count = 0;
            foreach(var value in array)
            {
                count++;
                Assert.Equal(count, value);
            }

            Assert.Equal(5, count);


        }
    }
}
