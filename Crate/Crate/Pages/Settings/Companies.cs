using AutoItX3Lib;
using Crate.Global;
using RelevantCodes.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Crate.Global.GlobalDefinition;

namespace Crate.Pages.companies
{
    class Companies
    {
        public void AddCompany()
        {
            //Populate in collectiion
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Companies");

            //click on admin tab
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(2, "Locator"), ExcelLib.ReadData(2, "Value"));

            //Click on Companies option
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(3, "Locator"), ExcelLib.ReadData(3, "Value"));

            //Click add new button
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(4, "Locator"), ExcelLib.ReadData(4, "Value"));

            //enter text in company name
            GlobalDefinition.Textbox(GlobalDefinition.driver, ExcelLib.ReadData(5, "Locator"), ExcelLib.ReadData(5, "Value"), ExcelLib.ReadData(5, "Input"));

            //enter email address
            GlobalDefinition.Textbox(GlobalDefinition.driver, ExcelLib.ReadData(6, "Locator"), ExcelLib.ReadData(6, "Value"), ExcelLib.ReadData(6, "Input"));

            //enter address
            GlobalDefinition.Textbox(GlobalDefinition.driver, ExcelLib.ReadData(7, "Locator"), ExcelLib.ReadData(7, "Value"), ExcelLib.ReadData(7, "Input"));

            //click the 1st suggestion
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(8, "Locator"), ExcelLib.ReadData(8, "Value"));

            //eneter website
            GlobalDefinition.Textbox(GlobalDefinition.driver, ExcelLib.ReadData(14, "Locator"), ExcelLib.ReadData(14, "Value"),ExcelLib.ReadData(14,"Input"));

            //click to browse logo
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(15, "Locator"), ExcelLib.ReadData(15, "Value"));

            //upload logo
            AutoItX3 auto = new AutoItX3();
            auto.WinActivate("Open");
            auto.Send(@"C:\Users\sonia\Desktop\Crate\experieco.png");
            auto.Send("{ENTER}");

            // Click on save button
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(16, "Locator"), ExcelLib.ReadData(16, "Value"));

        }
    }
}
