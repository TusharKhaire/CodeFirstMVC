using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestDemoCodeDAL.DAL.Entity.Masters;

namespace TestDemoMVCCodeFirst.Controllers
{
    public class UserMasterController : Controller
    {
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

            }
            else {
                ModelState.AddModelError("errmsg","Please Fill Required fill.");
                return View();
            }
            return View();
        }

    }
}