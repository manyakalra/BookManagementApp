using ConceptArchitect.Collections;
using Xunit;

namespace CollectionTests
{
    public class FixedStackSpecs
    {
        FixedStack stack;
        int size = 3;

        public FixedStackSpecs()
        {
            stack = new FixedStack(size);
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
            var stack = new FixedStack(10);
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
            bool success= stack.Pop();

            Assert.False(success);
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
            bool success = stack.Pop();

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
            int lastElement = stack.Pop();
            //Assert
            Assert.Equal(elementToPush, lastElement) ;
        }


        [Fact(
                Skip = "Not Yet Implemented"
        )]
        public void ClearingAStackMakesItEmpty()
        {
            AssertFailed();
        }

        [Fact(
                Skip = "Not Yet Implemented"
        )]
        public void PeekingInAnEmptyStackFails()
        {
            AssertFailed();
        }

        [Fact(
                Skip = "Not Yet Implemented"
        )]
        public void PeekingInAnNonEmptyStackReturnsLastItemPushed()
        {
            AssertFailed();
        }





    }
}