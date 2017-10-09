using Crate.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crate.Pages
{
    class AccountManagement
    {    

        public void AddAdminUser()
        {
            //Populate in collection
            Global.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "Account");

            //Click on Admin tab
            Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, Global.ExcelLib.ReadData(2, "Locator"),Global.ExcelLib.ReadData(2, "Value"));
            //Global.GlobalDefinition.wait(500);

            //Select Account option under Admin tab
            Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, Global.ExcelLib.ReadData(3, "Locator"),Global.ExcelLib.ReadData(3, "Value"));
            //Global.GlobalDefinition.wait(500);

            //Click on Add User button
            Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, Global.ExcelLib.ReadData(4, "Locator"), Global.ExcelLib.ReadData(4, "Value"));
            //Global.GlobalDefinition.wait(500);

            //Click on Company DD
            Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, Global.ExcelLib.ReadData(5, "Locator"), Global.ExcelLib.ReadData(5, "Value"));
            //Global.GlobalDefinition.wait(500);

            //Select a value from Company DD
            Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, Global.ExcelLib.ReadData(6, "Locator"), Global.ExcelLib.ReadData(6, "Value"));
        

            //Enter First Name 
            Global.GlobalDefinition.Textbox(Global.GlobalDefinition.driver, Global.ExcelLib.ReadData(7, "Locator"), Global.ExcelLib.ReadData(7, "Value"), Global.ExcelLib.ReadData(7, "FirstName"));
         

            //Enter Last Name 
            Global.GlobalDefinition.Textbox(Global.GlobalDefinition.driver, Global.ExcelLib.ReadData(8, "Locator"), Global.ExcelLib.ReadData(8, "Value"), Global.ExcelLib.ReadData(7, "LastName"));


            //Enter email address 
            Global.GlobalDefinition.Textbox(Global.GlobalDefinition.driver, Global.ExcelLib.ReadData(9, "Locator"), Global.ExcelLib.ReadData(9, "Value"), Global.ExcelLib.ReadData(7, "EmailAddress"));
           

            //Select a gender
            Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, Global.ExcelLib.ReadData(10, "Locator"), Global.ExcelLib.ReadData(10, "Value"));
 

            //Enter email address 
            Global.GlobalDefinition.Textbox(Global.GlobalDefinition.driver, Global.ExcelLib.ReadData(11, "Locator"), Global.ExcelLib.ReadData(11, "Value"), Global.ExcelLib.ReadData(7, "Mobile"));
      

            //Tick administrator check box
            Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, Global.ExcelLib.ReadData(12, "Locator"), Global.ExcelLib.ReadData(12, "Value"));
         

            //Enter password 
            Global.GlobalDefinition.Textbox(Global.GlobalDefinition.driver, Global.ExcelLib.ReadData(13, "Locator"), Global.ExcelLib.ReadData(13, "Value"), Global.ExcelLib.ReadData(7, "Password"));
     

            //Enter Confirm password 
            Global.GlobalDefinition.Textbox(Global.GlobalDefinition.driver, Global.ExcelLib.ReadData(14, "Locator"), Global.ExcelLib.ReadData(14, "Value"), Global.ExcelLib.ReadData(7, "ConfirmPassword"));
        
  
            //Enter Google address
            Global.GlobalDefinition.Textbox(Global.GlobalDefinition.driver, Global.ExcelLib.ReadData(15, "Locator"), Global.ExcelLib.ReadData(15, "Value"), Global.ExcelLib.ReadData(7, "GoogleAddress"));
      

            //Select address
            Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, Global.ExcelLib.ReadData(16, "Locator"), Global.ExcelLib.ReadData(16, "Value"));
           

            //Create Button
            Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, Global.ExcelLib.ReadData(17, "Locator"), Global.ExcelLib.ReadData(17, "Value"));
         

            // Verification of added user
            //Enter the email address of added user in search box
            Global.GlobalDefinition.Textbox(Global.GlobalDefinition.driver, Global.ExcelLib.ReadData(19, "Locator"), Global.ExcelLib.ReadData(19, "Value"), Global.ExcelLib.ReadData(7, "EmailAddress"));
         

            //Click Search button
            Global.GlobalDefinition.ActionButton(Global.GlobalDefinition.driver, Global.ExcelLib.ReadData(20, "Locator"), Global.ExcelLib.ReadData(20, "Value"));
          

            String ResultEmail = Global.GlobalDefinition.GetTextValue(Global.GlobalDefinition.driver, Global.ExcelLib.ReadData(21, "Locator"), Global.ExcelLib.ReadData(21, "Value"));

            if (ResultEmail == "duncan@gmail.com")
            {
                Base.test.Log(LogStatus.Pass, "Test passed, Admin user sucessfully added to the system ");
            }
            else
            {
                Base.test.Log(LogStatus.Fail, "Test UnSuccessful");
            }
        }

        public void AddAdminUserInvalidData()
        {

        }

    }
    
}
