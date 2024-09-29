using MarsAdvancedTask1.TestModel;
using MarsAdvancedTask1.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTask1.Pages.Components
{
    public class Shareskillpage : DriverFactory
    {
        private ElementUtil eleUtil;
        public Shareskillpage(IWebDriver driver)
        {
            eleUtil = new ElementUtil(driver);
        }
        //By locators
        private  By shareSkillbutton = By.XPath("//a[(text()='Share Skill')]");
        private By titlefield = By.XPath("//input[@name='title']");
        private By descriptionfield = By.Name("description");
        private By categoryfield = By.Name("categoryId");
        private By subcategoryfield = By.Name("subcategoryId");
        private By tagsfield = By.CssSelector("input[placeholder='Add new tag']");
        private By hourlybasisservice = By.Name("serviceType");
        private By Oneoffservice = By.XPath("(//input[@name='serviceType'])[2]");
        private By locationTypeonsite = By.XPath("(//input[@name='locationType'])[1]");
        private By locationTypeonline = By.XPath("(//input[@name='locationType'])[2]");
        private By startDate = By.Name("startDate");
        private By endDate = By.Name("endDate");
        private By skillExchangefield = By.XPath("(//input[@class='ReactTags__tagInputField'])[2]");
        private By credit = By.Name("charge");
        private By saveButton = By.XPath("//input[@value='Save']");
        private By skillTrade = By.Name("skillTrades");
        private By active = By.Name("isActive");
        private By Save = By.XPath("//input[@value='Save']");
        public void RenderShareskillComponents()
        {
            try
            {
                eleUtil.getElement(shareSkillbutton);
                eleUtil.getElement(titlefield);
                eleUtil.getElement(descriptionfield);
                eleUtil.getElement(categoryfield);
                eleUtil.getElement(subcategoryfield);
                eleUtil.getElement(tagsfield);
                eleUtil.getElement(hourlybasisservice);
                eleUtil.getElement(Oneoffservice);
                eleUtil.getElement(locationTypeonsite);
                eleUtil.getElement(locationTypeonline);
                eleUtil.getElement(startDate);
                eleUtil.getElement(endDate);
                eleUtil.getElement(skillExchangefield);
                eleUtil.getElement(credit);
                eleUtil.getElement(active);
                eleUtil.getElement(saveButton);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void Addshareskills(ShareSkillInfo skillinfo)
        {
            RenderShareskillComponents();
            Wait.WaitToBeClickable(driver, shareSkillbutton, Wait.LONG_DEFAULT_WAIT);
            eleUtil.doClick(shareSkillbutton);
            Wait.WaitToBeVisible(driver, titlefield, Wait.LONG_DEFAULT_WAIT);
            eleUtil.doSendKeys(titlefield,skillinfo.Title);
            Wait.WaitToBeVisible(driver, descriptionfield, Wait.LONG_DEFAULT_WAIT);
            eleUtil.doSendKeys(descriptionfield,skillinfo.Description);
            Wait.WaitToBeVisible(driver, categoryfield, Wait.LONG_DEFAULT_WAIT);
            eleUtil.doClick(categoryfield);
            Wait.WaitToBeClickable(driver, categoryfield, Wait.LONG_DEFAULT_WAIT);
            eleUtil.doSendKeys(categoryfield,skillinfo.Category);
            Wait.WaitToBeClickable(driver, categoryfield, Wait.LONG_DEFAULT_WAIT);
            eleUtil.doClick(categoryfield);
            Wait.WaitToBeClickable(driver, categoryfield, Wait.LONG_DEFAULT_WAIT);
            eleUtil.doClick(subcategoryfield);
            Wait.WaitToBeVisible(driver, subcategoryfield, Wait.LONG_DEFAULT_WAIT);
            eleUtil.doSendKeys(subcategoryfield,skillinfo.SubCategory);
            Wait.WaitToBeClickable(driver, tagsfield, Wait.LONG_DEFAULT_WAIT);
            eleUtil.doClick(tagsfield);
            Wait.WaitToBeClickable(driver, tagsfield, Wait.LONG_DEFAULT_WAIT);
            eleUtil.doSendKeys(tagsfield,skillinfo.Tags);
            eleUtil.doSendKeys(tagsfield,"\n");
            Wait.WaitToBeClickable(driver, tagsfield, Wait.LONG_DEFAULT_WAIT);
            eleUtil.doClick(tagsfield);
            eleUtil.doClick(Oneoffservice);
            eleUtil.doClick(locationTypeonline);
            eleUtil.doClick(startDate);
            Wait.WaitToBeVisible(driver, startDate, Wait.LONG_DEFAULT_WAIT);
            eleUtil.doSendKeys(startDate, skillinfo.StartDate);
            Wait.WaitToBeClickable(driver, endDate, Wait.LONG_DEFAULT_WAIT);
            eleUtil.doClick(endDate);
            Wait.WaitToBeVisible(driver, startDate, Wait.LONG_DEFAULT_WAIT);
            eleUtil.doSendKeys(startDate, skillinfo.EndDate);
            eleUtil.doClick(skillTrade);
            Wait.WaitToBeClickable(driver, skillExchangefield, Wait.LONG_DEFAULT_WAIT);
            eleUtil.doClick(skillExchangefield);
            Wait.WaitToBeClickable(driver, skillExchangefield, Wait.LONG_DEFAULT_WAIT);
            eleUtil.doSendKeys(skillExchangefield,skillinfo.SkillExchange);
            Wait.WaitToBeVisible(driver, skillExchangefield, Wait.LONG_DEFAULT_WAIT);
            eleUtil.doSendKeys(skillExchangefield,"\n");
            eleUtil.doClick(skillExchangefield);
            eleUtil.doClick(saveButton);
        }
    }
}
           
     