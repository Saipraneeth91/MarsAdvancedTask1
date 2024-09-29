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
    public class ShareskillAssert : DriverFactory
    {
        private ElementUtil eleutil;
        private By titlefield = By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]");
        public ShareskillAssert(IWebDriver driver)
        {
            eleutil = new ElementUtil(driver);
        }
        public void AddShareSkillAssert(string expectedtitle)
        {
            string actualtitle = eleutil.getText(titlefield);
            Assert.That(actualtitle, Is.EqualTo(expectedtitle), $"Expected title: '{expectedtitle}', but got: '{actualtitle}'.");

        }
    }
}
 