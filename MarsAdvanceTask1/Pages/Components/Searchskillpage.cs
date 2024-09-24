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
    public class Searchskillpage : DriverFactory
    {
        private ElementUtil eleutil;
        public Searchskillpage(IWebDriver driver)
        {
            eleutil = new ElementUtil(driver);
        }
        private By searchSkillTextBox = By.XPath("//div[@class='ui secondary menu']//i[@class='search link icon']");
        private By searchbar = By.XPath("//i[@class='search link icon']");
        private By onlinefilter = By.XPath("//button[contains(text(),'Online')]");
        private By onsitefilter = By.XPath("//button[contains(text(),'Onsite')]");
        private By showallfilter = By.XPath("//button[contains(text(),'ShowAll')]");
        private By searchuserfilter = By.XPath("//input[@placeholder='Search user']");
        public void SearchskillbyCategories(SearchSkill skillcategory)
        {
            RenderSearchSkillbtn();
            RenderSearchSkillTextbox();
            eleutil.doClick(searchSkillTextBox);
            By categoryElement = By.XPath($"//a[@class='item category' and text()='{skillcategory.Category}']");
            eleutil.doClick(categoryElement);
            RenderSearchSkillbtn();
        }
        public void Searchskillbysubcategories(SearchSubSkill subskillcategory)
        {
            RenderSearchSkillbtn();
            eleutil.doClick(searchSkillTextBox);
            Thread.Sleep(2000);
            By categoryElement = By.XPath($"//a[@class='item category' and text()='{subskillcategory.Category}']");
            eleutil.doClick(categoryElement);
            Thread.Sleep(2000);
            By subCategoryElement = By.XPath($"//a[@class='item subcategory' and text()='{subskillcategory.SubCategory}']");
            Wait.WaitToBeClickable(driver, subCategoryElement, Wait.LONG_DEFAULT_WAIT);
            eleutil.doClick(subCategoryElement);
            RenderSearchSkillbtn();
        }
        public void Searchskillbyfilter(SearchSkillFilter skill)
        {
            RenderSearchSkillbtn();
            Thread.Sleep(1000);
            RenderSearchSkillTextbox();
            eleutil.doClick(searchSkillTextBox);
            By categoryElement = By.XPath($"//a[@class='item category' and text()='{skill.SkillCategory}']");
            Wait.WaitToBeClickable(driver, categoryElement, Wait.LONG_DEFAULT_WAIT);
            eleutil.doClick(categoryElement);
            Renderfilter();
            switch (skill.filterOption)
            {
                case "Online":
                    eleutil.doClick(onlinefilter);
                    break;
                case "OnSite":

                    eleutil.doClick(onsitefilter);
                    break;
                case "ShowAll":
                    eleutil.doClick(showallfilter);
                    Thread.Sleep(5000);
                    break;
            }
        }
        public void RenderSearchSkillbtn()
        {
            eleutil.getElement(searchbar);
        }

        public void RenderSearchSkillTextbox()
        {

            eleutil.getElement(searchbar);
        }
        public void Renderfilter()
        {

            eleutil.getElement(onlinefilter);
            eleutil.getElement(onsitefilter);
            eleutil.getElement(showallfilter);
        }
    }
}
