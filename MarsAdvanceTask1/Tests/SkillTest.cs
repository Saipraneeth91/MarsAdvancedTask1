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
    public class Skilltest : DriverFactory
    {
        private LoginSteps loginsteps;
        private Profiletabsmenu profiletabmenu;
        private SkillSteps skillsteps;
        private LoginModel logindata;
        private SkillModel skilldata;
        private SkillModel editSkillData;

        [SetUp]
        public void initialise()
        {
            // Initialize page objects
            loginsteps = new LoginSteps(driver);
            profiletabmenu = new Profiletabsmenu(driver);
           

            // Load login data from JSON file
            string validLoginPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "logindata.json");
            logindata = JsonHelper.LoadData<LoginModel>(validLoginPath);

            // Load skill data from JSON file
            string validSkillPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "AddskillData.json");
            skilldata = JsonHelper.LoadData<SkillModel>(validSkillPath);
            string editSkillPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "EditSkillData.json");
            editSkillData = JsonHelper.LoadData<SkillModel>(editSkillPath);

            // Pass login data and skill data to skillSteps
            skillsteps = new SkillSteps(skilldata);
        
        }

        [Test]
        public void TestAddSkill()
        {
            // Perform login
            loginsteps.doLogin(logindata.ValidLogin); 
            profiletabmenu.ClickSkillsTab();
            // Add skill using the loaded data
            skillsteps.AddSkillSteps();
        }
        [Test]
        public void EditSkill()
        {
            // Perform login
            loginsteps.doLogin(logindata.ValidLogin); 
            profiletabmenu.ClickSkillsTab();
            // Add skill using the loaded data
            skillsteps = new SkillSteps(editSkillData);
            skillsteps.EditSkillSteps();
        }
        [Test]
        public void DeleteSkill()
        {
            // Perform login
            loginsteps.doLogin(logindata.ValidLogin); 
            profiletabmenu.ClickSkillsTab();
            // Add skill using the loaded data
            skillsteps.DeleteSkillSteps();
        }
        [TearDown]
        public void teardown()
        {
            skillsteps.TearDown();
        }
    }
}