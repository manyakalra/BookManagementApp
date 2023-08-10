using System;
using ConceptArchitect.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ConceptArchitect.Collections.Extensions;

namespace CollectionTests
{
    public class ListExtensionTests
    {
        string[] names = { "India", "USA", "France", "Japan", "UAE", "UK", "Norway" };
        int[] numbers = { 2, 5, 15, 11, 4, 8, 7, 1, 16, 2 };

        LinkedList<string> stringList;
        LinkedList<int> intList;

        public ListExtensionTests()
        {
            stringList = new LinkedList<string>(names);
            intList= new LinkedList<int>(numbers);
        }

        [Fact]
        public void FindCanReturnAllNamesGreaterThan3Char()
        {
            var result = stringList.Where(str => str.Length > 3);

            //for(int i=0;i<result.Length;i++)
            //{
            //    Assert.True(result[i].Length > 3);
            //}

            result.ForEach(v => Assert.True(v.Length > 3));
        }

        [Fact]
        public void TransformCanReturnAListContainsLengthsOfString()
        {
            var lengths = ListUtils.Select(stringList, s => s.Length);

            //for (int i = 0; i < lengths.Length; i++)
            //    Assert.Equal(stringList[i].Length, lengths[i]);

            int i = 0;
            lengths.ForEach(x => {
                Assert.Equal(stringList[i++].Length, x);
               });
        }

        [Fact]
        public void TransformCanReturnUpperCasedStrings()
        {
            var upperStringList = stringList.Select(s => s.ToUpper());

            //for (int i = 0; i < upperStringList.Length; i++)
            //    Assert.Equal(stringList[i].ToUpper(), upperStringList[i]);

            upperStringList.ForEach((v, i) => Assert.Equal(stringList[i].ToUpper(), v));
        }

        [Fact]
        public void CanConvertStringToInt()
        {
            var str = "25";
            var i = str.ToInt();

            Assert.Equal(25, i);
        }

        [Fact]
        public void ToIntReturnsDefaultForBadConversion()
        {
            var str = "hello";
            var i = str.ToInt(5);

            Assert.Equal(5, i);
        }
   
    
        [Fact]
        public void FindAllReturnsAllMatchingItems()
        {

        }
    
    }
}
