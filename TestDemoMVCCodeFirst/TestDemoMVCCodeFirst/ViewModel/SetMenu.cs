using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestDemoCodeDAL.DAL.Entity;
using TestDemoCodeDAL.DAL.Entity.Masters;

namespace TestDemoMVCCodeFirst.ViewModel
{
    public class SetMenu
    {
          public List<UserMaster> UserList { get; set; }
          public  List<MenuMaster> MenuList { get; set; }
    }
}