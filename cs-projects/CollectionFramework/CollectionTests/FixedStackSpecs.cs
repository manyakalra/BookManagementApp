using Xunit;

namespace CollectionTests
{
    public class FixedStackSpecs
    {


        private void AssertFailed(string reason = "Not Yet Implemented")
        {
            Assert.True(false, reason);
        }

        [Fact(
                Skip = "Not Yet Implemented"
        )]
        public void StackShouldBeInitializedWithSize()
        {
            AssertFailed();
        }
        [Fact(
                Skip = "Not Yet Implemented"
        )]
        public void StackShouldBeInitiallyEmpty()
        {
            AssertFailed();
        }
        [Fact(
                Skip = "Not Yet Implemented"
        )]
        public void PushingAnItemToAnEmptyStackMakesItNonEmpty()
        {
            AssertFailed();
        }


        [Fact(
                Skip = "Not Yet Implemented"
        )]
        public void PushingItemsEqualsToTheSizeOfStackMakesItFull()
        {
            AssertFailed();
        }

        [Fact(
                Skip = "Not Yet Implemented"
        )]
        public void PushingAnItemToAFullStackFails()
        {
            AssertFailed();
        }

        [Fact(
                Skip = "Not Yet Implemented"
        )]
        public void PoppingAnItemFromAnEmptyStackShouldFail()
        {
            AssertFailed();
        }


        [Fact(
                Skip = "Not Yet Implemented"
        )]
        public void PoppingFromAFullStackMakesItNonFull()
        {
            AssertFailed();
        }

        [Fact(
                Skip = "Not Yet Implemented"
        )]
        public void PoppingReturnsTheLastItemPushed()
        {
            AssertFailed();
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