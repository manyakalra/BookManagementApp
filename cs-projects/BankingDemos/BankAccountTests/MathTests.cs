using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountTests
{
    //[TestClass]
    public class MathTests
    {
        [TestMethod]
        public void PlusTest()
        {
            int x=20, y=30;
            int result=Math.Plus(x,y);
            if (result != x + y)
                Assert.Fail("Plus fails to sum number correctly");
        }

        

        [TestMethod]
        public void MinusTest()
        {
            int x = 20, y = 30;
            int result = Math.Minus(x, y);
            
            Assert.IsTrue(result == x - y);
        }

        [TestMethod]
        public void MultiplyTest()
        {
            int x = 20, y = 30;
            int result = Math.Multiply(x, y);

            Assert.AreEqual(x*y, result);

            

        }

        [TestMethod]
        public void DivideTest()
        {
            int x = 20, y = 3;
            int result = Math.Divide(x, y);

            Assert.AreEqual(x / y, result);
        }

    }
}
