using Crate.Pages;
using NUnit.Framework;

namespace Crate
{
    class Test
    {
        static void Main()
        {
        }

    }


    [TestFixture]
    [Category("Sprint_2")]
    class Sprint2_Account : Global.Base
    {
        [Test]
        public void Account_AddNewAdminUser_ValidData()
        {
            // creates a toggle for the given test, adds all log events under it    
            test = extent.StartTest("Add Admin user using Valid Data");
            // Creating an instance
            AccountManagement obj = new AccountManagement();
            // method for adding admin user with valid data
            obj.AddAdminUser();

        }
    }

    [TestFixture]
    [Category("Sprint_2")]
    class Sprint2_Settings : Global.Base
    {
        [Test]
        public void Settings_Addroom_Validdata()
        {
            //create test log
            test = extent.StartTest("Add room using valid data");

            //Creating instance and calling the function
            Room AD = new Room();
            AD.NavSettingpage();
            AD.Addroom_Valid();
        }
        [Test]
        public void Settings_Addroom_InValiddata()
        {
            test = extent.StartTest("Add room with invalid data");
            Room Adi = new Room();
            Adi.NavSettingpage();
            Adi.AddRoom_Invalid();
        }
        [Test]
        public void Settings_EditRoom_validData()
        {
            test = extent.StartTest("Edit room using valid data");
            // Creating instance and calling function
            Room ED = new Room();
            ED.NavSettingpage();
            ED.EditRoom_Validdata();
        }
        [Test]
        public void Settings_Editroom_Duplicatedata()
        {
            test = extent.StartTest("Edit room with duplicate data");
            //Creating instance and calling function
            Room ERD = new Room();
            ERD.NavSettingpage();
            ERD.EditRoom_Duplicatedata();
        }
        [Test]
        public void Settings_EditRoom_blank()
        {
            test = extent.StartTest("Edit room with blank data");
            //Creating instance and calling function
            Room ERD = new Room();
            ERD.NavSettingpage();
            ERD.EditRoom_blank();
        }
        [Test]
        public void Settings_EditRoom_InvalidData()
        {
            test = extent.StartTest("Edit room with Invalid data");
            //Creating instance and calling function
            Room ERD = new Room();
            ERD.NavSettingpage();
            ERD.EditRoom_InvalidData();
        }
        [Test]
        public void Settings_Deleteroom()
        {
            test = extent.StartTest("Delete Room");
            Room Dr = new Room();
            Dr.NavSettingpage();
            Dr.DeleteRoom();
        }
        [Test]
        public void Assets_AddNewAsset_Validdata()
        {
            test = extent.StartTest("Add new Asset with valid data");

            assets AA = new assets();
            AA.NavAssetsPage();
            AA.AddNewAsset_Validdata();
        }
        [Test]
        public void Assets_Addnewasset_Invaliddata()
        {
            test = extent.StartTest("Add new Asset");

            assets AA = new assets();
            AA.NavAssetsPage();
            AA.Addnewasset_Invaliddata();
        }
        [Test]
        public void Assets_DeleteAsset()
        {
            test = extent.StartTest("Delete asset");
            assets DA = new assets();
            DA.NavAssetsPage();
            DA.DeleteAsset();
        }
        [Test]
        public void Assets_Editassetname()
        {
            test = extent.StartTest("Edit Asset Name");
            assets EA = new assets();
            EA.NavAssetsPage();
            EA.EditAssetname();
        }
        [Test]
        public void Asset_editRoom()
        {
            test = extent.StartTest("Edit asset room");
            assets EAR = new assets();
            EAR.NavAssetsPage();
            EAR.EditAssetRoom();
        }
        [Test]
        public void Assets_Filter()
        {
            test = extent.StartTest("filter asset");
            assets AF = new assets();
            AF.NavAssetsPage();
            AF.FilterAsset();
        }
        [Test]
        public void Update_Dashboard()
        {
            test = extent.StartTest("Update Dashboard");
            Dashboard UD = new Dashboard();
            UD.Update_dashboard();
        }
        [Test]
        public void DeleteLogo()
        {
            test = extent.StartTest("delete logo");
            Logo DL = new Logo();
            DL.Delete_Logo();
        }
        [Test]
        public void Uploadlogo()
        {
            test = extent.StartTest("Upload Logo");
            Logo UL = new Logo();
            UL.Upload_Logo();
        }
   
    }

    [TestFixture]
    [Category("Sprint_2")]
    class Sprint2_Company : Global.Base
    {
        [Test]
        public void Companies_addcompany()
        {
            test = extent.StartTest("add new company");
            Companies ad = new Companies();
            ad.AddCompany();
        }
    }

}


  