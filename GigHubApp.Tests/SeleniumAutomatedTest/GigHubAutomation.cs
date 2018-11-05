using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GigHub.AutomatedTest;

namespace GigHubApp.Tests.SeleniumAutomatedTest
{
    [TestClass]
    public class GigHubAutomation
    {
        [TestMethod]
        public void Admin_User_Can_LogIn()
        {

            var c = new GigHubAutomatedTest();

            c.StartApplication();

        }
    }
}
