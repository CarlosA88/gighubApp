using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GigHub.AutomatedTest
{
    //[TestClass]
    public class GigHubAutomatedTest
    {
        //[TestMethod]
        [Fact]
        public void StartApplication()
        {

            using(IWebDriver googleDriver = new ChromeDriver())
            {

                // 1. Maximize the browser
                googleDriver.Manage().Window.Maximize();

                googleDriver.Navigate().GoToUrl("http://gighubap.azurewebsites.net/Gigs/Create");

            }

        }
    }
}
