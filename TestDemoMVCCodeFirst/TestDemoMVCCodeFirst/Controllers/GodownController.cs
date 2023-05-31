using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestDemoCodeDAL.DAL.Entity.Masters;
using TestDemoCodeDAL.DAL.DataConnection;
using System.Data.Entity;

namespace TestDemoMVCCodeFirst.Controllers
{
    public class GodownController : Controller
    {
        DataContext dbconn = new DataContext();
        // GET: Godown
        public ActionResult Index()
        {
            return View(dbconn.godownMaster.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind] GodownMaster Gm)
        {
            ViewBag.Message = null;
            if (String.IsNullOrEmpty(Gm.G_Name))
            {
                ModelState.AddModelError("G_Name", "Please Enter Godown Name");
                ViewBag.Message = "Enter Godown Name";
                return View(Gm);
            }
            else if (String.IsNullOrEmpty(Gm.Address))
            {
                ModelState.AddModelError("Address","Please Enter Address");
                ViewBag.Message = "Enter Godown Address";
                return View(Gm);

            }
            else
            {
                Gm.G_id =  Guid.NewGuid();
                dbconn.godownMaster.Add(Gm);
                dbconn.SaveChanges();
                ViewBag.Message = "Godown "+Gm.G_Name +" Added";
                ModelState.Clear();
                return View();

            }
        }
    }
}