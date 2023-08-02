using ConceptArchitect.Collections;
using System;
using Xunit;

namespace CollectionTests
{
    public class ObjectListSpecs
    {

        Object[] dataSet = { "India", "USA", "UK", "France", "Japan" };
        ObjectList list;

        public ObjectListSpecs()
        {
            list = new ObjectList();
            foreach (var data in dataSet)
                list.Add(data);
        }

        [Fact()]
        public void NewList_HasZeroLength()
        {
            var list = new ObjectList();

            Assert.Equal(0, list.Length);
        }


        [Fact()]
        public void NewList_CanBeSuppliedWithInitializerList()
        {
            var list = new ObjectList(1, 2, 3, 4);

            Assert.Equal(4, list.Length);
        }

        [Fact()]
        public void Add_IncreasesTheListLength()
        {
            list.Add("something");

            Assert.Equal(dataSet.Length+1, list.Length);
        }


        [Fact()]
        public void Add_AddsAnItemAtTheEndOfTheList()
        {
            var data = "something";

            list.Add(data);

            Assert.Equal(data, list.Get(list.Length - 1));
        }

        [Fact(Skip ="We are Not implementing this")]
        public void Add_CanAddMulitpleItemsUsingInitializerList()
        { }


        [Fact()]
        public void Get_CanAccessTheItemUsingZeroBasedIndex()
        {
            
            for(var index=0;index<dataSet.Length;index++)
                Assert.Equal(dataSet[index], list.Get(index));

        }
        [Fact()]
        public void Get_FailsForInvalidIndex()
        {
            Assert.Throws<IndexOutOfRangeException>(()=>list.Get(dataSet.Length));
        }


        [Fact()]
        public void Set_CanSetTheItemAtZeroBasedIndex()
        {
            var data = "something";
            for(int i=0;i<list.Length;i++)
            {
                list.Set(i, i * 10);
                Assert.Equal(i * 10, list.Get(i));
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

    }
}
