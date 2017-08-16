using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crate.Global
{
    class Login
    {
        // Initializing the web elements 
        internal Login()
        {
            PageFactory.InitElements(Global.GlobalDefinition.driver, this);
        }

        
        // Finding the Username Field
        [FindsBy(How = How.XPath, Using = ".//*[@id='UserName']")]
        private IWebElement Username { get; set; }

        // Finding the Password Field
        [FindsBy(How = How.XPath, Using = ".//*[@id='Password']")]
        private IWebElement Password { get; set; }

        // Finding the Login Button
        [FindsBy(How = How.XPath, Using = "html/body/div/form/button")]
        private IWebElement loginButton { get; set; }

        public void LoginSteps()
        {
            //Populate in collection
            Global.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "LoginPage");

            //Navigate to test env
            Global.GlobalDefinition.driver.Navigate().GoToUrl(Global.ExcelLib.ReadData(2, "Url"));
            Global.GlobalDefinition.wait(500);

            //Maximize the window
            Global.GlobalDefinition.driver.Manage().Window.Maximize();

            //Enter the username
            Username.SendKeys(Global.ExcelLib.ReadData(2, "Username"));

            //Enter the username
            Password.SendKeys(Global.ExcelLib.ReadData(2, "Password"));

            //Click on Login button
            loginButton.Click();
        }
    }
}
