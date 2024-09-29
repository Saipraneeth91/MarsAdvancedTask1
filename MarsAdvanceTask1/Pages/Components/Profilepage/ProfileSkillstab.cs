using MarsAdvancedTask1.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTask1.Pages.Components.Profilepage
{
    public class Profileskillstab : DriverFactory
    {
        private ElementUtil eleUtil;
        private readonly IWebDriver driver;
        public Profileskillstab(IWebDriver driver)
        {
            eleUtil = new ElementUtil(driver);
            this.driver = driver;
         
        }
        private readonly By skillssection = By.XPath("//a[text()='Skills']");
        private By skillsTextbox = By.XPath("//input[@type='text'][@placeholder='Add Skill']");
        private By skillLevelOption = By.Name("level");
        private By addSkillButton = By.XPath("//div[@class='ui teal button']");
        private By editNewSkillButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i");
        private By addskillbutt = By.XPath("//input[@value='Add']");
        private By editskilltextbox = By.XPath("//input[@placeholder='Add Skill']");
        private By editSkillLevel = By.Name("level");
        private By updateSkillButton = By.XPath("//input[@value='Update']");
        private By deleteSkillButton = By.XPath("//i[@class='remove icon']");
        private readonly By deletelastskill = By.XPath("//th[text()='Skill']/ancestor::thead/following-sibling::tbody[last()]/tr[1]/td/span[2]");
        private readonly By logout = By.XPath("//button[text()='Sign Out']");
        public ReadOnlyCollection<IWebElement> rows => driver.FindElements(By.XPath("//div[@data-tab='second']/div/div[2]/div/table[@class='ui fixed table']/tbody"));
        public void RenderSkillButton()
        {

            eleUtil.getElement(addSkillButton);
        }
        public void RenderAddSkillComponents()
        {
            try
            {
                eleUtil.getElement(addSkillButton);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void AddSkills(string skills, string skillLevel)
        {
            RenderSkillButton();
            Wait.WaitToBeClickable(driver, addSkillButton, Wait.LONG_DEFAULT_WAIT);
            eleUtil.doClick(addSkillButton);
            RenderAddSkillComponents();
            eleUtil.doSendKeys(skillsTextbox, skills);
            Wait.WaitToBeVisible(driver, skillLevelOption, Wait.LONG_DEFAULT_WAIT);
            eleUtil.doSendKeys(skillLevelOption, skillLevel);
            eleUtil.doClick(skillLevelOption);
            Wait.WaitToBeVisible(driver, addskillbutt, Wait.LONG_DEFAULT_WAIT);
            eleUtil.doClick(addskillbutt);
            Thread.Sleep(2000);
           

        }
        public void RenderEditIconComponent()
        {
            try
            {
                eleUtil.getElement(editNewSkillButton);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void RenderEditSkillComponents()
        {
            try
            {
                eleUtil.getElement(editskilltextbox);
                eleUtil.getElement(editSkillLevel);
                eleUtil.getElement(updateSkillButton);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void EditSkill(string skills, string skillLevel)
        {
            RenderEditIconComponent();
            Wait.WaitToBeClickable(driver, editNewSkillButton, Wait.LONG_DEFAULT_WAIT);
            eleUtil.doClick(editNewSkillButton);
            RenderEditSkillComponents();
            Wait.WaitToBeVisible(driver, editskilltextbox, Wait.LONG_DEFAULT_WAIT);
            eleUtil.doClear(editskilltextbox);
            Wait.WaitToBeVisible(driver, skillsTextbox, Wait.LONG_DEFAULT_WAIT);
            eleUtil.doSendKeys(skillsTextbox, skills);
            Wait.WaitToBeClickable(driver, editSkillLevel, Wait.LONG_DEFAULT_WAIT);
            eleUtil.doClick(editSkillLevel);
            eleUtil.doSendKeys(skillLevelOption, skillLevel);
            eleUtil.doClick(updateSkillButton);
            Thread.Sleep(2000);
        }


        public void RenderDeleteIconComponent()
        {
            try
            {
                eleUtil.getElement(deleteSkillButton);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void DeleteSkill(string skills, string skillLevel)
        {
            RenderDeleteIconComponent();
            eleUtil.doClick(deleteSkillButton);

        }
        public void DeleteSkillrecord()
        {
            RenderDeleteIconComponent();
            eleUtil.doClick(deleteSkillButton);
            Thread.Sleep(1000);
        }

        public void ClearSkills()
        {
            Wait.WaitToBeClickable(driver, skillssection, Wait.LONG_DEFAULT_WAIT);
            eleUtil.doClick(skillssection);
            int totalrows = rows.Count;
            Console.WriteLine(totalrows);
            for (int i = 0; i < totalrows; i = i + 1)
            {
                Wait.WaitToBeClickable(driver, deletelastskill, Wait.LONG_DEFAULT_WAIT);
                // click on delete icon
                eleUtil.doClick(deletelastskill);
            }
            eleUtil.doClick(logout);
        }
        public void DeleteSkill(string Skillname)
        {
            // click to navigate to skill section 
            eleUtil.doClick(skillssection);
            // delete skill by skill name passed
            By deletebyskill = By.XPath("//td[text()='" + Skillname + "']/following-sibling::td/span[@class='button'][2]");
            Wait.WaitToBeClickable(driver, deletebyskill, Wait.MEDIUM_DEFAULT_WAIT);
            eleUtil.doClick(deletebyskill);
            //Thread.Sleep(1000);
        }
    }

}