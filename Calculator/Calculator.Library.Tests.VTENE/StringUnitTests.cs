using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace StringAssertTests
{
    [TestClass]
    public class StringUnitTests
    {
        [TestMethod]
        public void StartsWithTest()
        {
            StringAssert.StartsWith("Unit Testing Tutorial", "Unit");
        }

        [TestMethod]
        public void EndsWithTest()
        {
            StringAssert.EndsWith("Unit Testing Tutorial", "Tutorial");
        }

        [TestMethod]
        public void ContainsTest()
        {
            StringAssert.Contains("Unit Testing Tutorial", "Testing");
        }

        [TestMethod]
        public void MatchesTest()
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
            StringAssert.Matches("kudvenkat@gmail.com", regex, "Invalid Email Address");
        }
    }
}
