using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunNotePad02
{
    class Program
    {
        private const string LogFileName = @"C:\Temp\Appium\TestLog.txt";

        static void Main(string[] args)
        {

            // This script demonstrates how to automatically start 
            // the Appium WinDrivers
            var appiumLocalService = new AppiumServiceBuilder().UsingPort(4723)
                .WithLogFile(new FileInfo(LogFileName)).Build();
            appiumLocalService.Start();

            AppiumOptions ao = new AppiumOptions();
            ao.AddAdditionalCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");

            WindowsDriver<WindowsElement> session = new WindowsDriver<WindowsElement>(appiumLocalService, ao);

            session.Quit();

            }
    }
}
