using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Library;
using System.Diagnostics;

namespace Calculator.Library.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        [TestCategory("Calculator")]
        [TestProperty("Test Group", "Security")]
        [Priority(1)]
        public void Divide_PositiveNumbers_ReturnsPositiveQuotient()
        {
            // Arrange
            int expected = -5;
            int numerator = 20;
            int denominator = 4;

            // Act
            int actual = Calculator.Divide(numerator, denominator);
            System.Threading.Thread.Sleep(1000);
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Calculator")]
        [TestProperty("Test Group", "Security")]
        [Owner("Venkat")]
        [Priority(1)]
        public void Divide_PositiveNumeratorAndNegativeDenominator_ReturnsNegativeQuotient()
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
        [Priority(1)]
        public void Divide_NegativeNumbers_ReturnsPositiveQuotient()
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
    }
}