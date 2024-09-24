using AventStack.ExtentReports;
using MarsAdvancedTask1.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTask1.Helpers
{
    public class NotificationAssert
    {
        By notificationbox =By.XPath("//div[@class='ns-box-inner']");
        private ElementUtil eleutil;
        public NotificationAssert(IWebDriver driver)
        {
            eleutil = new ElementUtil(driver);
        }
        public void NotificationsAssert()
        {
             string Actualtext = eleutil.getText(notificationbox);
             string Expectedtext= "Notification updated";
            Assert.That(Actualtext, Is.EqualTo(Expectedtext));
          
        }
        public static void NotificationAssertSelectAll(bool clicked)
        {
            Assert.That(clicked, Is.True);
            Console.WriteLine("Select All Clicked", clicked);
        }
        public static void NotificationAssertUnSelectAll(bool clicked)
        {
            Assert.That(clicked, Is.True);
            Console.WriteLine("UnSelect All Clicked", clicked);

        }
       
    }
}
 