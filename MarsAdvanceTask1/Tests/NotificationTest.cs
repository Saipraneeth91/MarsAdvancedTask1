using MarsAdvancedTask1.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsAdvancedTask1.TestModel;
using MarsAdvancedTask1.Helpers;
namespace MarsAdvancedTask1.Tests
{
    [TestFixture]
    public class NotificationTest : DriverFactory
    {
        NotificationSteps notificationsteps;
        private LoginSteps loginSteps;
        private LoginModel logindata;
        [SetUp]
        public void initialise()
        {
            // Initialize page objects
            loginSteps = new LoginSteps(driver);
            notificationsteps = new NotificationSteps(driver);

            // Load login data from JSON file
            string validLoginPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "logindata.json");
            logindata = JsonHelper.LoadData<LoginModel>(validLoginPath);
        }
        [Test]
        public void SelectAll()
        {
            loginSteps.doLogin(logindata.ValidLogin);
            notificationsteps.notificationdashboard();
            notificationsteps.CheckSelectAllNotificationSteps();
        }
        [Test]
        public void UnSelectAll()
        {
            loginSteps.doLogin(logindata.ValidLogin);
            notificationsteps.notificationdashboard();
            notificationsteps.CheckUnSelectAllNotificationSteps();
        }
        [Test]
        public void MarkAsRead()
        {
            loginSteps.doLogin(logindata.ValidLogin);
            notificationsteps.notificationdashboard();
            notificationsteps.MarkAsReadSteps();
        }
        [Test]
        public void DeleteNotification()
        {
            loginSteps.doLogin(logindata.ValidLogin);
            notificationsteps.notificationdashboard();
            notificationsteps.DeleteNotificationSteps();
        }
    }
}
