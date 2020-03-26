using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace NetLecture1.Core
{
    [Binding]
    class SetupWebDriver
    {
        private IWebDriver _driver;
        private readonly IObjectContainer _container;
        private ScenarioContext _context { get; }

        public SetupWebDriver(IObjectContainer container, ScenarioContext scenarioContext)
        {
            _container = container;
            _context = _container.Resolve<ScenarioContext>();
        }

        [BeforeScenario]
        public void initialize()
        {
            _driver = getDriver("CHROME");
        }

        public IWebDriver getDriver(String requiredDriver)
        {
            switch (requiredDriver)
            {
                case "CHROME":
                    ChromeOptions options = new ChromeOptions();
                    _driver = new ChromeDriver(options);
                    _container.RegisterInstanceAs(_driver);
                    break;
            }

            return _driver;
        }
    }
}
