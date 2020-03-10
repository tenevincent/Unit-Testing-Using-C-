using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Test
{
    [TestClass]
    public class UnitTest1
    {
        private TestContext _testContext;

        public TestContext TestContext
        {
            get
            {
                return _testContext;
            }
            set
            {
                _testContext = value;
            }
        }
        
        [TestMethod]
        [TestCategory("Demo"), TestCategory("Calculator")]
        [TestProperty("Test Group", "Performance")]
        [Owner("Pragim Technologies")]
        [Priority(2)]
        public void TestMethod1()
        {
        }

        [TestMethod]
        [TestProperty("Test Group", "Security")]
        [TestCategory("Demo")]
        [Priority(2)]
        public void TestMethod2()
        {
            System.Diagnostics.Debug.WriteLine("Debug : TM2 executed");
            TestContext.WriteLine("TestContext : TM2 executed");
        }
    }
}
