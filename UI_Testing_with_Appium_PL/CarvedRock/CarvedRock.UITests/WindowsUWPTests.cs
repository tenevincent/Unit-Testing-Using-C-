using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace CarvedRock.UITests
{
    [TestClass]
    [TestCategory("UWPAppUnitTesting")]
    public class WindowsUWPTests
    {
        static TestContext _testContext;

        [ClassInitialize]
        static public void Initialize(TestContext context)
        {
            _testContext = context;
        }


        [TestMethod]
        public void CheckMasterDetailAndBack()
        {
            WindowsDriver<WindowsElement> driver = this.StartApp();
            // tap on second item
            WindowsElement el1 = driver.FindElementByName("Second item");

            this.CreateScreenshot(driver, _testContext);
            el1.Click();
            WindowsElement el2 = driver.FindElementByAccessibilityId("ItemText");
            Assert.IsTrue(el2.Text == "Second item");

            this.CreateScreenshot(driver, _testContext);
            WindowsElement backButton = driver.FindElementByAccessibilityId("Back");
            backButton.Click();

            this.CreateScreenshot(driver, _testContext);
            WindowsElement el3 = driver.FindElementByName("Fourth item");
            Assert.IsTrue(el3 != null);

            this.CreateScreenshot(driver, _testContext);
            driver.Close();

        }

        [TestMethod]
        public void AddNewItem()
        {
            WindowsDriver<WindowsElement> driver = this.StartApp();
            // tap on second item
            WindowsElement el1 = driver.FindElementByAccessibilityId("Add");
            TouchAction a = new TouchAction(driver);
            a.Tap(el1);
            el1.Click();
            WindowsElement elItemText = driver.FindElementByAccessibilityId("ItemText");
            elItemText.Clear();
            elItemText.SendKeys("This is a new Item");

            WindowsElement elItemDetail = driver.FindElementByAccessibilityId("ItemDescription");
            elItemDetail.Clear();
            elItemDetail.SendKeys("These are the details");

            WindowsElement elSave = driver.FindElementByAccessibilityId("Save");
            elSave.Click();

            this.WaitForProgressbarToDisapear(driver);

            RemoteTouchScreen touchScreen = new RemoteTouchScreen(driver);
            Boolean found = false;
            int maxretries = 5;
            int count = 0;
            while (!found && count++ < maxretries)
            {
                // Good value typically goes around 160 - 200 pixels with diminishing delta on the bigger values
                touchScreen.Flick(0, 180);
                try
                {
                    WindowsElement el3 = driver.FindElementByName("This is a new Item");
                    found = el3 != null;
                }
                catch (Exception)
                { }
            }
            Assert.IsTrue(found);


            driver.Close();

        }

        private void WaitForProgressbarToDisapear(WindowsDriver<WindowsElement> driver)
        {
            DefaultWait<WindowsDriver<WindowsElement>> wait = new DefaultWait<WindowsDriver<WindowsElement>>(driver)
            {
                Timeout = TimeSpan.FromSeconds(60),
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Until(d => d.FindElementByName("Second item"));
        }

        private void FlickUp(WindowsDriver<WindowsElement> driver, AppiumWebElement element)
        {
            PointerInputDevice input = new PointerInputDevice(PointerKind.Touch);
            ActionSequence FlickUp = new ActionSequence(input);
            FlickUp.AddAction(input.CreatePointerMove(element, 0, 0, TimeSpan.Zero));
            FlickUp.AddAction(input.CreatePointerDown(MouseButton.Left));
            FlickUp.AddAction(input.CreatePointerMove(element, 0, -600, TimeSpan.FromMilliseconds(200)));
            FlickUp.AddAction(input.CreatePointerUp(MouseButton.Left));
            driver.PerformActions(new List<ActionSequence>() { FlickUp });
        }
        private WindowsDriver<WindowsElement> StartApp()
        {
            AppiumOptions capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability(MobileCapabilityType.App, "8b831c56-bc54-4a8b-af94-a448f80118e7_xk6svzwph5e4g!App");
            capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Windows");
            capabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, "WindowsPC");

            AppiumLocalService _appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().Build();
            _appiumLocalService.Start();
            WindowsDriver<WindowsElement> driver = new WindowsDriver<WindowsElement>(_appiumLocalService, capabilities);
            return driver;
        }

        public void CreateScreenshot(WindowsDriver<WindowsElement> driver, TestContext ctx)
        {
            Screenshot screenshot = driver.GetScreenshot();
            string fileName = Guid.NewGuid().ToString() + ".png";
            screenshot.SaveAsFile(fileName);
            ctx.AddResultFile(fileName);
        }
    }
}

