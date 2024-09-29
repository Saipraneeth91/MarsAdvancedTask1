using MarsAdvancedTask1.Helpers;
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
    public class Userdetailtest : DriverFactory
    {
        private LoginSteps loginsteps;
        private LoginModel logindata;
        private UserDetailmodel userdata;
        private ProfileAboutuserPage aboutuser;
        private UserDetailSteps userdetsteps;

        [SetUp]
        public void initialise()
        {
            // Initialize page objects
            loginsteps = new LoginSteps(driver);
            aboutuser = new ProfileAboutuserPage(driver);
            userdetsteps = new UserDetailSteps(driver);


            // Load login data from JSON file
            string validLoginPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "logindata.json");
            logindata = JsonHelper.LoadData<LoginModel>(validLoginPath);

            // Load skill data from JSON file
            string validUserInfo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "AddUserData.json");
            userdata = JsonHelper.LoadData<UserDetailmodel>(validUserInfo);

            
        }

        [Test]
        public void AddUserdetail()
        {
            // Perform login
            loginsteps.doLogin(logindata.ValidLogin); // Ensure this method uses logindata correctly
            userdetsteps.AddUserInfo(userdata);

        }
    }
}