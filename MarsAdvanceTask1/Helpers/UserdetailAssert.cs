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
    public class UserdetailAssert : DriverFactory
    {
        private By Actualmessage = By.XPath("//div[@class='ns-box-inner']");
        private ElementUtil eleutil;
        public UserdetailAssert(IWebDriver driver)
        {
            eleutil = new ElementUtil(driver);
        }
        public void EditUserDetailAssert()
        {
            string actual = eleutil.getText(Actualmessage);
            string expected = "Availability updated";
            Thread.Sleep(2000);
            Assert.That(actual, Is.EqualTo(expected));

        }
    }
}