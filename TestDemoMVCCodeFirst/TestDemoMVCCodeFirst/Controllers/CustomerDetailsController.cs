using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestDemoCodeDAL.DAL.DataConnection;
using TestDemoCodeDAL.DAL.Entity.Customer;
using TestDemoCodeDAL.DAL;
namespace TestDemoMVCCodeFirst.Controllers
{
    public class CustomerDetailsController : Controller
    {
        DataContext db = new DataContext();

        // GET: CustomerDetails
        public ActionResult Index()
        {
            return View(db.CustomerDetails.ToList());
        }

        // GET: CustomerDetails/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerDetails customerDetails = db.CustomerDetails.Find(id);
            if (customerDetails == null)
            {
                return HttpNotFound();
            }
            return View(customerDetails);
        }


        // POST: CustomerDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerName,Address,State,Dist,MobileNo,Email,DateOfBirth,OpeningBal,ClosingBal")] CustomerDetails customerDetails)
        {
            ViewBag.Message = null;
            if (String.IsNullOrEmpty(customerDetails.CustomerName))
            {
                ModelState.AddModelError("CustomerName", "Please Enter Customer Name");
                return View();
            }
            else if (String.IsNullOrEmpty(customerDetails.Address))
            {
                ModelState.AddModelError("Address", "Please Enter Address");
                return View();
            }
            else if (customerDetails.DateOfBirth == DateTime.Now)
            {
                ModelState.AddModelError("","Please Proper date of Birth");
                return View();
            }
            else 
            {
                customerDetails.Id = Guid.NewGuid();
                db.CustomerDetails.Add(customerDetails);
                db.SaveChanges();
                ViewBag.Message = "Customer  "+ customerDetails.CustomerName +" Saved";
                ModelState.Clear();
                return View();
            }

        }

        // GET: CustomerDetails/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerDetails customerDetails = db.CustomerDetails.Find(id);
            if (customerDetails == null)
            {
                return HttpNotFound();
            }
            return View(customerDetails);
        }

        // POST: CustomerDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerName,Address,State,Dist,MobileNo,Email,DateOfBirth,OpeningBal,ClosingBal")] CustomerDetails customerDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerDetails);
        }

        // GET: CustomerDetails/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerDetails customerDetails = db.CustomerDetails.Find(id);
            if (customerDetails == null)
            {
                return HttpNotFound();
            }
            return View(customerDetails);
        }

        // POST: CustomerDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CustomerDetails customerDetails = db.CustomerDetails.Find(id);
            db.CustomerDetails.Remove(customerDetails);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [HttpGet]
        public JsonResult GetCustomerByName(string searchText) {
            if (searchText != "") {
                var customerName = db.CustomerDetails.Where(a => a.CustomerName.Contains(searchText)).ToList();
                return Json(customerName.Select(q => new { id = q.Id, text = q.CustomerName }), JsonRequestBehavior.AllowGet);
            } return Json("",JsonRequestBehavior.AllowGet);
        }

    }
}
