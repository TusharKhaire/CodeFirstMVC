using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestDemoCodeDAL.DAL.DataConnection;
using TestDemoCodeDAL.DAL.Entity.Masters;
using TestDemoCodeDAL.DAL;

namespace TestDemoMVCCodeFirst.Controllers
{
    public class ItemTypeController : Controller
    {
        DataContext db = new DataContext();
        // GET: ItemType
        public ActionResult Index()
        {
            return View(db.ItemType.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] ItemType type)
        {
            if (String.IsNullOrEmpty(type.TypeName))
            {
                ModelState.AddModelError("TypeName","Please Enter Item Type");
                return View();
            }
            else 
            {
                type.TypeId = Guid.NewGuid() ;
                db.ItemType.Add(type);
                db.SaveChanges();
                ViewBag.Message = "Item Type "+type.TypeName +" Saved";
                ModelState.Clear();
                return View();
            }
        }
    }
}