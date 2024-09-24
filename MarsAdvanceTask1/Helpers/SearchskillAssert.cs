using MarsAdvancedTask1.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTask1.Helpers
{
    public class SearchskillAssert
    {
        private ElementUtil eleutil;
        private By verifySkill = By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]/div[1]/a[2]");
        private By category = By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[1]/div/div[2]");
        private By subCategory = By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[2]/div/div[2]");
        private By filter = By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[3]/div/div[3]/div/div[2]");

        public SearchskillAssert(IWebDriver driver)
        {
            eleutil = new ElementUtil(driver);
        }

        public void VerifySearchSkillByAllCategories(string expectedCategory)
        {
            Thread.Sleep(2000);
            eleutil.doClick(verifySkill);
            string actualCategory = eleutil.getText(category);
            Assert.That(actualCategory, Is.EqualTo(expectedCategory), $"Expected category: '{expectedCategory}', but got: '{actualCategory}'.");
        }

        public void VerifySearchSkillBySubCategories(string expectedCategory, string expectedSubCategory)
        {
            Thread.Sleep(2000); 
            eleutil.doClick(verifySkill);
            Thread.Sleep(2000); 

            string actualCategory = eleutil.getText(category);
            string actualSubCategory = eleutil.getText(subCategory);

            Assert.That(actualCategory, Is.EqualTo(expectedCategory), $"Expected category: '{expectedCategory}', but got: '{actualCategory}'.");
            Assert.That(actualSubCategory, Is.EqualTo(expectedSubCategory), $"Expected subcategory: '{expectedSubCategory}', but got: '{actualSubCategory}'.");

            Console.WriteLine($"SearchSkill By Category & Subcategory Verified Successfully: {actualCategory} - {actualSubCategory}");
        }

        public void VerifySearchSkillByFilter(string expectedFilter)
        {
            Thread.Sleep(2000); 
            eleutil.doClick(verifySkill);
            Thread.Sleep(2000); 

            string actualFilter = eleutil.getText(filter);
            Assert.That(actualFilter, Is.EqualTo(expectedFilter), $"Expected filter: '{expectedFilter}', but got: '{actualFilter}'.");

            Console.WriteLine($"SearchSkill By Filter Verified Successfully: {actualFilter}");
        }
    }

}

