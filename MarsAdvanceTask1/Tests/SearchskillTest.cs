using MarsAdvancedTask1.Helpers;
using MarsAdvancedTask1.Pages.Components;
using MarsAdvancedTask1.Steps;
using MarsAdvancedTask1.TestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTask1.Tests
{
  
        [TestFixture]
        public class Searchskilltest : DriverFactory
        {
        private SearchSkillSteps searchskillsteps;
        private LoginSteps loginsteps;
        private Searchskillpage searchskillpage;
        private LoginModel logindata;
        private SearchskillCategoryModel skilldata;
        private SearchskillsubcategoryModel subskilldata;
        private SearchskillFilterModel searchfilterdata;

        [SetUp]
        public void initialise()
        {
            // Initialize page objects
            loginsteps = new LoginSteps(driver);
            searchskillpage = new Searchskillpage(driver);

            // Load login data from JSON file
            string loginpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "logindata.json");
            logindata = JsonHelper.LoadData<LoginModel>(loginpath);

            // Load skill data from JSON file
            string validSkillPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "SearchskillCategory.json");
            skilldata = JsonHelper.LoadData<SearchskillCategoryModel>(validSkillPath);
            string validsubSkillPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "SearchskillSubCategory.json");
            subskilldata = JsonHelper.LoadData<SearchskillsubcategoryModel>(validsubSkillPath);
            string SearchFilterPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "SearchSkillFilter.json");
            searchfilterdata = JsonHelper.LoadData<SearchskillFilterModel>(SearchFilterPath);

            // Pass login data and skill data to skillSteps
            searchskillsteps = new SearchSkillSteps(driver);
        }
        [Test]
        public void SearchSkillCategory()
        {
            // Perform login
            loginsteps.doLogin(logindata.ValidLogin); // Ensure this method uses logindata correctly
            searchskillsteps.SearchSkillByAllCategoriesSteps(skilldata);

        }
        [Test]
        public void SearchSubskill()
        {
            // Perform login
            loginsteps.doLogin(logindata.ValidLogin); // Ensure this method uses logindata correctly
            searchskillsteps.SearchSkillBySubCategoriesSteps(subskilldata);

        }
        [Test]
        public void SearchSkillByFilters()
        {
            loginsteps.doLogin(logindata.ValidLogin);
            searchskillsteps.SearchSkillByFilterSteps(searchfilterdata);
        }

    }
    }


