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
    public class Profilelanguagetab :DriverFactory
    {
          private ElementUtil eleUtil;
          
         public Profilelanguagetab(IWebDriver driver)
        {
            eleUtil = new ElementUtil(driver);
        }
        //By locators
        private readonly By addnewbutton = By.XPath("//div[text()='Add New']");
        private readonly By languagefield = By.XPath("//input[@placeholder='Add Language']");
        private readonly By languagelevel = By.Name("level");
        private readonly By addlangbutton = By.XPath("//input[@value='Add']");
        private readonly By languagerecord = By.XPath("(//div[text()='Add New']/ancestor::thead/following-sibling::tbody[last()]/tr/td)[1]");
        private readonly By editicon = By.XPath("//tbody[(1)]/tr[1]/td[3]/span[1]/i[1]");
        private readonly By updatebutton = By.XPath("//input[@value='Update']");
        private readonly By lastrecordedit = By.XPath("//tbody[last()]/tr[1]/td[3]/span[1]/i[1]");
        private readonly By deletelanguageicon = By.XPath("//i[@class='remove icon']");
        private readonly By logout = By.XPath("//button[text()='Sign Out']");
        public ReadOnlyCollection<IWebElement> rows => driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody"));

        public void RenderLanguage()
            {
            eleUtil.getElement(addnewbutton);
                
            }
            public void RenderAddLanguage()
            {
                try
                {
                   eleUtil.getElement(languagefield);
                   eleUtil.getElement(languagelevel);
                   eleUtil.getElement(addlangbutton);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            public void AddLanguage(string language, string level)
            {
              RenderLanguage();
            Wait.WaitToBeClickable(driver, addnewbutton, Wait.LONG_DEFAULT_WAIT);
            // click on add new button
            eleUtil.doClick(addnewbutton);
            // Enter Language
            Wait.WaitToBeClickable(driver, languagefield, Wait.LONG_DEFAULT_WAIT);
            eleUtil.doSendKeys(languagefield, language);
            // Enter Language level
            Wait.WaitToBeClickable(driver, languagelevel, Wait.LONG_DEFAULT_WAIT);
            eleUtil.doSendKeys(languagelevel, level);
            // Click language level
            Wait.WaitToBeClickable(driver, languagelevel, Wait.LONG_DEFAULT_WAIT);
            eleUtil.doClick(languagelevel);
            // Click add button
            eleUtil.doClick(addlangbutton);
            
        }
             public void RenderEditIconComponent()
            {
                try
                {
                eleUtil.getElement(editicon);
            }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            public void RenderEditLangComponents()
            {
                try
                {
                eleUtil.getElement(languagelevel);
                eleUtil.getElement(languagelevel);
                eleUtil.getElement(updatebutton);
            }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            public void EditLanguage(string newlanguage, string newlanguagelevel)
            {
            
            RenderEditIconComponent();
            RenderEditLangComponents();
            Wait.WaitToBeClickable(driver, editicon, Wait.LONG_DEFAULT_WAIT);
            eleUtil.doClick(editicon);
            eleUtil.doClick(languagefield);
            eleUtil.doClear(languagefield);
            eleUtil.doSendKeys(languagefield, newlanguage);
            eleUtil.doClick(languagelevel);
            eleUtil.doSendKeys(languagelevel, newlanguagelevel);
            eleUtil.doClick(updatebutton);
            Thread.Sleep(2000);
        }
            public void RenderDeleteIconComponent()
            {
                try
                {
                   eleUtil.getElement(deletelanguageicon);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            public void DeleteLanguage(string language)
            {
            RenderDeleteIconComponent();
            By deleteLanguage = By.XPath("//td[text()='" + language + "']/following-sibling::td/span[@class='button'][2]");
            // click on delete icon of language passed
            Wait.WaitToBeClickable(driver, deleteLanguage, Wait.MEDIUM_DEFAULT_WAIT);
            eleUtil.doClick(deleteLanguage);
            Thread.Sleep(2000);
        }
        public void DeleteLanguagedetails()
        {
           
            Wait.WaitToBeVisible(driver, deletelanguageicon, Wait.LONG_DEFAULT_WAIT);
            eleUtil.doClick(deletelanguageicon);
            Thread.Sleep(1000);
        }
        public void ClearLanguage()
        {
            int totalrows = rows.Count;
            Console.WriteLine(totalrows);

            for (int i = 0; i < totalrows; i = i + 1)
            {
                Wait.WaitToBeVisible(driver, deletelanguageicon, Wait.MEDIUM_DEFAULT_WAIT);
                // click on delete icon
                eleUtil.doClick(deletelanguageicon);
                Thread.Sleep(2000);
            }
            
        }

    }
    }

