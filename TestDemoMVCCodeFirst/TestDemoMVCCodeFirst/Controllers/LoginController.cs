using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestDemoCodeDAL.DAL.DataConnection;
using TestDemoCodeDAL.DAL.Entity.Masters;

namespace TestDemoMVCCodeFirst.Controllers
{
    public class LoginController : Controller
    {
        DataContext db = new DataContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login() {

            return View();
        }
        [HttpPost]
        public  ActionResult Login(UserMaster User) {
            var data = db.UserMaster.Where(x => x.UserName == User.UserName && 
                                           x.PassWord==User.PassWord).FirstOrDefault();
            if (data != null)
            {
                Session["UserId"] = data.ID;
                ViewBag.Message = "Login successfully";
                ModelState.Clear();
                return RedirectToAction("Index","Home");
            }
            else {

                Session["UserId"] = null;
                ViewBag.Message = "User Name or Password Incorect";
                ModelState.Clear();
                return View();

            }
        }
    }
}