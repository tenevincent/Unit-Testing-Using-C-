using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InitializationAndCleanup.Test
{
    [TestClass]
    public class TestInitializeAndTestCleanup
    {
        Rectangle rectangle;

        [TestInitialize]
        public void Setup()
        {
            rectangle = new Rectangle();
            rectangle.Width = 3;
            rectangle.Length = 4;
        }

        [TestCleanup]
        public void Cleanup()
        {
            rectangle = null;
        }
        
        [TestMethod]
        public void PerimeterTest()
        {
            double expected = 14;

            double actual = rectangle.Perimeter();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AreaTest()
        {
            double expected = 12;

            double actual = rectangle.Area();


      
            Assert.AreEqual(expected, actual);

            rectangle.Width = 2;
        }
    }
}
