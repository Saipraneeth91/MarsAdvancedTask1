using MarsAdvancedTask1.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsAdvancedTask1.TestModel;
using OpenQA.Selenium;
using MarsAdvancedTask1.Pages.Components.Profilepage;
using MarsAdvancedTask1.Helpers;

namespace MarsAdvancedTask1.Steps
{
    public class UserDetailSteps : DriverFactory
    {
        private ProfileAboutuserPage userinfo;
        private UserdetailAssert userdetailassert;
        public UserDetailSteps(IWebDriver driver) // Pass login data to constructor
        {
            userinfo = new ProfileAboutuserPage(driver); // Initialize here
            userdetailassert = new UserdetailAssert(driver);
        }

        public void AddUserInfo(UserDetailmodel userdata)
        {

            foreach (var userInfo in userdata.UserDetails)
            {
                userinfo.EditAvailableTime(userInfo.availableTime);
                userdetailassert.EditUserDetailAssert();
                userinfo.EditAvailableHours(userInfo.availableHours);
                userinfo.EditEarntarget(userInfo.earnTarget);
               
            }
        }


    }
}