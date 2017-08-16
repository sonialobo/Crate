
using Crate.Config;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crate.Global
{
    class Base
    {
        #region To access Path from resource file
        public static int Browser = Int32.Parse(Resources.Browser);
        public static String ExcelPath = Resources.ExcelPath;
        public static string ScreenshotPath = Resources.ScreenShotPath;
        public static string ReportPath = Resources.ReportPath;
        #endregion

        #region reports
      public static ExtentTest test;
      public static ExtentReports extent;
        #endregion

        #region Setup
        [SetUp]
        public void Inititalize()
        {

            // advisasble to read this documentation before proceeding http://extentreports.relevantcodes.com/net/
            switch (Browser)
            {
                case 1:
                    GlobalDefinition.driver = new FirefoxDriver();
                    GlobalDefinition.driver.Manage().Window.Maximize();
                    break;
                case 2:
                    GlobalDefinition.driver = new ChromeDriver();
                    GlobalDefinition.driver.Manage().Window.Maximize();

                    break;

            }

            //IsLogin under CobraResource has made to false cuz this login is setup and it will run everytime with 
            // valid login test. To run setup make it to true then below login will run
            if (Resources.IsLogin.Equals("true"))
            {

                // Creating object for Login class to access Loginstep method
                Login loginobj = new Login();
                loginobj.LoginSteps();
            }

            //Initialise Report -- to get all the reports change to false
            extent = new ExtentReports(ReportPath, true, DisplayOrder.NewestFirst);
            //Load report cofig file
            extent.LoadConfig(Resources.ReportXMLPath);
        }
        #endregion

        #region TearDown
        [TearDown]
        public void TearDown()
        {
            // Screenshot
           String img = SaveScreenShotClass.SaveScreenshot(GlobalDefinition.driver, "Report");
            test.Log(LogStatus.Info, "Image example: " + img);
           // end test. (Reports)
            extent.EndTest(test);
            // calling Flush writes everything to the log file (Reports)
            extent.Flush();
            // Close the driver :           
           GlobalDefinition.driver.Close();
        }
        #endregion

    }

}
