using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace AppiumGettingStarted.Tests
{
    [TestClass]
    public class AppiumGettingStartedUnitTest
    {
        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string WpfAppId = @"E:\DevGit\Unit-Testing\AppiumGettingStarted\AppiumGettingStarted\bin\Debug\AppiumGettingStarted.exe";
        protected static WindowsDriver<WindowsElement> session;



        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            if (session == null)
            {
                var options = new AppiumOptions();
                options.AddAdditionalCapability("app", WpfAppId);
                options.AddAdditionalCapability("deviceName", "WindowsPC");
                options.AddAdditionalCapability(capabilityName: "platformName", capabilityValue: "Windows");
                // options.AddAdditionalCapability(capabilityName: "ms:experimental-webdriver", capabilityValue: true);


                session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), options);
            }
        }

        [TestMethod]
        public void AddNameToTextBox()
        {
            var txtName = session.FindElementByAccessibilityId("txtName");
            txtName.SendKeys("Matteo");
            session.FindElementByAccessibilityId("sayHelloButton").Click();
            var txtResult = session.FindElementByAccessibilityId("txtResult");
            Assert.AreEqual(txtResult.Text, $"Hello {txtName.Text}");
        }





    }
}
