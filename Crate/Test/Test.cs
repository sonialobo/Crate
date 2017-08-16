using Crate.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }


  }