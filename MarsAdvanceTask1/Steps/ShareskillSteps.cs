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
using MarsAdvancedTask1.Pages.Components;

namespace MarsAdvancedTask1.Steps
{
    public class ShareskillSteps : DriverFactory
    {
        private Shareskillpage shareskillpage;
        private ShareskillModel shareskilldata;
        private ShareskillAssert shareskillAssert;
        public ShareskillSteps(ShareskillModel shareskilldata) 
        {
            shareskillpage = new Shareskillpage(driver);
            shareskillAssert = new ShareskillAssert(driver);
            this.shareskilldata = shareskilldata;
        }

        public void AddShareskillInfo(ShareskillModel shareSkillData)
        {
            foreach (var shareskillRecord in shareSkillData.ShareskillRecords)
            {
                shareskillpage.Addshareskills(shareskillRecord);
                shareskillAssert.AddShareSkillAssert(shareskillRecord.Title);
            }
        }


    }
}