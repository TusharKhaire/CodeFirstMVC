using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestDemoCodeDAL.DAL.DataConnection;
using TestDemoMVCCodeFirst.ViewModel;

namespace TestDemoMVCCodeFirst.Controllers
{
    public class MenuMappingController : Controller
    {
        DataContext db = new DataContext();
        // GET: MenuMapping
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult setMenuMapping() {
            SetMenu menu = new SetMenu();
            menu.UserList = db.UserMaster.ToList();
            menu.MenuList = db.MenuMaster.ToList();
            return View(menu);
        }


    }
}