using MarsAdvancedTask1.Helpers;
using MarsAdvancedTask1.Steps;
using MarsAdvancedTask1.TestModel;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTask1.Tests
{
    [TestFixture]
    public class LoginTest : DriverFactory // Inheriting DriverFactory to use its driver management
    {
        private LoginSteps loginSteps;
        private LoginModel logindata;

        [SetUp]
        public void Initialize()
        {
            // Initialize LoginSteps using the driver from DriverFactory
            loginSteps = new LoginSteps(driver);
            // Load login data from JSON file
            string validLoginPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "logindata.json");
            logindata = JsonHelper.LoadData<LoginModel>(validLoginPath);
        }
        [Test]
        public void Login()
        {
            // Perform the login steps
            loginSteps.doLogin(logindata.ValidLogin);
        }
    }

}
