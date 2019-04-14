using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using static NUnit.Core.NUnitFramework;
using static SpecflowPages.CommonMethods;


namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class SpecFlowFeature1Steps : Utils.Start
    {
        [Given(@"I clicked on the Language tab under Profile page")]
        public void GivenIClickedOnTheLanguageTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);
       
            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//a[starts-with(text(), 'Profile') and @class='item']")).Click();
        }
        
        [When(@"I add a new language")]
        public void WhenIAddANewLanguage()
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//thead//tr[1]//th[3]//div[contains(text(), 'Add New') and @class='ui teal button ']")).Click();

            //Add Language
            Driver.driver.FindElement(By.XPath("//input[contains(@name, 'name')]")).SendKeys("English");

            //Click on Language Level
            SelectElement levelDropdown=new SelectElement(Driver.driver.FindElement(By.XPath("//select[contains(@name, 'level')]")));

            //Choose the language level
            levelDropdown.SelectByText("Fluent");

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[contains(@value, 'Add')]")).Click();
        }

        [Then(@"that language should be displayed on my listings")]
        public void ThenThatLanguageShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Language");
                Thread.Sleep(1000);

                string ExpectedValue = "English";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Text;
                Thread.Sleep(500);

                if(ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
            }
            catch(Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed",e.Message);
            }
        }

        [When(@"I add language with out level")]
        public void WhenIAddLanguageWithOutLevel()
        {
            Driver.driver.FindElement(By.XPath("//thead//tr[1]//th[3]//div[contains(text(), 'Add New') and @class='ui teal button ']")).Click();
            //Add Language
            Driver.driver.FindElement(By.XPath("//input[contains(@name, 'name')]")).SendKeys("English");
            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[contains(@value, 'Add')]")).Click();
        }

        [When(@"I add level without language")]
        public void WhenIAddLevelWithoutLanguage()
        {
            Driver.driver.FindElement(By.XPath("//thead//tr[1]//th[3]//div[contains(text(), 'Add New') and @class='ui teal button ']")).Click();
            //Click on Language Level
            SelectElement levelDropdown = new SelectElement(Driver.driver.FindElement(By.XPath("//select[contains(@name, 'level')]")));
            //Choose the language level
            levelDropdown.SelectByText("Fluent");
            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[contains(@value, 'Add')]")).Click();
        }

        [When(@"I click add without level and language")]
        public void WhenIClickAddWithoutLevelAndLanguage()
        {
            Driver.driver.FindElement(By.XPath("//thead//tr[1]//th[3]//div[contains(text(), 'Add New') and @class='ui teal button ']")).Click();
            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[contains(@value, 'Add')]")).Click();
        }

        [Then(@"Language addition should be unsuccessful")]
        public void ThenLanguageAdditionShouldBeUnsuccessful()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Language without language or level");
                Thread.Sleep(1000);
                
                IWebElement AddButton = Driver.driver.FindElement(By.XPath("//input[contains(@value, 'Add')]")) ;
                Thread.Sleep(500);

                //If add button is displayed,then language addition is unsuccessful
                if (AddButton.Displayed)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Language is not Added ");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Language is not Added");
                }
                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }

        [When(@"I click add and cancel")]
        public void WhenIClickAddAndCancel()
        {
            Driver.driver.FindElement(By.XPath("//thead//tr[1]//th[3]//div[contains(text(), 'Add New') and @class='ui teal button ']")).Click();
            Driver.driver.FindElement(By.XPath("//input[contains(@value, 'Cancel')]")).Click();
        }

        [Then(@"language should not be added")]
        public void ThenLanguageShouldNotBeAdded()
        {
            
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("cancel Adding a Language ");
                Thread.Sleep(1000);

                //checking for cancel button
                IWebElement CancelButton = Driver.driver.FindElement(By.XPath("//input[contains(@value, 'Cancel')]"));
                Thread.Sleep(500);

                if (CancelButton.Displayed)
                {
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                }
            }
            catch (Exception e)
            {
                
                CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Adding a language is cancelled ");
                SaveScreenShotClass.SaveScreenshot(Driver.driver, "Adding a language is cancelled");

            }
        }


        [When(@"I click edit button and update")]
        public void WhenIClickEditButtonAndUpdate()
        {
            string beforeXpath = "//th[text()='Language']//ancestor::thead//following-sibling::tbody";
            IList<IWebElement> Languages=Driver.driver.FindElements(By.XPath(beforeXpath +"//tr//td[1]"));
            
            //checking language list for English or Hindi and Updating it
            for (int i= 1; i<=Languages.Count; i++)
            {
                if (Languages[i-1].Text.Equals("English") || Languages[i-1].Text.Equals("Hindi"))
                {
                    Driver.driver.FindElement(By.XPath(beforeXpath+"[" + i +"]//i[@class='outline write icon']")).Click();
                    Driver.driver.FindElement(By.XPath("//input[@name='name']")).Clear();
                    Driver.driver.FindElement(By.XPath("//input[@name='name']")).SendKeys("LanguageEdited");
                    Driver.driver.FindElement(By.XPath("//input[contains(@value, 'Update')]")).Click();
                }
            }
        }

        [Then(@"Updated language details should be listed")]
        public void ThenUpdatedLanguageDetailsShouldBeListed()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Edit a Language");
                Thread.Sleep(1000);

                string ExpectedValue = "LanguageEdited";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Text;
                Thread.Sleep(500);

                //Checking if language is modified to LanguageEdited
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Edited a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, " Language Edited");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }

        [When(@"I click edit button and Update button")]
        public void WhenIClickEditButtonAndUpdateButton()
        {
            string beforeXpath = "//th[text()='Language']//ancestor::thead//following-sibling::tbody";
            IList<IWebElement> Languages = Driver.driver.FindElements(By.XPath(beforeXpath + "//tr//td[1]"));

            //Checking for English or Hindi and trying to update
            for (int i = 1; i <= Languages.Count; i++)
            {
                if (Languages[i - 1].Text.Equals("English") || Languages[i - 1].Text.Equals("Hindi"))
                {
                    Driver.driver.FindElement(By.XPath(beforeXpath + "[" + i + "]//i[@class='outline write icon']")).Click();
                    Driver.driver.FindElement(By.XPath("//input[contains(@value, 'Update')]")).Click();
                }
            }
        }

        [Then(@"Language update should be unsuccessful")]
        public void ThenLanguageUpdateShouldBeUnsuccessful()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Update a Language without editing");
                Thread.Sleep(1000);

                IWebElement UpdateButton = Driver.driver.FindElement(By.XPath("//input[contains(@value, 'Update')]"));
                Thread.Sleep(500);

                //If update is displayed then updation is unsuccessful
                if (UpdateButton.Displayed)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed,  Language Update is unsuccessfull");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, " Language did not update");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }


        [When(@"I click edit button and then cancel")]
        public void WhenIClickEditButtonAndThenCancel()
        {
            string beforeXpath = "//th[text()='Language']//ancestor::thead//following-sibling::tbody";
            IList<IWebElement> Languages = Driver.driver.FindElements(By.XPath(beforeXpath + "//tr//td[1]"));
            IList<IWebElement> Levels = Driver.driver.FindElements(By.XPath(beforeXpath + "//tr//td[2]"));

            for (int i = 1; i <= Languages.Count; i++)
            {
                if (Languages[i - 1].Text.Equals("English") && Levels[i - 1].Text.Equals("Basic"))
                {
                    Driver.driver.FindElement(By.XPath(beforeXpath + "[" + i + "]//i[@class='outline write icon']")).Click();
                    Driver.driver.FindElement(By.XPath("//input[contains(@value, 'Cancel')]")).Click();
                }
            }
        }

        [Then(@"the language list should be same as previous")]
        public void ThenTheLanguageListShouldBeSameAsPrevious()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("cancelling Editing a Language");
                Thread.Sleep(1000);

                string ExpectedLang = "English";
                string ExpectedLevel = "Basic";
                bool Flag=false;
                IList<IWebElement> ActualLangs = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
                IList<IWebElement> ActualLevels = Driver.driver.FindElements(By.XPath("//th[text()='Language']//ancestor::thead//following-sibling::tbody//tr//td[2]"));
                Thread.Sleep(500);

                for (int i = 0; i < ActualLangs.Count; i++)
                {
                    if ((ExpectedLang == ActualLangs[i].Text) && (ExpectedLevel == ActualLevels[i].Text))
                    {
                        Flag = true;
                        break;
                    }
                    else
                        Flag = false;
                }
                        
                if (Flag == true)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Cancelling Editing a Language");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, " Language Edition cancelled");
                }
                    else
                        CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }

        }


        [When(@"I click the remove button")]
        public void WhenIClickTheRemoveButton()
        {
            /*method 1: removes 1st language in the table
             IReadOnlyCollection<IWebElement> languages = Driver.driver.FindElements(By.XPath("//th[text()='Language']//ancestor::thead//following-sibling::tbody//descendant::i[@class='remove icon']"));
            if(languages.Count() > 0)
            {
                //removes first language in the list
                Driver.driver.FindElement(By.XPath("//th[text()='Language']//ancestor::thead//following-sibling::tbody[1]//descendant::i[@class='remove icon']")).Click();
            }
            else
                Console.WriteLine("There are no languages to delete");
            
        }*/

            //th[text()='Language']//ancestor::thead//following-sibling::tbody//tr  languages
            //th[text()='Language']//ancestor::thead//following-sibling::tbody[1]//tr//td    language name
            //th[text()='Language']//ancestor::thead//following-sibling::tbody[1]//i[@class='remove icon']  remove icon


            string beforeXpath = "//th[text()='Language']//ancestor::thead//following-sibling::tbody[";
            string LanguageXpath = "]//tr//td";
            string removeXpath = "]//i[@class='remove icon']";

            //check the list for English language and click remove
            IList<IWebElement> Languages = Driver.driver.FindElements(By.XPath("//th[text()='Language']//ancestor::thead//following-sibling::tbody//tr"));
            int count = Languages.Count();

            if (Languages.Count() > 0)
            {
                for (int i = 1; i<=count; i++)
                {
                    if (Driver.driver.FindElement(By.XPath(beforeXpath + i + LanguageXpath)).Text == "English")
                        Driver.driver.FindElement(By.XPath(beforeXpath + i + removeXpath)).Click();
                }
            }
            else
                Console.WriteLine("There are no languages to delete");
        }

        [Then(@"The language should be removed from the listings")]
        public void ThenTheLanguageShouldBeRemovedFromTheListings()
        {
            try
            {
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Removing a language");
                Thread.Sleep(1000);

                /*  method 1-validating dynamic tooltip text

                 string ExpectedValue = "has been deleted from your languages";
                 string ActualValue = Driver.driver.FindElement(By.XPath("//div[contains(@class,'ns-box-inner')]")).Text;

                     if (ActualValue.Contains(ExpectedValue))
                     {
                         CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Deleted a Language Successfully");
                         SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageDeleted");
                         Console.WriteLine("language deleted successfully");
                     }

                     else
                     CommonMethods.test.Log(LogStatus.Fail, ActualValue +"Test Failed in else");
                     
                 */

                //method 2-check the list for the language you hv deleted
                // //th[contains(text(),'Language')]//ancestor::thead//following-sibling::tbody[1]/tr/td---English
                // //th[contains(text(),'Language')]//ancestor::thead//following-sibling::tbody[2]/tr/td---hindi

                //check if English exists in the list after removing
                IList<IWebElement> Languages = Driver.driver.FindElements(By.XPath("//th[text()='Language']//ancestor::thead//following-sibling::tbody"));
                int count = Languages.Count();
                String beforeXPath = "//th[contains(text(),'Language')]//ancestor::thead//following-sibling::tbody[";
                String AfterXPath = "]/tr/td";
                bool LangFound;

                for (int i = 1; i <= count; i++)
                {
                    
                    if (Driver.driver.FindElement(By.XPath(beforeXPath + i + AfterXPath)).Text == "English")
                    {
                        LangFound = true;
                    }
                    else
                    {
                        LangFound = false;
                        Console.WriteLine("language deleted successfully");
                    }
                    if (LangFound)
                    {
                        CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                    }
                    else
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Deleted a Language Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageDeleted");
                    }

                }
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
        [When(@"I add languages")]
        public void WhenIAddLanguages(Table table)
        {
            var languages = table.CreateSet<Languages>();
            foreach (Languages lang in languages)
            {
                //Click on Add New button
                Driver.driver.FindElement(By.XPath("//thead//tr[1]//th[3]//div[contains(text(), 'Add New') and @class='ui teal button ']")).Click();

                //Add Language
                Driver.driver.FindElement(By.XPath("//input[contains(@name, 'name')]")).SendKeys(lang.LanguageName);

                //Click on Language Level
                SelectElement levelDropdown = new SelectElement(Driver.driver.FindElement(By.XPath("//select[contains(@name, 'level')]")));

                //Choose the language level
                levelDropdown.SelectByText(lang.Level);

                //Click on Add button
                Driver.driver.FindElement(By.XPath("//input[contains(@value, 'Add')]")).Click();
                Thread.Sleep(1000);
            }
        }

        [Then(@"I should see only four languages")]
        public void ThenIShouldSeeOnlyFourLanguages()
        {
            try
            {
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Adding maximum 4 languages");
                Thread.Sleep(1000);
                /*
                //method 1:check the languages count and if its 4 then test passes
                IList<IWebElement> Languages = Driver.driver.FindElements(By.XPath("//th[text()='Language']//ancestor::thead//following-sibling::tbody"));
                int count = Languages.Count();
                if (count == 4)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Maximum is four languages");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "maximum 4 Languages added");
                }
                */

                //method 2: check if add new btn is displayed or not
                IWebElement AddNewBtn = Driver.driver.FindElement(By.XPath("//thead//tr[1]//th[3]//div[contains(text(), 'Add New') and @class='ui teal button ']"));
                if (AddNewBtn.Displayed)
                {
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                }
                else {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed in else, Maximum is four languages");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "maximum 4 Languages added");
                }
            }
            catch (Exception e) {
                CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Maximum is four languages");
                SaveScreenShotClass.SaveScreenshot(Driver.driver, "Maximum 4 Languages can be added");
            }
        }

        [When(@"I add duplicate language and level")]
        public void WhenIAddDuplicateLanguageAndLevel()
        { 
                IList<IWebElement> Languages = Driver.driver.FindElements(By.XPath("//th[text()='Language']//ancestor::thead//following-sibling::tbody"));
                int count = Languages.Count();
                string lang, level;

                //Getting the values of already existing language and level and trying to add same 
                if (count >= 1) {
                    lang = Driver.driver.FindElement(By.XPath("//th[contains(text(),'Language')]//ancestor::thead//following-sibling::tbody[1]/tr/td[1]")).Text;
                    level = Driver.driver.FindElement(By.XPath("//th[contains(text(),'Language')]//ancestor::thead//following-sibling::tbody[1]/tr/td[2]")).Text;

                    Driver.driver.FindElement(By.XPath("//thead//tr[1]//th[3]//div[contains(text(), 'Add New') and @class='ui teal button ']")).Click();
                    Driver.driver.FindElement(By.XPath("//input[contains(@name, 'name')]")).SendKeys(lang);

                    SelectElement levelDropdown = new SelectElement(Driver.driver.FindElement(By.XPath("//select[contains(@name, 'level')]")));                   
                    levelDropdown.SelectByText(level);

                    Driver.driver.FindElement(By.XPath("//input[contains(@value, 'Add')]")).Click();
                }
        }

        [Then(@"error about already existing language data should be displayed")]
        public void ThenErrorAboutAlreadyExistingLanguageDataShouldBeDisplayed()
        {
            try {

                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Adding duplicate languages");
                Thread.Sleep(1000);
                IList<IWebElement> Languages = Driver.driver.FindElements(By.XPath("//th[contains(text(),'Language')]//ancestor::thead//following-sibling::tbody/tr/td[1]"));
                int count = Languages.Count();

                //compare all the languages
                for (int i = 0; i < count; i++)
                {
                    for (int j = 0; j < count; j++)
                    {
                        string str = Languages[i].Text;
                        if ((Languages[j].Text.Equals(str)) && i!= j)
                        {
                            CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                        }
                        else
                        {
                            CommonMethods.test.Log(LogStatus.Pass, "Test Passed,Lang is not added");
                            SaveScreenShotClass.SaveScreenshot(Driver.driver, "Lang is not added");
                            Console.WriteLine("duplicate doesnot exist in else");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed in catch", e.Message);
                //Console.WriteLine("duplicate does not exist in catch");
            }
        }

        [When(@"I add same language with different level")]
        public void WhenIAddSameLanguageWithDifferentLevel()
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//thead//tr[1]//th[3]//div[contains(text(), 'Add New') and @class='ui teal button ']")).Click();

            //Add Language
            Driver.driver.FindElement(By.XPath("//input[contains(@name, 'name')]")).SendKeys("English");

            //Click on Language Level
            SelectElement levelDropdown = new SelectElement(Driver.driver.FindElement(By.XPath("//select[contains(@name, 'level')]")));

            //Choose the language level
            levelDropdown.SelectByText("Basic");

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[contains(@value, 'Add')]")).Click();
        }

    }
}
