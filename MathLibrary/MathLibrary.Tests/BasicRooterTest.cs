using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MathLibrary.Tests
{
    [TestClass]
    public class BasicRooterTest
    {


        [TestMethod]
        public void Basic_Rooter_Test()
        {


            // Create an instance to test:
            Rooter rooter = new Rooter();
            // Define a test input and output value:
            double expectedResult = 2.0;
            double input = expectedResult * expectedResult;
            // Run the method under test:
            double actualResult = rooter.SquareRoot(input);
            // Verify the result:
            Assert.AreEqual(expectedResult, actualResult, delta: expectedResult / 100);
        }


        [TestMethod]
        public void Rooter_Value_Range_Test()
        {
            // Create an instance to test.
            Rooter rooter = new Rooter();

            // Try a range of values.
            for (double expected = 1e-8; expected < 1e+8; expected *= 3.2)
            {
                RooterOneValue(rooter, expected);
            }
        }

        private void RooterOneValue(Rooter rooter, double expectedResult)
        {
            double input = expectedResult * expectedResult;
            double actualResult = rooter.SquareRoot(input);
            Assert.AreEqual(expectedResult, actualResult, delta: expectedResult / 1000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RooterTestNegativeInputx()
        {
            Rooter rooter = new Rooter();
            rooter.SquareRoot(-10);

        }



    }


}
