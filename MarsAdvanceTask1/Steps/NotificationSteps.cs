using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsAdvancedTask1.Helpers;
using MarsAdvancedTask1.Pages;
using MarsAdvancedTask1.Pages.Components;
using MarsAdvancedTask1.Pages.Components.Profilepage;
using OpenQA.Selenium;

namespace MarsAdvancedTask1.Steps
{
    public class NotificationSteps : DriverFactory
    {
        private ProfileNotificationPage notificationpage;
        private NotificationAssert notificationassert;
        public NotificationSteps(IWebDriver driver)
        {
            notificationpage = new ProfileNotificationPage(driver);
            notificationassert = new NotificationAssert(driver);
        }
        public void CheckSelectAllNotificationSteps()
        {
            bool isClicked = notificationpage.SelectAllNotification();
            NotificationAssert.NotificationAssertSelectAll(isClicked);
        }
        public void CheckUnSelectAllNotificationSteps()
        {
            bool isClicked = notificationpage.UnSelectAllNotification();
            NotificationAssert.NotificationAssertUnSelectAll(isClicked);
        }
        public void DeleteNotificationSteps()
        {
            notificationpage.DeleteNotification();
            notificationassert.NotificationsAssert();
        }
        public void MarkAsReadSteps()
        {
            notificationpage.MarkAsReadNotification();
            notificationassert.NotificationsAssert();
        }
        public void notificationdashboard()
        {
            notificationpage.ClickDashboard();
        }
    }
}
