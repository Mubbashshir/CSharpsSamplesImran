using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace NetLecture1.StepDefs
{
    [Binding]
    public class BBHomeSteps : BaseSteps
    {
        private readonly ScenarioContext _context;
        //driver is already registered with container in SetupWebDriver class
        //Here we are only injecting it through constructor
        public BBHomeSteps(IWebDriver driver, ScenarioContext context) : base(driver)
        {
            _context = context;
        }

        [Given(@"the user has launched the BBCHome page")]
        public void GivenTheUserHasLaunchedTheBBCHomePage()
        {
            Driver.Navigate().GoToUrl("https://www.bbc.co.uk");
        }

        [When(@"the user enters the BBC new employee details")]
        public void WhenTheUserEntersTheBBCNewEmployeeDetails(Table table)
        {
            var name = table.Rows[0]["Name"];
            var age = table.Rows[0]["Age"];
            var phone = table.Rows[0]["Phone"];
            var email = table.Rows[0]["Email"];

            //the line below will add a new employee - just for demo and not funcational
            //employeePageObject.addNewEmployee(name, age, phone,email);
            _context["EmpDetails"] = table;
        }

        [Then(@"emplyee details can be seen at the employee view page")]
        public void ThenEmplyeeDetailsCanBeSeenAtTheEmployeeViewPage()
        {

            Table table = _context.Get<Table>("EmpDetails");
            var name = table.Rows[0]["Name"];
            var age = table.Rows[0]["Age"];
            var phone = table.Rows[0]["Phone"];
            var email = table.Rows[0]["Email"];
            //employeePageObject.validateEmployee(name, age, phone,email);
        }
    }
}
