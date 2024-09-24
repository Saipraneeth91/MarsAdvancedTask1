using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsAdvancedTask1.Utilities;

namespace MarsAdvancedTask1.Helpers
{
    public class LanguageAssert : DriverFactory
    {
        private By Actualmessage =By.XPath("//div[@class='ns-box-inner']");
        private ElementUtil eleutil;
        public LanguageAssert(IWebDriver driver)
        {
            eleutil = new ElementUtil(driver);
        }

        public void AddLanguageAssert(String language)
        {
            Thread.Sleep(1000);
            string actual = eleutil.getText(Actualmessage);
            string expected = language + " has been added to your languages";
            Assert.That(actual,Is.EqualTo(expected), $"Expected message: '{expected}', but got: '{actual}'");
        }
        public  void EditLanguageAssert(String language)
        {
            string actual = eleutil.getText(Actualmessage);
            string expected = language + " has been updated to your languages";
            Assert.That(actual, Is.EqualTo(expected), $"Expected message: '{expected}', but got: '{actual}'");
        }
        public  void DeleteLanguageAssert(String language)
        {
            string actual = eleutil.getText(Actualmessage);
            string expected = language + " has been deleted from your languages";
            Assert.That(actual, Is.EqualTo(expected), $"Expected message: '{expected}', but got: '{actual}'");
        }
    }
}
