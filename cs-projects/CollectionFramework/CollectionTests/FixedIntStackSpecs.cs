using ConceptArchitect.Collections;
using Xunit;

namespace CollectionTests
{
    public class FixedIntStackSpecs
    {
        FixedIntStack stack;
        int size = 3;

        public FixedIntStackSpecs()
        {
            stack = new FixedIntStack(size);
        }

        private void AssertFailed(string reason = "Not Yet Implemented")
        {
            Assert.True(false, reason);
        }

        [Fact(
                //Skip = "Not Yet Implemented"
        )]
        public void StackShouldBeInitializedWithSize()
        {
            var stack = new FixedIntStack(10);
            Assert.NotNull(stack);
        }
        [Fact(
               // Skip = "Not Yet Implemented"
        )]
        public void StackShouldBeInitiallyEmpty()
        {
            Assert.True(stack.IsEmpty);
        }

        [Fact(
        // Skip = "Not Yet Implemented"
        )]
        public void PushPushesNumberToStack()
        {
            var success=stack.Push(20);

            Assert.True(success);
        }


        [Fact(
               // Skip = "Not Yet Implemented"
        )]
        public void PushingAnItemToAnEmptyStackMakesItNonEmpty()
        {
            stack.Push(20);

            Assert.False(stack.IsEmpty);
        }


        [Fact(
               // Skip = "Not Yet Implemented"
        )]
        public void PushingItemsEqualsToTheSizeOfStackMakesItFull()
        {
            for (int i = 0; i < size; i++)
                stack.Push(i);


            Assert.True(stack.IsFull);
        }

        [Fact(
               // Skip = "Not Yet Implemented"
        )]
        public void PushingAnItemToAFullStackFails()
        {
            //Arrange --- Get a Full Stack
            for(var i = 0; i < size; i++)
            {
                stack.Push(i);
            }

            //Act
            bool success = stack.Push(10); //This should fail

            //Assert
            Assert.False(success);
        }

        [Fact(
                //Skip = "Not Yet Implemented"
        )]
        public void PoppingAnItemFromAnEmptyStackShouldFail()
        {
            bool checkSuccess;
            int val = stack.Pop(out checkSuccess);

            Assert.False(checkSuccess);
        }


        [Fact(
               // Skip = "Not Yet Implemented"
        )]
        public void PoppingFromAFullStackMakesItNonFull()
        {
            //Arrange 

           for(int i = 0; i < size; i++)
            {
                stack.Push(i);
            }

            //Act
            bool checkSuccess;
            int val = stack.Pop(out checkSuccess);

            //Assert

            Assert.False(stack.IsFull);



        }

        [Fact(
                //Skip = "Not Yet Implemented"
        )]
        public void PoppingReturnsTheLastItemPushed()
        {
            //Arrange
            int elementToPush = 10;
            stack.Push(elementToPush);
            //Act
            bool checkSuccess;
            int lastElement = stack.Pop(out checkSuccess);
            //Assert
            Assert.Equal(elementToPush, lastElement) ;
        }


        [Fact(
               /// Skip = "Not Yet Implemented"
        )]
        public void ClearingAStackMakesItEmpty()
        {
            //Arrange
            stack.Push(1);

            //Act
            stack.Clear();

            //Assert
            Assert.True(stack.IsEmpty);

        }

        [Fact(
               // Skip = "Not Yet Implemented"
        )]
        public void PeekingInAnEmptyStackFails()
        {
            bool success;

            stack.Peek(out success);

            Assert.False(success);
        }

        [Fact(
               // Skip = "Not Yet Implemented"
        )]
        public void PeekingInAnNonEmptyStackReturnsLastItemPushed()
        {
            //Arrange
            int item=10;
            bool success;
            stack.Push(item);

            //ACT
            int value = stack.Peek(out success);

            //Assert
            Assert.True(success);
            Assert.Equal(item, value);
        }

        [Fact]
        public void PopShouldPopItemsInLastInFirstOutOrder()
        {
            bool checkSuccess;
            int[] values = { 5, 10, 6 };
            foreach(var item in values)
            {
                stack.Push(item);
            }
            for(var i=0; i<values.Length; i++)
            {
                int value = stack.Pop(out checkSuccess);
                Assert.Equal(values[values.Length-1-i], value);
                Assert.True(checkSuccess);
            }
            

            
        }




    }
}