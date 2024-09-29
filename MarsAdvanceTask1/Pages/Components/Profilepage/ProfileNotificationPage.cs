using MarsAdvancedTask1.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTask1.Pages.Components.Profilepage
{
    public class ProfileNotificationPage : DriverFactory
        {
    private ElementUtil eleUtil;
        public ProfileNotificationPage(IWebDriver driver)
        {
            eleUtil= new ElementUtil(driver);
        }
        //By locators
        private By  dashboard = By.XPath("//a[normalize-space()='Dashboard']");
        private By  selectAll = By.XPath(" //i[@class='mouse pointer icon']");
        private By  unSelectAll = By.XPath("//div[@data-tooltip='Unselect all']");
        private By  selectCheckBoxIcon = By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[1]/div/div/div[3]/input");
        private By  markasRead = By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[4]/i");
        private By  deleteIcon = By.XPath("//i[@class='trash icon']");
       public bool SelectAllNotification()
        {
                RenderSelectNotification();
                eleUtil.doClick(selectAll);
                return true;

        }
        public bool UnSelectAllNotification()
            {
              
                RenderSelectNotification();
                eleUtil.doClick(selectAll);   
                RenderUnselectNotification();
                eleUtil.doClick(unSelectAll);
                 return true;

        }
            public void ClickDashboard()
            {
               eleUtil.doClick(dashboard);

            }
            public void DeleteNotification()
            {
                RenderSelectCheckBox();
                eleUtil.doClick(selectCheckBoxIcon);
            Wait.WaitToBeClickable(driver, deleteIcon, Wait.MEDIUM_DEFAULT_WAIT);
            RenderReadDeleteNotification();
                eleUtil.doClick(deleteIcon);
             Thread.Sleep(1000);
            }
            public void MarkAsReadNotification()
            {
                RenderSelectNotification();
                eleUtil.doClick(selectAll);
            RenderReadDeleteNotification();
                eleUtil.doClick(markasRead);
        }
         public void RenderSelectNotification()
            {
                try
                {
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            public void RenderUnselectNotification()
            {
                try
                {
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            public void RenderSelectCheckBox()
            {
            eleUtil.getElement(selectCheckBoxIcon);
            }
            public void RenderReadDeleteNotification()
            {
               eleUtil.getElement(deleteIcon);
        }

        }
    }
