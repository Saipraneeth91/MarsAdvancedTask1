using MarsAdvancedTask1.Helpers;
using MarsAdvancedTask1.Pages.Components;
using MarsAdvancedTask1.Pages.Components.Profilepage;
using MarsAdvancedTask1.Steps;
using MarsAdvancedTask1.TestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTask1.Tests
{

    [TestFixture]
    public class Shareskilltest : DriverFactory
    {
        private LoginSteps loginsteps;
        private Shareskillpage shareskillpage;
        private ShareskillSteps shareskillsteps;
        private LoginModel logindata;
        private ShareskillModel skilldata;

        [SetUp]
        public void initialise()
        {
            // Initialize page objects
            loginsteps = new LoginSteps(driver);
            shareskillpage = new Shareskillpage(driver);


            // Load login data from JSON file
            string loginpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "logindata.json");
            logindata = JsonHelper.LoadData<LoginModel>(loginpath);

            // Load skill data from JSON file
            string validSkillPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "ShareSkillData.json");
            skilldata = JsonHelper.LoadData<ShareskillModel>(validSkillPath);

            // Pass login data and skill data to skillSteps
            shareskillsteps = new ShareskillSteps(skilldata);
        }

        [Test]
        public void AddShareSkill()
        {
            // Perform login
            loginsteps.doLogin(logindata.ValidLogin); // Ensure this method uses logindata correctly
            shareskillsteps.AddShareskillInfo(skilldata);

        }
    }
}