using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestDemoCodeDAL.DAL.DataConnection;
using TestDemoCodeDAL.DAL.Entity.Masters;

namespace TestDemoMVCCodeFirst.Controllers
{
    public class UserMasterController : Controller
    {
        DataContext db = new DataContext();
        // GET: UserMaster
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateUser() {
            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(UserMaster user) {
            if (ModelState.IsValid)
            {
                user.isActive = true;
                db.UserMaster.Add(user);
                db.SaveChanges();
                ViewBag.Message = "User Saved successfully";
                ModelState.Clear();
                return View();
            }
            else {
                ModelState.AddModelError("errmsg","Please Fill Required fill.");
                return View();
            }
        }

    }
}