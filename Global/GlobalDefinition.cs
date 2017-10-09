﻿
using Excel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crate.Global
{
    public static class GlobalDefinition
    {
        //initialising driver
        public static IWebDriver driver { get; set; }

        #region WaitforElement 

        public static IWebElement WaitForElement(IWebDriver driver, By by, int timeOutinSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            return (wait.Until(ExpectedConditions.ElementIsVisible(by)));
        }
        #endregion

        #region DynamicIWebELement
        public static void Textbox(IWebDriver driver, string Locator, string Lvalue, string InputValue)
        {
            if (Locator == "Id")
            {
                driver.FindElement(By.Id(Lvalue)).SendKeys(InputValue);
            }
            else if (Locator == "XPath")
            {
                driver.FindElement(By.XPath(Lvalue)).SendKeys(InputValue);
            }
            else if (Locator == "CSS")
            {
                driver.FindElement(By.CssSelector(Lvalue)).SendKeys(InputValue);
            }
            else if (Locator == "Class")
            {
                driver.FindElement(By.ClassName(Lvalue)).SendKeys(InputValue);
            }
            else
                Console.WriteLine("Invalid Locator value");

        }
        public static string GetTextValue(IWebDriver driver, string Locator, string Lvalue)
        {
            if (Locator == "Id")
            {
                return driver.FindElement(By.Id(Lvalue)).Text;
            }
            else if (Locator == "XPath")
            {
                return driver.FindElement(By.XPath(Lvalue)).Text;
            }
            else if (Locator == "CSS")
            {
                return driver.FindElement(By.CssSelector(Lvalue)).Text;
            }
            else
                Console.WriteLine("Invalid Locator value");
            return "";

        }
        public static void GetClear(IWebDriver driver, string Locator, string Lvalue)
        {
            if (Locator == "Id")
            {
                driver.FindElement(By.Id(Lvalue)).Clear();
            }
            else if (Locator == "XPath")
            {
                driver.FindElement(By.XPath(Lvalue)).Clear();
            }
            else if (Locator == "CSS")
            {
                driver.FindElement(By.CssSelector(Lvalue)).Clear();
            }
            else
                Console.WriteLine("Invalid Locator value");


        }

        public static void ActionButton(IWebDriver driver, string Locator, string Lvalue)
        {
            if (Locator == "Id")
                driver.FindElement(By.Id(Lvalue)).Click();
            else if (Locator == "XPath")
                driver.FindElement(By.XPath(Lvalue)).Click();
            else if (Locator == "CSS")
                driver.FindElement(By.CssSelector(Lvalue)).Click();
            else if (Locator == "Class")
                driver.FindElement(By.ClassName(Lvalue)).Click();
            else
                Console.WriteLine("Invalid Locator value");
        }
        public static Boolean isElementPresent(string Lvalue)
        {
            int count = driver.FindElements(By.XPath(Lvalue)).Count();
            if (count == 0)
                return false;
            else
                return true;

        }
    
        public static void SelectDropDown(IWebDriver driver, string Locator, string Lvalue, string InputValue)
        {
            if (Locator == "Id")
                new SelectElement(driver.FindElement(By.Id(Lvalue))).SelectByText(InputValue);
            if (Locator == "XPath")
                new SelectElement(driver.FindElement(By.XPath(Lvalue))).SelectByText(InputValue);
        }
            #endregion

        }

        #region Excel 
        public class ExcelLib
    {
        static List<Datacollection> dataCol = new List<Datacollection>();

        public class Datacollection
        {
            public int rowNumber { get; set; }
            public string colName { get; set; }
            public string colValue { get; set; }
        }


        public static void ClearData()
        {
            dataCol.Clear();
        }


        private static DataTable ExcelToDataTable(string fileName, string SheetName)
        {
            // Open file and return as Stream
            using (System.IO.FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream))
                {
                    excelReader.IsFirstRowAsColumnNames = true;

                    //Return as dataset
                    DataSet result = excelReader.AsDataSet();
                    //Get all the tables
                    DataTableCollection table = result.Tables;

                    // store it in data table
                    DataTable resultTable = table[SheetName];
                    // return
                    return resultTable;
                }
            }
        }

        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                //Retriving Data using LINQ to reduce much of iterations
                rowNumber = rowNumber - 1;
                string data = (from colData in dataCol
                               where colData.colName == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).SingleOrDefault();
                //var datas = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;
                return data.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred in ExcelLib Class ReadData Method!" + Environment.NewLine + e.Message.ToString());
                return null;
            }
        }
        public static void PopulateInCollection(string fileName, string SheetName)
        {
            ExcelLib.ClearData();
            DataTable table = ExcelToDataTable(fileName, SheetName);
            //Iterate through the rows and columns of the Table
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };
                    //Add all the details for each row
                    dataCol.Add(dtTable);
                }
            }
        }
    }
    #endregion

    #region screenshots
    public class SaveScreenShotClass
    {
        public static string SaveScreenshot(IWebDriver driver, string ScreenShotFileName) // Definition
        {
            var folderLocation = (Global.Base.ScreenshotPath);

            if (!System.IO.Directory.Exists(folderLocation))
            {
                System.IO.Directory.CreateDirectory(folderLocation);
            }

            var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
            var fileName = new StringBuilder(folderLocation);

            fileName.Append(ScreenShotFileName);
            fileName.Append(DateTime.Now.ToString("_dd-mm-yyyy_mss"));
            fileName.Append(".jpeg");
#pragma warning disable CS0618 // Type or member is obsolete
           screenShot.SaveAsFile(fileName.ToString(), ScreenshotImageFormat.Jpeg);
#pragma warning restore CS0618 // Type or member is obsolete
            return fileName.ToString();
        }
    }
    #endregion
}
