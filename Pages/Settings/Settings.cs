using Crate.Global;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Threading;
using AutoItX3Lib;
using OpenQA.Selenium.Support.UI;

namespace Crate.Pages
{
    class Room
    {
        public void NavSettingpage()
        { //populate in collection
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Settings");

            //Click on Admin tab
            GlobalDefinition.ActionButton(GlobalDefinition.driver, Global.ExcelLib.ReadData(2, "Locator"), Global.ExcelLib.ReadData(2, "Value"));
            Base.test.Log(LogStatus.Info, "Clicked on Admin link");

            //Select Settings option under admin tab
            Thread.Sleep(1000);
            GlobalDefinition.ActionButton(GlobalDefinition.driver, Global.ExcelLib.ReadData(3, "Locator"), Global.ExcelLib.ReadData(3, "Value"));
        }

        public void Addroom_Valid()
        {
            // Click on Add Room button
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(5, "Locator"), ExcelLib.ReadData(5, "Value"));
            //Enter Room name
            GlobalDefinition.Textbox(GlobalDefinition.driver, ExcelLib.ReadData(6, "Locator"), ExcelLib.ReadData(6, "Value"), ExcelLib.ReadData(6, "Input"));
            //Click on Color picker
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(7, "Locator"), ExcelLib.ReadData(7, "Value"));

            //Select the color
            IWebElement color = GlobalDefinition.driver.FindElement(By.XPath("//div[@class='k-hsv-gradient']"));
            color.GetCssValue("#804040");
            Thread.Sleep(2000);
            color.Click();
            // Click on apply button
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(9, "Locator"), ExcelLib.ReadData(9, "Value"));
            Thread.Sleep(1000);

            //Click on save button
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(10, "Locator"), ExcelLib.ReadData(10, "Value"));
            Thread.Sleep(2000);

            // Handle validation alert if occurs
            //bool isElementDisplayed = GlobalDefinition.driver.FindElement(By.XPath(".//*[@id='beehive-alert']/p")).Displayed;

            //if (isElementDisplayed == true)
            //{
            //    string alert = GlobalDefinition.GetTextValue(GlobalDefinition.driver, ExcelLib.ReadData(16, "Locator"), ExcelLib.ReadData(16, "Value"));
            //    Base.test.Log(LogStatus.Error, "test failed " + alert);
            //} 
            //    return;
           
            Thread.Sleep(1000);
            // last page on pagination
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(34, "Locator"), ExcelLib.ReadData(34, "Value"));
            Thread.Sleep(1000);

            string xpath_start = ".//*[@id='Room-List']/tr[";
            string xpath_end = "]/td[2]";

            int i = 1;
            while (GlobalDefinition.isElementPresent(xpath_start + i + xpath_end))
            {
                // string Roomname = GlobalDefinition.GetTextValue(GlobalDefinition.driver,ExcelLib.ReadData(14,"Locator"),ExcelLib.ReadData(14,"Value"));
                string roomname = GlobalDefinition.driver.FindElement(By.XPath(".//*[@id='Room-List']/tr[" + i + "]/td[2]")).Text;
                if (roomname == ExcelLib.ReadData(6, "Input"))
                {
                    Base.test.Log(LogStatus.Pass, "Room added successfully");
                }
                else
                {
                    Base.test.Log(LogStatus.Fail, "Add new room unsuccessfull");
                }
                i++;
            }
            
        }

        public void AddRoom_Invalid()
        {// Click on Add Room button
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(5, "Locator"), ExcelLib.ReadData(5, "Value"));
            //Enter Room name
            //GlobalDefinition.Textbox(GlobalDefinition.driver, ExcelLib.ReadData(6, "Locator"), ExcelLib.ReadData(6, "Value"), ExcelLib.ReadData(6, "Input"));

            for (int i = 2; i<5; i++)
            {
                // Enter room name
                GlobalDefinition.Textbox(GlobalDefinition.driver, ExcelLib.ReadData(6, "Locator"), ExcelLib.ReadData(6, "Value"), ExcelLib.ReadData(i, "InValid_Name"));
                
                //Click on Color picker
                GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(7, "Locator"), ExcelLib.ReadData(7, "Value"));
              
             
                //Select the color
                IWebElement color = GlobalDefinition.driver.FindElement(By.XPath("//div[@class='k-hsv-gradient']"));
               
                color.GetCssValue("#804056");
               
                color.Click();
              
                // Click on apply button
                GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(9, "Locator"), ExcelLib.ReadData(9, "Value"));
                

                //Click on save button
                Global.GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(10, "Locator"), ExcelLib.ReadData(10, "Value"));
               

                string alert = GlobalDefinition.GetTextValue(GlobalDefinition.driver, ExcelLib.ReadData(16, "Locator"), ExcelLib.ReadData(16, "Value"));
                Base.test.Log(LogStatus.Pass,"invalid input "+i+ "gets " + alert);

                //Close the alert
                GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(17, "Locator"), ExcelLib.ReadData(17, "Value"));

                // Clear the textbox
                GlobalDefinition.GetClear(GlobalDefinition.driver, ExcelLib.ReadData(6, "Locator"), ExcelLib.ReadData(6, "Value"));
            }
                     
            
        }

        public void EditRoom_Validdata()
        {
            //Click on Edit Button
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(11, "Locator"), ExcelLib.ReadData(11, "Value"));

            //Edit room name
            GlobalDefinition.GetClear(GlobalDefinition.driver, ExcelLib.ReadData(12, "Locator"), ExcelLib.ReadData(12, "Value"));
            GlobalDefinition.Textbox(GlobalDefinition.driver, ExcelLib.ReadData(12, "Locator"), ExcelLib.ReadData(12, "Value"), ExcelLib.ReadData(12, "Input"));

            //Click on update btn
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(13, "Locator"), ExcelLib.ReadData(13, "Value"));
           
            // Checking if record created in the table
            String editValidation = GlobalDefinition.GetTextValue(GlobalDefinition.driver, ExcelLib.ReadData(14, "Locator"), ExcelLib.ReadData(14, "Value"));

            if (editValidation == ExcelLib.ReadData(12, "Input"))
            {
                Base.test.Log(LogStatus.Pass, "Room name edited to: " + ExcelLib.ReadData(12, "Input") + " successfully");
            } else
            {
                Base.test.Log(LogStatus.Fail, "Edit Room name failed");
            }
        }

        public void EditRoom_Duplicatedata()
        {
            //Click on Edit Button
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(15, "Locator"), ExcelLib.ReadData(15, "Value"));

            //Edit room name
            GlobalDefinition.GetClear(GlobalDefinition.driver, ExcelLib.ReadData(12, "Locator"), ExcelLib.ReadData(12, "Value"));
            GlobalDefinition.Textbox(GlobalDefinition.driver, ExcelLib.ReadData(12, "Locator"), ExcelLib.ReadData(12, "Value"), ExcelLib.ReadData(12, "Input"));

            //Click on update btn
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(13, "Locator"), ExcelLib.ReadData(13, "Value"));

            //get alert text
            string alert = GlobalDefinition.GetTextValue(GlobalDefinition.driver, ExcelLib.ReadData(16, "Locator"), ExcelLib.ReadData(16, "Value"));
            Base.test.Log(LogStatus.Pass, "Test Passed with alert message :" + alert);

        }

        public void EditRoom_blank()
        {
            //Click on Edit Button
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(15, "Locator"), ExcelLib.ReadData(15, "Value"));

            //Edit room name
            GlobalDefinition.GetClear(GlobalDefinition.driver, ExcelLib.ReadData(12, "Locator"), ExcelLib.ReadData(12, "Value"));

            //Click on update btn
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(13, "Locator"), ExcelLib.ReadData(13, "Value"));

            //Get text from alert
            string alert = GlobalDefinition.GetTextValue(GlobalDefinition.driver, ExcelLib.ReadData(16, "Locator"), ExcelLib.ReadData(16, "Value"));
            Base.test.Log(LogStatus.Pass, "Test Passed with alert message :" + alert);
        }

        public void EditRoom_InvalidData()
        {            
            //Click on Edit Button
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(15, "Locator"), ExcelLib.ReadData(15, "Value"));

            for (int i = 2; i < 5; i++)
            {    // Clear text
                GlobalDefinition.GetClear(GlobalDefinition.driver, ExcelLib.ReadData(12, "Locator"), ExcelLib.ReadData(12, "Value"));

                //enter data
                GlobalDefinition.Textbox(GlobalDefinition.driver, ExcelLib.ReadData(12, "Locator"), ExcelLib.ReadData(12, "Value"), ExcelLib.ReadData(i, "InValid_Name"));
                
                //Click on update btn
                GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(13, "Locator"), ExcelLib.ReadData(13, "Value"));

                //Get text from alert
                Thread.Sleep(1000);
                string alert = GlobalDefinition.GetTextValue(GlobalDefinition.driver, ExcelLib.ReadData(16, "Locator"), ExcelLib.ReadData(16, "Value"));
                Base.test.Log(LogStatus.Pass, "Test Passed with alert message : " + i + alert);
                
                //Close Alert
                GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(17, "Locator"), ExcelLib.ReadData(17, "Value"));
            }
        }

        public void DeleteRoom()
        {           
            //Click on Delete
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(18, "Locator"), ExcelLib.ReadData(18, "Value"));
            GlobalDefinition.driver.SwitchTo().Alert().Accept();

            //Get text from alert
            string alert = GlobalDefinition.GetTextValue(GlobalDefinition.driver, ExcelLib.ReadData(16, "Locator"), ExcelLib.ReadData(16, "Value"));
            Base.test.Log(LogStatus.Pass, "Test Passed with alert message : " + alert);
            
            //Close Alert
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(17, "Locator"), ExcelLib.ReadData(17, "Value"));
        }

    }
    class assets
    {
        public void NavAssetsPage()
        { //populate in collection
            ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "Settings");

            //Click on Admin tab
            Global.GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(2, "Locator"), ExcelLib.ReadData(2, "Value"));
            Base.test.Log(LogStatus.Info, "Clicked on Admin link");

            //Select Settings option under admin tab
            Thread.Sleep(1000);
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(3, "Locator"), ExcelLib.ReadData(3, "Value"));
           
            //Click on asset tab
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(19, "Locator"), ExcelLib.ReadData(19, "Value"));
        }

        public void AddNewAsset_Validdata()
        {            
            //Click on Add new asset
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(20, "Locator"), ExcelLib.ReadData(20, "Value"));

            //select asset type
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(21, "Locator"), ExcelLib.ReadData(21, "Value"));
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(22, "Locator"), ExcelLib.ReadData(22, "Value"));

            //Enter asset name
            GlobalDefinition.Textbox(GlobalDefinition.driver, ExcelLib.ReadData(23, "Locator"), ExcelLib.ReadData(23, "Value"),ExcelLib.ReadData(23,"Input"));
           // for (int i = 2; i < 5; i++)
            //{
                //enter data
              //  GlobalDefinition.Textbox(GlobalDefinition.driver, ExcelLib.ReadData(23, "Locator"), ExcelLib.ReadData(23, "Value"), ExcelLib.ReadData(i, "V_Asset name"));
                
                //Select room
                GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(24, "Locator"), ExcelLib.ReadData(24, "Value"));
                GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(25, "Locator"), ExcelLib.ReadData(25, "Value"));
            string roomname = GlobalDefinition.GetTextValue(GlobalDefinition.driver, ExcelLib.ReadData(25, "Locator"), ExcelLib.ReadData(25, "Value"));
            //click on save btn
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(26, "Locator"), ExcelLib.ReadData(26, "Value"));
            //}
            //Click last page button on pagination
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(35, "Locator"), ExcelLib.ReadData(35, "Value"));

            //Check if asset created 
            string Xpath_start = ".//*[@id='AssetList']/tr[";
            string Xpath_end = "]/td[1]";

            int l = 1;
            while (GlobalDefinition.isElementPresent(Xpath_start + l + Xpath_end))
            {
                string Roomnamel = GlobalDefinition.driver.FindElement(By.XPath(".//*[@id='AssetList']/tr[" + l + "]/td[1]")).Text;
                
                if (Roomnamel == roomname)
                {
                    Base.test.Log(LogStatus.Info, "Room name matched");

                    string Assetnamel = GlobalDefinition.driver.FindElement(By.XPath(".//*[@id='AssetList']/tr[" + l + "]/td[2]")).Text;
                    if (Assetnamel == ExcelLib.ReadData(23, "Input"))
                    {
                        Base.test.Log(LogStatus.Pass, "Asset Created");
                    }
                }
                l++;
            }
            
        }

        public void Addnewasset_Invaliddata()
        {
            //Click on Add new asset
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(20, "Locator"), ExcelLib.ReadData(20, "Value"));

            //select asset type
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(21, "Locator"), ExcelLib.ReadData(21, "Value"));
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(22, "Locator"), ExcelLib.ReadData(22, "Value"));

            //Enter asset name
           // GlobalDefinition.Textbox(GlobalDefinition.driver, ExcelLib.ReadData(23, "Locator"), ExcelLib.ReadData(23, "Value"), ExcelLib.ReadData(23, "Input"));
            for (int i = 2; i < 5; i++)
            {
                //enter data
                GlobalDefinition.Textbox(GlobalDefinition.driver, ExcelLib.ReadData(23, "Locator"), ExcelLib.ReadData(23, "Value"), ExcelLib.ReadData(i, "InV_Asset name"));


                //Select room
                GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(24, "Locator"), ExcelLib.ReadData(24, "Value"));
                GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(25, "Locator"), ExcelLib.ReadData(25, "Value"));
                string selectedroom = GlobalDefinition.GetTextValue(GlobalDefinition.driver, ExcelLib.ReadData(25, "Locator"), ExcelLib.ReadData(25, "Value"));

                //click on save btn
                GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(26, "Locator"), ExcelLib.ReadData(26, "Value"));

                //Get text from validation error
                string error = GlobalDefinition.GetTextValue(GlobalDefinition.driver, ExcelLib.ReadData(33, "Locator"), ExcelLib.ReadData(33, "Value"));
                Base.test.Log(LogStatus.Pass, "Test Passed with alert message : " + i + error);
            }

        }

        public void DeleteAsset()
        {
            // search for record and delete asset
            IList<IWebElement> deleteasset = GlobalDefinition.driver.FindElements(By.XPath("/div[@class='medium-12 columns']//div/h5[text()='Assets']"));
            int Dasset = deleteasset.Count;
            for (int n = 1; n <= Dasset; n++)
                //for (int i = 1; i == 10; i++)
            {
                Base.test.Log(LogStatus.Info, "Entered the delete search loop");
                string roomname = GlobalDefinition.GetTextValue(GlobalDefinition.driver, ExcelLib.ReadData(27, "Locator"), ExcelLib.ReadData(27, "Value"));
                string assetname = GlobalDefinition.GetTextValue(GlobalDefinition.driver, ExcelLib.ReadData(28, "Locator"), ExcelLib.ReadData(28, "Value"));
                string selectedroom = GlobalDefinition.GetTextValue(GlobalDefinition.driver, ExcelLib.ReadData(25, "Locator"), ExcelLib.ReadData(25, "Value"));

                if (roomname == selectedroom && assetname == ExcelLib.ReadData(23, "Input"))
                {

                    //Click on delete button
                    GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(29, "Locator"), ExcelLib.ReadData(29, "Value"));
                    GlobalDefinition.driver.SwitchTo().Alert().Accept();
                   
                }
                else
                {
                    Base.test.Log(LogStatus.Fail, "Delete search not found");
                }                              
            }

            //Check if the asset is deleted
            for (int i = 1; i == 10; i++)
            {
                Base.test.Log(LogStatus.Info, "Entered the delete search loop");
                string roomname = GlobalDefinition.GetTextValue(GlobalDefinition.driver, ExcelLib.ReadData(27, "Locator"), ExcelLib.ReadData(27, "Value"));
                string assetname = GlobalDefinition.GetTextValue(GlobalDefinition.driver, ExcelLib.ReadData(28, "Locator"), ExcelLib.ReadData(28, "Value"));
                string selectedroom = GlobalDefinition.GetTextValue(GlobalDefinition.driver, ExcelLib.ReadData(25, "Locator"), ExcelLib.ReadData(25, "Value"));

                if (roomname == selectedroom && assetname == ExcelLib.ReadData(23, "Input"))
                {

                    Base.test.Log(LogStatus.Pass, "Asset not deleted");
                    return;
                }
                else
                {
                    Base.test.Log(LogStatus.Fail, "Asset deleted successfully");
                }
            }

        }

        public void EditAssetname()
        {
            //Click on Edit button
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(30, "Locator"), ExcelLib.ReadData(30, "Value"));

            //Change asset name
            GlobalDefinition.GetClear(GlobalDefinition.driver, ExcelLib.ReadData(23, "Locator"), ExcelLib.ReadData(23, "Value"));
            GlobalDefinition.Textbox(GlobalDefinition.driver, ExcelLib.ReadData(23, "Locator"), ExcelLib.ReadData(23, "Value"), ExcelLib.ReadData(23, "Input"));

            //Click on save btn
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(31, "Locator"), ExcelLib.ReadData(31, "Value"));

            string Editasset = GlobalDefinition.GetTextValue(GlobalDefinition.driver, ExcelLib.ReadData(32, "Locator"), ExcelLib.ReadData(32, "Value"));
            if (Editasset == ExcelLib.ReadData(23, "Input"))
            {
                Base.test.Log(LogStatus.Pass, "Edit Asset successful");

            }
            else
            {
                Base.test.Log(LogStatus.Fail, "Edit Asset unsuccessful");
            }

         
        }

        public void EditAssetRoom()
        {
            //Click on Edit button
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(30, "Locator"), ExcelLib.ReadData(30, "Value"));

            //select room

            GlobalDefinition.SelectDropDown(GlobalDefinition.driver, ExcelLib.ReadData(24, "Locator"), ExcelLib.ReadData(24, "Value"), ExcelLib.ReadData(24, "Input"));

            //Click on save
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(31, "Locator"), ExcelLib.ReadData(31, "Value"));

        }

        public void FilterAsset()
        {
            //click on filter
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(36, "Locator"), ExcelLib.ReadData(36, "Value"));

            IList<IWebElement> dd_Room = GlobalDefinition.driver.FindElements(By.XPath(".//*[@id='assetDropdown_listbox']/li"));
            int RoomCount = dd_Room.Count;

            for (int i = 0; i < RoomCount; i++)
            {
                if (dd_Room[i].Text == "Sky")
                {
                    dd_Room[i].Click();
                }
            }
            //Check if asset created 
            string Xpath_start = ".//*[@id='AssetList']/tr[";
            string Xpath_end = "]/td[1]";

            int l = 1;
            while (GlobalDefinition.isElementPresent(Xpath_start + l + Xpath_end))
            {
                string Roomnamel = GlobalDefinition.driver.FindElement(By.XPath(".//*[@id='AssetList']/tr[" + l + "]/td[1]")).Text;

                if (Roomnamel == "Sky")
                {
                    Base.test.Log(LogStatus.Pass, "Room name matches the filter");
                }
                else
                {
                    Base.test.Log(LogStatus.Fail, "Room name does not match the filter");
                } l++;
            }
        }
    }

    class Dashboard
    {
        public void Update_dashboard()
        {
            //populate in collection
            ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "Settings");

            //Click on Admin tab
            Global.GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(2, "Locator"), ExcelLib.ReadData(2, "Value"));
            Thread.Sleep(2000);
            //Select Settings option under admin tab
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(3, "Locator"), ExcelLib.ReadData(3, "Value"));
            Thread.Sleep(2000);

            //Click on Dashboard tab
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(37, "Locator"), ExcelLib.ReadData(37, "Value"));

            //Enter Text
            GlobalDefinition.Textbox(GlobalDefinition.driver, ExcelLib.ReadData(38, "Locator"), ExcelLib.ReadData(38, "Value"), ExcelLib.ReadData(38, "Input"));
            

            //Click update button
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(39, "Locator"), ExcelLib.ReadData(39, "Value"));

            //Check if the dashboard header is updated
            string dashheader= GlobalDefinition.GetTextValue(GlobalDefinition.driver, ExcelLib.ReadData(40, "Locator"), ExcelLib.ReadData(40, "Value"));

            if (dashheader == ExcelLib.ReadData(38, "Input"))
            {
                Base.test.Log(LogStatus.Pass, "Dashboard Header updated");
            }
            else
            {
                Base.test.Log(LogStatus.Fail, "Dashboard Header not updated");
            }

        }
    }
    class Logo
    {
        public void Delete_Logo()
        { 
            //populate in collection
            ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "Settings");

            //Click on Admin tab
            Global.GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(2, "Locator"), ExcelLib.ReadData(2, "Value"));
            Thread.Sleep(2000);

            //Select Settings option under admin tab
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(3, "Locator"), ExcelLib.ReadData(3, "Value"));
            Thread.Sleep(2000);

            //Click on Logo tab
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(41, "Locator"), ExcelLib.ReadData(41, "Value"));

            //Click on delete Logo btn
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(42, "Locator"), ExcelLib.ReadData(42, "Value"));

            // accept alert
            GlobalDefinition.driver.SwitchTo().Alert().Accept();
        }

        public void Upload_Logo()
        {
            //populate in collection
            ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "Settings");

            //Click on Admin tab
            Global.GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(2, "Locator"), ExcelLib.ReadData(2, "Value"));
            Thread.Sleep(2000);

            //Select Settings option under admin tab
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(3, "Locator"), ExcelLib.ReadData(3, "Value"));
            Thread.Sleep(2000);

            //Click on Logo tab
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(41, "Locator"), ExcelLib.ReadData(41, "Value"));
            Thread.Sleep(1000);

            //Click on Upload Logo
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(43, "Locator"), ExcelLib.ReadData(43,"Value"));
           
            AutoItX3 auto = new AutoItX3();
            auto.WinActivate("Open");
            auto.Send(@"C:\Users\sonia\Desktop\CRATE\crate logo.png");
            auto.Send("{ENTER}");

            //Click on save btn
            GlobalDefinition.ActionButton(GlobalDefinition.driver, ExcelLib.ReadData(44, "Locator"), ExcelLib.ReadData(44, "Value"));
        }



    }



}


