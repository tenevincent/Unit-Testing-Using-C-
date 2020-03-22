using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Library.Tests.VTE
{
    [TestClass]
    public class CalculatorTests
    {
        public TestContext TestContext { get; set; }

        private Calculator calculator;


        [TestInitialize]
        public void Initialize()
        {

        }

        [TestMethod]
        [TestCategory("Calculator")]
        [TestProperty("Test Group", "Security")]
        [Priority(1)]
        public void Divide_PositiveNumbers_ReturnsPositiveQuotient_1()
        {
            // Arrange
            int expected = 5;
            int numerator = 20;
            int denominator = 4;

            // Act
            int actual = Calculator.Divide(numerator, denominator);
            System.Threading.Thread.Sleep(1000);
            //Assert
            Assert.AreEqual(expected, actual);
            TestContext.WriteLine(TestContext.FullyQualifiedTestClassName);
            TestContext.WriteLine(TestContext.TestName);

        }

        [TestCleanup]
        public void CleanUp()
        {
            TestContext.WriteLine(TestContext.CurrentTestOutcome.ToString());
        }



        [TestMethod]      
        [TestCategory("Calculator")]
        [TestProperty("Test Group", "Security")]
        [Owner("Venkat")]
        [Priority(1)]
        public void Divide_PositiveNumeratorAndNegativeDenominator_ReturnsNegativeQuotient_2()
        {
            // Arrange
            int expected = -5;
            int numerator = 20;
            int denominator = -4;

             
            // Act
            int actual = Calculator.Divide(numerator, denominator);
            System.Threading.Thread.Sleep(400);
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Calculator")]
        [TestProperty("Test Group", "Performance")]
        [Owner("Venkat")]
        [Priority(2)]
        public void Divide_NegativeNumbers_ReturnsPositiveQuotient_3()
        {
            // Arrange
            int expected = 5;
            int numerator = -20;
            int denominator = -4;

            // Act
            int actual = Calculator.Divide(numerator, denominator);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Divide_DenominatorIsZero_ThorwsDivideByZeroException_4()
        {
            // Arrange
            int numerator = 20;
            int denominator = 0;

            // Act
            try
            {
                Calculator.Divide(numerator, denominator);
            }
            catch (DivideByZeroException ex)
            {
                Assert.AreEqual("Denominator cannot be ZERO", ex.Message);
                throw;
            }
        }


        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Divide_DenominatorIsZero_ThorwsDivideByZeroException_5()
        {
            // Arrange
            int numerator = 20;
            int denominator = 0;

            Assert.ThrowsException<DivideByZeroException>(() => {
                Calculator.Divide(numerator, denominator);

            });

            // Act
            try
            {
                Calculator.Divide(numerator, denominator);
            }
            catch (DivideByZeroException ex)
            {
                Assert.AreEqual("Denominator cannot be ZERO", ex.Message);
                throw;
            }
        }


        [TestMethod]
        public void IsPositive_PositiveNumber_ReturnsTrue_5()
        {

          

            PrivateType privateObject = new PrivateType(typeof(Calculator));
            bool actual = (bool)privateObject.InvokeStatic("IsPositive", -10);

            Assert.IsFalse(actual);
        }



        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                    "CalculatorSrc.csv",
                    "CalculatorSrc.csv", DataAccessMethod.Sequential)]
        public void Calculator_Add_Data_Source()
        {
          
            int param01 = int.Parse(TestContext.DataRow["FirstParameter"].ToString());
           int param02 = int.Parse(TestContext.DataRow["SecondParameter"].ToString());
            int expected = int.Parse(TestContext.DataRow["Result"].ToString());

            int actual = Calculator.Add(param01, param02);
            // Assert
            Assert.AreEqual(expected, actual);

        }



    }
}