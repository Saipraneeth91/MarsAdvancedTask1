using MarsAdvancedTask1.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsAdvancedTask1.Pages;
using MarsAdvancedTask1.Pages.Components.Profilepage;
using MarsAdvancedTask1.TestModel;
using MarsAdvancedTask1.Helpers;

namespace MarsAdvancedTask1.Tests
{
    [TestFixture]
    public class LanguageTest : DriverFactory
    {
        private LoginSteps loginSteps;
        private Profiletabsmenu profiletab;
        private LanguageSteps langsteps;
        private LoginModel logindata;
        private LanguageModel langdata;


        [SetUp]
        public void initialise()
        {
            // Initialize page objects
            loginSteps = new LoginSteps(driver);
            profiletab = new Profiletabsmenu(driver);

            // Load login data from JSON file
            string validLoginPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "logindata.json");
            logindata = JsonHelper.LoadData<LoginModel>(validLoginPath);

            // Load language data from JSON file
            string validLanguagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "Addlangdata.json");
            langdata = JsonHelper.LoadData<LanguageModel>(validLanguagePath);

            // Pass login data and language data to LanguageSteps
            langsteps = new LanguageSteps(langdata);
        }

        [Test]
        public void AddLanguage()
        {
            // Perform login
            loginSteps.doLogin(logindata.ValidLogin);
            langsteps.AddLanguageSteps();

        }
        [Test]
        public void EditLanguage()
        {
            // Perform login
            loginSteps.doLogin(logindata.ValidLogin); // Ensure this method uses logindata correctly

            // Add language using the loaded data
            langsteps.EditLanguageSteps();
        }
        [Test]
        public void DeleteLanguage()
        {
            // Perform login
            loginSteps.doLogin(logindata.ValidLogin); // Ensure this method uses logindata correctly

            // Add language using the loaded data
            langsteps.DeleteLanguageSteps();
        }
        [TearDown]
        public void teardown()
        {
            langsteps.TearDown();
        }

    }
    }