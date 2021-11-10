using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecFlow.DrivingDemo;
using System;
using TechTalk.SpecFlow;

namespace SpecFlow.DrivingDemoLib.Test.Features
{
    [Binding]
    public class DrivingAgeSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IDrivingRegulations _drivingRegulations;

        public DrivingAgeSteps(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
            _drivingRegulations = new DrivingRegulations();
        }



        [Given(@"The driver is (\d+) years old")]
        public void GivenTheDriverIsYearsOld(int age)
        {
            _scenarioContext["Person"] = new Person { FirstName = "John", Age = age };


        }
        
        [When(@"they live in (.*)")]
        public void WhenTheyLiveInSwitzerland(string countryName)
        {
            var country = Enum.Parse<Country>(countryName);
            var person = _scenarioContext["Person"] as Person;
            _scenarioContext["Result"] = _drivingRegulations.IsAllowedToDrive(person,country);
        }
        
        [Then(@"they are permitted to drive a car")]
        public void ThenTheyArePermittedToDriveACar()
        {
            var result = (bool)_scenarioContext["Result"];
            Assert.IsTrue(result);
        }

        [Then(@"they are not permitted to drive a car")]
        public void ThenTheyAreNotPermittedToDriveACar()
        {
            var result = (bool)_scenarioContext["Result"];
            Assert.IsFalse(result);
        }



    }
}
