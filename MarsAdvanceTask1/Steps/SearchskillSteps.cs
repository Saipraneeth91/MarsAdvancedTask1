using MarsAdvancedTask1.Pages.Components;
using MarsAdvancedTask1.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsAdvancedTask1.TestModel;
using OpenQA.Selenium;
using MongoDB.Bson;
using MarsAdvancedTask1.Helpers;

namespace MarsAdvancedTask1.Steps
{
    public class SearchSkillSteps : DriverFactory
    {
        private Searchskillpage searchskillpage;
        private SearchskillAssert searchSkillAssert;
        public SearchSkillSteps(IWebDriver driver)
        {
            searchskillpage = new Searchskillpage(driver);
            searchSkillAssert = new SearchskillAssert(driver);
        }
        public void SearchSkillByAllCategoriesSteps(SearchskillCategoryModel searchskilldata)
        {
            foreach (var SearchskillCategoryrecord in searchskilldata.SearchskillRecords)
            {
                searchskillpage.SearchskillbyCategories(SearchskillCategoryrecord);
                searchSkillAssert.VerifySearchSkillByAllCategories(SearchskillCategoryrecord.Category);
            }
        }
        public void SearchSkillBySubCategoriesSteps(SearchskillsubcategoryModel searchsubskilldata)
        {
            foreach (var SearchsubskillCategoryrecord in searchsubskilldata.SearchsubskillRecords)
            {
                searchskillpage.Searchskillbysubcategories(SearchsubskillCategoryrecord);
                searchSkillAssert.VerifySearchSkillBySubCategories(SearchsubskillCategoryrecord.Category, SearchsubskillCategoryrecord.SubCategory);
            }
        }
        public void SearchSkillByFilterSteps(SearchskillFilterModel searchfilter)
        {

            foreach (var SearchSkillFilterrecord in searchfilter.Searchskillfilter)
            {
                searchskillpage.Searchskillbyfilter(SearchSkillFilterrecord);
                searchSkillAssert.VerifySearchSkillByFilter(SearchSkillFilterrecord.filterOption);
            }
        }
    }

}