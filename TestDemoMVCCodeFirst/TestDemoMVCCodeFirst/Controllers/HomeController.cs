using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestDemoCodeDAL.DAL.DataConnection;

namespace TestDemoMVCCodeFirst.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Menu_List()
        {
            if (Session["userid"] == null || (int)Session["userid"] == 0)
            {
                return RedirectToAction("login","login");
            }
            int userID = (int)Session["UserId"];
            var menuItems = (from um in db.UserMaster
                             join ma in db.MenuAccess on um.ID equals ma.userId
                             join mm in db.MenuMaster on ma.MenuId equals mm.ID
                             where ma.userId == userID
                             select mm).ToList();

            //var menuItems = db.MenuMaster.ToList();
            return PartialView("_Menu", menuItems);
        }
    }
}