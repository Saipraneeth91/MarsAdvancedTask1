     using MarsAdvancedTask1.TestModel;
using MarsAdvancedTask1.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V126.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTask1.Pages
{
    public class LoginPage : DriverFactory
    {
        private ElementUtil eleUtil;
        public LoginPage(IWebDriver driver)
        {
            eleUtil = new ElementUtil(driver);
        }
        //By Locators
        private readonly By signin = By.XPath("//a[contains(text(),'Sign In')]");
        private readonly By emailaddress = By.XPath("//input[@placeholder='Email address']");
        private readonly By password = By.XPath("//input[@placeholder='Password']");
        private readonly By login = By.XPath("//button[contains(text(),'Login')]");
        public void RenderLoginComponents()
        {
            try
            {
                eleUtil.getElement(signin);
                eleUtil.getElement(emailaddress);
                eleUtil.getElement(password);
                eleUtil.getElement(login);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void LoginActions(string email, string pwd)
        {
            eleUtil.doClick(signin);
            eleUtil.doSendKeys(emailaddress, email);
            eleUtil.doSendKeys(password, pwd);
            eleUtil.doClick(login);
        }

    }
}