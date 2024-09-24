using MarsAdvancedTask1.TestModel;
using MarsAdvancedTask1.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsAdvancedTask1.TestModel;
using OpenQA.Selenium;
using MarsAdvancedTask1.Helpers;
using MarsAdvancedTask1.Pages.Components.Profilepage;
namespace MarsAdvancedTask1.Steps
{
    public class SkillSteps : DriverFactory
    {
        private LoginPage loginPage;
        private LoginModel logindata;
        private SkillModel skilldata;
        private Profileskillstab profileTabSkillObj;
        private SkillAssert skillassert;
        private List<string> dataUsedInTest;

        public SkillSteps(SkillModel skilldata) // Pass login data to constructor
        {
            profileTabSkillObj = new Profileskillstab(driver); // Initialize here
            skillassert = new SkillAssert(driver);
            dataUsedInTest = new List<string>();
            this.skilldata = skilldata;
            
        }

        public void AddSkillSteps()
        {
            foreach (var skillRecord in skilldata.SkillRecords)
            {
                profileTabSkillObj.AddSkills(skillRecord.AddSkill, skillRecord.ChooseSkill);
                skillassert.AddSkillAssert(skillRecord.AddSkill);
                dataUsedInTest.Add(skillRecord.AddSkill);
            }
        }
        public void EditSkillSteps()
        {
            // Load skill data from JSON file
            var addskill = skilldata.SkillRecords[0];
            var editskill = skilldata.SkillRecords[1];
            profileTabSkillObj.AddSkills(addskill.AddSkill,addskill.ChooseSkill);
            profileTabSkillObj.EditSkill(editskill.AddSkill, editskill.ChooseSkill);
            skillassert.EditSkillAssert(editskill.AddSkill);
            dataUsedInTest.Add(editskill.AddSkill);
        }
        public void DeleteSkillSteps()
        {
            // Load skill data from JSON file
            var addskill = skilldata.SkillRecords[0];
            profileTabSkillObj.AddSkills(addskill.AddSkill, addskill.ChooseSkill);
            profileTabSkillObj.DeleteSkillrecord();
            skillassert.DeleteSkillAssert(addskill.AddSkill);

        }
        public void TearDown()
        {
            // Delete all education records created in the current test
            foreach (var addskill in dataUsedInTest)
            {
                profileTabSkillObj.DeleteSkill(addskill);
            }
            //Clear the datalist for the next test
            dataUsedInTest.Clear();
            Dispose();
        }
    }
}
