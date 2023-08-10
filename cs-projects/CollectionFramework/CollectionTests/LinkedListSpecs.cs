using ConceptArchitect.Collections;
using ConceptArchitect.Utils;
using System;
using Xunit;
using ConceptArchitect.Collections.Extensions;

namespace CollectionTests
{
    public class LinkedListSpecs
    {

        string[] dataSet = { "India", "USA", "UK", "France", "Japan" };
        LinkedList<string> list;
        int originalLength;


        public LinkedListSpecs()
        {
            list = new LinkedList<string>();
            foreach (var data in dataSet)
                list.Add(data);

            originalLength = list.Length;
        }

        [Fact()]
        public void NewList_HasZeroLength()
        {
            var list = new LinkedList<int>();

            Assert.Equal(0, list.Length);
        }


        [Fact()]
        public void NewList_CanBeSuppliedWithInitializerList()
        {
            var list = new LinkedList<int>(1, 2, 3, 4);

            Assert.Equal(4, list.Length);
        }

        [Fact()]
        public void Add_IncreasesTheListLength()
        {
            list.Add("something");

            Assert.Equal(dataSet.Length+1, list.Length);
        }

        [Fact]
        public void Add_ReturnsTheSameList()
        {
            var result = list.Add("something");

            result.Add("soemthing else"); //adding to the same list

            Assert.Equal(list.GetHashCode(), result.GetHashCode());
        }

        [Fact]
        public void Add_CanChainAdds()
        {
            var newLength = list
                                .Add("one")
                                .Add("two")
                                .Add("three")
                                .Length;

            Assert.Equal(originalLength+3,newLength);
        }


        [Fact()]
        public void Add_AddsAnItemAtTheEndOfTheList()
        {
            var data = "something";

            list.Add(data);

            Assert.Equal(data, list[list.Length-1]);
        }

        [Fact(Skip ="We are Not implementing this")]
        public void Add_CanAddMulitpleItemsUsingInitializerList()
        { }


        [Fact()]
        public void Get_CanAccessTheItemUsingZeroBasedIndex()
        {
            
            for(var index=0;index<dataSet.Length;index++)
                Assert.Equal(dataSet[index], list[index]);

        }
        [Fact()]
        public void Get_FailsForInvalidIndex()
        {
            Assert.Throws<IndexOutOfRangeException>(()=>list[dataSet.Length]);
        }


        [Fact()]
        public void Set_CanSetTheItemAtZeroBasedIndex()
        {
            var list = new LinkedList<int>();

            for(int i=0;i<list.Length;i++)
            {
                list[i] = i * 10;   //list.Set(i, i * 10);
                Assert.Equal(i * 10, list[i]);
            }

        }


        [Fact()]
        public void Set_FailsForInvalidIndex()
        {
            Assert.Throws<IndexOutOfRangeException>(() => list.Set(100, "value"));
        }


        [Fact()]
        public void Length_ReturnsTheLengthOfTheList()
        {
           

            Assert.Equal(dataSet.Length, list.Length);
        }


        [Fact()]
        public void Remove_CanRemoveItemFromAGivenIndex()
        {
           
            var index = 2;

            list.Remove(index);

            Assert.Equal(dataSet.Length-1, list.Length);

        }


        [Fact()]
        public void Remove_ReturnsTheRemovedItem()
        {
            var index = 2;



            var item= list.Remove(index);

            Assert.Equal(dataSet[index], item);

        }

        [Fact()]
        public void Remove_FailsForInvalidIndex()
        {
            Assert.Throws<IndexOutOfRangeException>(() => list.Remove(100));
        }
        [Fact()]
        public void ToString_ReturnsEmptyForEmptyList()
        {
            var list = new ObjectList();

            Assert.Equal("(empty)", list.ToString());
        }
        [Fact()]
        public void ToString_IncludesAllItemsInTheList()
        {
            foreach (var data in dataSet)
                Assert.Contains(data.ToString(), list.ToString());
        }


        [Fact()]
        public void InsertIncreasesTheListLength()
        {
            list.Insert(1, "something");

            Assert.Equal(dataSet.Length+1, list.Length);
        }


        [Fact()]
        public void InsertInsertsNewItemInTheGivenPosition()
        {
            int pos = 2;
            var value = "something";

            list.Insert(pos, value);

            Assert.Equal(value, list.Get(pos));
        }


        [Fact()]
        public void InsertFailsForInvalidIndex()
        {
            Assert.Throws<IndexOutOfRangeException>(() => list.Insert(100, "anything"));
        }


        [Fact()]
        public void IndexOfReturnsIndexOfSearchedItem()
        {  

            for (int i = 0; i < dataSet.Length; i++)
                Assert.Equal(i, list.IndexOf(dataSet[i]));
        }

        [Fact()]
        public void IndexOfReturnsMinusOneForFailedSearch() {
            Assert.Equal(-1, list.IndexOf("missing item"));
        }


        [Fact]
        public void CountReturnsOccuranceOfAGivenValueInTheList()
        {
            var list = new LinkedList<int>(2, 3, 9, 2, 2, 1, 4, 5, 1);

            Assert.Equal(3, list.Count(2));

            Assert.Equal(2, list.Count(1));

            Assert.Equal(0, list.Count(10));
        }

        [Fact]
        public void LastIndexOfReturnsLastIndexOfAValueInTheList()
        {
            var list = new LinkedList<int>(2, 3, 9, 2, 2, 1, 4, 5, 1);

            Assert.Equal(4, list.LastIndexOf(2));

            Assert.Equal(8, list.LastIndexOf(1));

            Assert.Equal(-1, list.LastIndexOf(10));
        }

        [Fact]
        public void FindPrimesReturnsAllPrimes()
        {

            var list = new LinkedList<int>(2, 9, 7, 14, 4, 15, 19, 7);

            int [] expectedResult = { 2, 7, 19, 7 };

            var actualResult = list.Where(PrimeUtils.IsPrime);

            for (int i = 0; i < expectedResult.Length; i++)
            {
                Assert.Equal(expectedResult[i], actualResult[i]);
            }

        }

        [Fact]
        public void FindNamesOfGreaterThanThree()
        {

            var list = new LinkedList<string>("India", "USA", "UK", "France", "UAE");


            var result = list.Where(name => name.Length > 3);

            Assert.Equal(2, result.Length);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.True(result[i].Length > 3);
            }

        }


    }
}
