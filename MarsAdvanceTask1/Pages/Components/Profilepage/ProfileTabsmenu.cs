using MarsAdvancedTask1.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTask1.Pages.Components.Profilepage
{
    public class Profiletabsmenu : DriverFactory
    {   
        private ElementUtil eleUtil;
        public Profiletabsmenu(IWebDriver driver)
        {
            eleUtil= new ElementUtil(driver);
        }
       private By languagesTab = By.XPath("//a[text()='Languages']");
       private By skillsTab = By.XPath("//a[text()='Skills']");
      public void Renderprofiletabcomponents()
        {
            try
            {
                eleUtil.getElement(languagesTab);
                eleUtil.getElement(skillsTab);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void ClickSkillsTab()
        {
            Renderprofiletabcomponents();
            eleUtil.doClick(skillsTab);
        }
      
    }
}
   