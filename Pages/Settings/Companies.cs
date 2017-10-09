using AutoItX3Lib;
using Crate.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Crate.Pages
{
    class Companies
    {
        public void AddCompany()
        {
            //Populate in collectiion
            //check git hub
            ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "Companies");

            //click on admin tab
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(2, "Locator"), ExcelLib.ReadData(2, "Value"));

            //Click on Companies option
            WebDriverWait wait = new WebDriverWait(GlobalDefinition.driver, TimeSpan.FromSeconds(10));
            var Company = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(ExcelLib.ReadData(3, "Value"))));
            Company.Click();
            //GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(3, "Locator"), ExcelLib.ReadData(3, "Value"));

            //Click add new button
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(4, "Locator"), ExcelLib.ReadData(4, "Value"));

            //enter text in company name
            GlobalDefinition.Textbox(GlobalDefinition.driver, ExcelLib.ReadData(5, "Locator"), ExcelLib.ReadData(5, "Value"), ExcelLib.ReadData(5, "Input"));

            //enter email address
            GlobalDefinition.Textbox(GlobalDefinition.driver, ExcelLib.ReadData(6, "Locator"), ExcelLib.ReadData(6, "Value"), ExcelLib.ReadData(6, "Input"));

            //enter street number
            GlobalDefinition.Textbox(GlobalDefinition.driver, ExcelLib.ReadData(9, "Locator"), ExcelLib.ReadData(9, "Value"), ExcelLib.ReadData(9, "Input"));

            //enter street name
            GlobalDefinition.Textbox(GlobalDefinition.driver, ExcelLib.ReadData(10, "Locator"), ExcelLib.ReadData(10, "Value"), ExcelLib.ReadData(10, "Input"));

            //Enter Suburb
            GlobalDefinition.Textbox(GlobalDefinition.driver, ExcelLib.ReadData(11, "Locator"), ExcelLib.ReadData(11, "Value"), ExcelLib.ReadData(11, "Input"));

            //Enter City
            GlobalDefinition.Textbox(GlobalDefinition.driver, ExcelLib.ReadData(12, "Locator"), ExcelLib.ReadData(12, "Value"), ExcelLib.ReadData(12, "Input"));

            //Enter Postcode
            GlobalDefinition.Textbox(GlobalDefinition.driver, ExcelLib.ReadData(13, "Locator"), ExcelLib.ReadData(13, "Value"), ExcelLib.ReadData(13, "Input"));

            //eneter website
            GlobalDefinition.Textbox(GlobalDefinition.driver, ExcelLib.ReadData(14, "Locator"), ExcelLib.ReadData(14, "Value"), ExcelLib.ReadData(14, "Input"));

            //click to browse logo
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(15, "Locator"), ExcelLib.ReadData(15, "Value"));

            //upload logo
            AutoItX3 auto = new AutoItX3();
            auto.WinActivate("Open");
            auto.Send(@"C:\Users\sonia\Desktop\CRATE\experieco.png");
            auto.Send("{ENTER}");

             GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(16, "Locator"), ExcelLib.ReadData(16, "Value"));

            //Click on last page btn
            WebDriverWait wait1 = new WebDriverWait(GlobalDefinition.driver,TimeSpan.FromSeconds(10));
            var lastpage = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(ExcelLib.ReadData(17, "Value"))));
            lastpage.Click();
            //GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(17, "Locator"), ExcelLib.ReadData(17, "Value"));
            var element = GlobalDefinition.driver.FindElement(By.XPath(ExcelLib.ReadData(17, "Value")));

            Actions actions1 = new Actions(GlobalDefinition.driver);

            actions1.MoveToElement(element).Click().Perform();
            
            //hi there just testing git hub




            //Check if company added

            string xpath_start = ".//*[@id='companies']/tr[";
            string xpath_end = "]/td[1]";

            int i = 1;
            while (GlobalDefinition.isElementPresent(xpath_start + i + xpath_end))
            {
                string companyname = GlobalDefinition.driver.FindElement(By.XPath(".//*[@id='companies']/tr[" +i+ "]/td[1]")).Text;

                if (companyname == ExcelLib.ReadData(5, "Input"))
                {
                    Base.test.Log(LogStatus.Info, "Company name found");
                    string emailid = GlobalDefinition.driver.FindElement(By.XPath(".//*[@id='companies']/tr[" +i+ "]/td[2]")).Text;

                    if (emailid == ExcelLib.ReadData(6, "Input"))
                    {
                        Base.test.Log(LogStatus.Pass, "Company Created");
                    }

                }i++;
            }
        }
    }
}
