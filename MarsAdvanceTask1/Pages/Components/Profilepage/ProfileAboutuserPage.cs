using MarsAdvancedTask1.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTask1.Pages.Components.Profilepage
{
    public class ProfileAboutuserPage : DriverFactory
    {
        private ElementUtil eleUtil;
        public ProfileAboutuserPage(IWebDriver driver)
        {
            eleUtil = new ElementUtil(driver);
        }
        //By locators
        private By editavailability = By.XPath("(//i[@class='right floated outline small write icon'])[1]");
        private By availability =By.XPath("//select[@name='availabiltyType']");
        private By edithours = By.XPath("(//i[@class='right floated outline small write icon'])[2]");
        private By hours =By.XPath("//select[@name='availabiltyHour']");
        private By editearntarget = By.XPath("(//i[@class='right floated outline small write icon'])[3]");
        private By earntarget = By.XPath("//select[@name='availabiltyTarget']");
        private By selectavailability = By.XPath("//select[@name='availabiltyType']");
        private By selecthours = By.XPath("(//i[@class='right floated outline small write icon'])[2]");
        private By selectearnTarget = By.XPath("(//i[@class='right floated outline small write icon'])[3]");
       public void RenderAboutuserDetails()
        {
            try
            {
                
                eleUtil.getElement(editavailability);
                eleUtil.getElement(edithours);
                eleUtil.getElement(editearntarget);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void RenderSelectEarnTarget()
        {
            try
            {
                eleUtil.getElement(selectearnTarget);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void EditAvailableTime(string time)
        {
            Wait.WaitToBeClickable(driver, editavailability, Wait.MEDIUM_DEFAULT_WAIT);
            eleUtil.doClick(editavailability);
            Wait.WaitToBeClickable(driver, availability, Wait.MEDIUM_DEFAULT_WAIT);
            eleUtil.doClick(availability);
            Wait.WaitToBeClickable(driver, availability, Wait.MEDIUM_DEFAULT_WAIT);
            eleUtil.doSendKeys(availability, time);
            Wait.WaitToBeClickable(driver, availability, Wait.MEDIUM_DEFAULT_WAIT);
            eleUtil.doClick(availability);
            Thread.Sleep(2000);
        }
        public void EditAvailableHours(string Hours)
        {
            Wait.WaitToBeClickable(driver, edithours, Wait.MEDIUM_DEFAULT_WAIT);
            eleUtil.doClick(edithours);
            Wait.WaitToBeClickable(driver, hours, Wait.MEDIUM_DEFAULT_WAIT);
            eleUtil.doClick(hours);
            Wait.WaitToBeClickable(driver, hours, Wait.MEDIUM_DEFAULT_WAIT);
            eleUtil.doSendKeys(hours, Hours);
            Wait.WaitToBeClickable(driver, edithours, Wait.MEDIUM_DEFAULT_WAIT);
            eleUtil.doClick(hours);
            Thread.Sleep(2000);
        }
        public void EditEarntarget(string Target)
        {
            RenderAboutuserDetails();
            eleUtil.doClick(editearntarget);
            RenderSelectEarnTarget();
            eleUtil.doClick(earntarget);
            Wait.WaitToBeVisible(driver, earntarget, Wait.MEDIUM_DEFAULT_WAIT);
            eleUtil.doSendKeys(earntarget, Target);
            Wait.WaitToBeClickable(driver, earntarget, Wait.MEDIUM_DEFAULT_WAIT);
            eleUtil.doClick(earntarget);
            Thread.Sleep(2000);
        }


}


}