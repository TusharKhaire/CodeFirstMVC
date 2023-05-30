using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestDemoCodeDAL.DAL.DataConnection;
using TestDemoCodeDAL.DAL.Entity.Masters;
using TestDemoCodeDAL.DAL;
using System.Net;
using System.Globalization;
using System.Data.Entity;

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
        [HttpGet]
        public ActionResult Edit(Guid ? id)
        {
            ViewBag.Message = null;
            if(id ==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            }
            ItemType it = db.ItemType.Find(id);
            if (it == null)
                return HttpNotFound();
            TempData["TypeId"] = id;
            TempData.Keep();
            return View(it);
        }
        [HttpPost]
        public ActionResult Edit(ItemType it)
        {
            ViewBag.Message = null;
            NumberFormatInfo formatprovider = new NumberFormatInfo();
            formatprovider.NumberDecimalSeparator = ",";
            formatprovider.NumberGroupSeparator = ".";
            formatprovider.NumberGroupSizes = new int[] { 2 };
            //Double  typecode = Convert.ToDouble(TempData["TypeId"],formatprovider);
           // var type = db.ItemType.Where(x => x.TypeId == typecode).FirstOrDefault();
            var type = db.ItemType.Where(x => x.TypeId == it.TypeId).FirstOrDefault();

            if (ModelState.IsValid)
            {
                if (type != null)
                {
                    type.TypeName = it.TypeName;
                    type.Details = it.Details;
                    db.Entry(type).State = EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.Message = "Type Modify Succesfully";
                    //ModelState.Clear();
                    return RedirectToAction("Index");
                }
                else
                    return View(it);
            }
            else
            return View(it);
        }

        public ActionResult Delete(Guid ?id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var it = db.ItemType.Find(id);
            if(it==null)
            {
                return HttpNotFound();
            }
            TempData["TypeId"] = id;
            TempData.Keep();
            return View(it);
        }
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            ItemType type = db.ItemType.Find(id);
            db.ItemType.Remove(type);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}