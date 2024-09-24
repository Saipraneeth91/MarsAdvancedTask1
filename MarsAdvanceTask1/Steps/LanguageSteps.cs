using MarsAdvancedTask1.TestModel;
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

namespace MarsAdvancedTask1.Steps
{
    public class LanguageSteps : DriverFactory
    {
        private LoginPage loginPage;
        private LanguageModel langdata;
        private Profilelanguagetab profilelangtab;
        private LanguageAssert languageassert;
        private List<string> dataUsedInTest;

        public LanguageSteps(LanguageModel langdata) 
        {
            profilelangtab = new Profilelanguagetab(driver);
            languageassert = new LanguageAssert(driver);
            dataUsedInTest = new List<string>();
            this.langdata = langdata;
        }

        public void AddLanguageSteps()
        {
            foreach (var langRecord in langdata.LanguageRecords)
            {
                profilelangtab.AddLanguage(langRecord.Addlanguage, langRecord.ChooseLanguageLevel);
                languageassert.AddLanguageAssert(langRecord.Addlanguage);
                dataUsedInTest.Add(langRecord.Addlanguage);
            }
        }
        public void EditLanguageSteps()
        {
            
            var addlanguage = langdata.LanguageRecords[0];
            var editlanguage = langdata.LanguageRecords[1];
            profilelangtab.AddLanguage(addlanguage.Addlanguage, addlanguage.ChooseLanguageLevel);
            profilelangtab.EditLanguage(editlanguage.Addlanguage, editlanguage.ChooseLanguageLevel);
            languageassert.EditLanguageAssert(editlanguage.Addlanguage);
            dataUsedInTest.Add(editlanguage.Addlanguage);
        }
        public void DeleteLanguageSteps()
        {
            var addlanguage = langdata.LanguageRecords[0];
            profilelangtab.AddLanguage(addlanguage.Addlanguage, addlanguage.ChooseLanguageLevel);
            profilelangtab.DeleteLanguagedetails();
            languageassert.DeleteLanguageAssert(addlanguage.Addlanguage);

        }
        public void TearDown()
        {
            // Delete all education records created in the current test
            foreach (var addlanguage in dataUsedInTest)
            {
                profilelangtab.DeleteLanguage(addlanguage);
            }
            //Clear the datalist for the next test
            dataUsedInTest.Clear();
            Dispose();
        }
    }

    }


