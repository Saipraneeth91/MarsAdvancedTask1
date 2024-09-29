using MarsAdvancedTask1.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsAdvancedTask1.TestModel;
using OpenQA.Selenium;

namespace MarsAdvancedTask1.Steps
{
    public class LoginSteps
    {
        LoginPage loginpage;
        public LoginSteps(IWebDriver driver)
        {
            loginpage = new LoginPage(driver);
        }
        public void doLogin(ValidLoginModel logindetails)
        {
            loginpage.LoginActions(logindetails.Emailaddress,logindetails.Password);
        }
    }
}