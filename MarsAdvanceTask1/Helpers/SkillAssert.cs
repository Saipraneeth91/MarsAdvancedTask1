using MarsAdvancedTask1.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTask1.Helpers
{
    public class SkillAssert : DriverFactory
    {
        private By Actualmessage = By.XPath("//div[@class='ns-box-inner']");
        private ElementUtil eleutil;
        public SkillAssert(IWebDriver driver)
        {
            eleutil = new ElementUtil(driver);
        }

        public void AddSkillAssert(String skill)
        {
            Thread.Sleep(1000);
            string actual = eleutil.getText(Actualmessage);
            string expected = skill + " has been added to your skills";
            Assert.That(actual, Is.EqualTo(expected), $"Expected message: '{expected}', but got: '{actual}'");
        }
        public void EditSkillAssert(String skill)
        {
            string actual = eleutil.getText(Actualmessage);
            string expected = skill + " has been updated to your skills";
            Assert.That(actual, Is.EqualTo(expected), $"Expected message: '{expected}', but got: '{actual}'");
        }
        public void DeleteSkillAssert(String skill)
        {
            string actual = eleutil.getText(Actualmessage);
            string expected = skill + " has been deleted";
            Assert.That(actual, Is.EqualTo(expected), $"Expected message: '{expected}', but got: '{actual}'");
        }
    }
}


