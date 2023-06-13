using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestDemoCodeDAL.DAL.DataConnection;
using TestDemoCodeDAL.DAL.Entity.Masters;
using TestDemoMVCCodeFirst.Models;
using ItemMaster = TestDemoMVCCodeFirst.Models.ItemMaster;

namespace TestDemoMVCCodeFirst.Controllers
{
    public class ItemMasterController : Controller
    {
        DataContext db = new DataContext();
        // GET: ItemMaster
        public ActionResult Index()
        {
            ItemMaster item = new ItemMaster();
            var result = db.ItemMaster.ToList();
            List<ItemMaster> Itemlist = new List<ItemMaster>();
            foreach (var type in result)
            {
                ItemMaster im = new ItemMaster();
                var itemtypedata = db.ItemType.Where(x => x.TypeId == type.ItemType).FirstOrDefault();
                im.ItemCode = type.ItemCode;
                im.ItemName = type.ItemName;
                im.ItemTypeName = itemtypedata.TypeName;
                im.Gst = type.Gst;
                Itemlist.Add(im);
            }
            return View(Itemlist);
        }
        [HttpGet]
        public ActionResult CreateItem()
        {
            ItemMaster viewmodel = new ItemMaster();
            List<SelectListItem> ItemTypeList = new List<SelectListItem>();
            List<DDLData> DlList = new List<DDLData>();
            foreach (var data in db.ItemType.ToList())
            {
                DDLData Dl = new DDLData();
                Dl.Text = data.TypeName;
                Dl.Value = data.TypeId.ToString();
                DlList.Add(Dl);
                ItemTypeList.Add(new SelectListItem { Text = data.TypeName, Value = data.TypeId.ToString() });
            }
            viewmodel.ItemTypeList = ItemTypeList;
            viewmodel.lst_itemType = DlList;
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult CreateItem(ItemMaster item)
        {
            ItemMaster viewmodel = new ItemMaster();
            List<SelectListItem> ItemTypeList = new List<SelectListItem>();
            List<DDLData> DlList = new List<DDLData>();
            foreach (var data in db.ItemType.ToList())
            {
                DDLData Dl = new DDLData();
                Dl.Text = data.TypeName;
                Dl.Value = data.TypeId.ToString();
                DlList.Add(Dl);
                ItemTypeList.Add(new SelectListItem { Text = data.TypeName, Value = data.TypeId.ToString() });

            }
            viewmodel.ItemTypeList = ItemTypeList;
            viewmodel.lst_itemType = DlList;
            ViewBag.Message = null;
            if (item != null)
            {
                if (String.IsNullOrEmpty(item.ItemName))
                {
                    ModelState.AddModelError("ItemName", "Please Enter ItemName");
                    return View(viewmodel);
                }
                else if (item.ItemType == null)
                {
                    ModelState.AddModelError("ItemType", "Please Select Valid Item Type");
                    return View(viewmodel);

                }
                var checkexist = db.ItemMaster.Where(x => x.ItemCode == item.ItemCode).FirstOrDefault();
                if (checkexist != null)
                {
                    ViewBag.Message = "Item " + item.ItemName + " Alredy exist";
                    return View(viewmodel);

                }
                TestDemoCodeDAL.DAL.Entity.Masters.ItemMaster newItem = new TestDemoCodeDAL.DAL.Entity.Masters.ItemMaster();
                newItem.ItemCode = Guid.NewGuid();
                newItem.ItemName = item.ItemName;
                newItem.ItemType = item.ItemType;
                newItem.Gst = item.Gst;
                db.ItemMaster.Add(newItem);
                db.SaveChanges();
                ViewBag.Message = "Item " + item.ItemName + " Saved";
                ModelState.Clear();

                return View(viewmodel);
            }
            else
            {
                ViewBag.Message = "Please Enter Valid Details";
                return View(viewmodel);
            }
        }
        [HttpGet]
        public ActionResult EditItem(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var item = db.ItemMaster.Where(x => x.ItemCode == id).FirstOrDefault();
            if (item == null)
            {
                return HttpNotFound();
            }
            TestDemoMVCCodeFirst.Models.ItemMaster viewmodel = new TestDemoMVCCodeFirst.Models.ItemMaster();
            List<SelectListItem> itemtype = new List<SelectListItem>();
            List<ItemType> typelist = db.ItemType.ToList();
            viewmodel.ItemCode = item.ItemCode;
            viewmodel.ItemName = item.ItemName;
            viewmodel.Gst = item.Gst;

            foreach (var typename in db.ItemType.ToList())
            {
                itemtype.Add(new SelectListItem { Text = typename.TypeName, Value = typename.TypeId.ToString() });
            }
            viewmodel.ItemTypeList = itemtype;
            viewmodel.ItemType = item.ItemType;
            TempData["itemcode"] = id;
            TempData.Keep();
            return View("CreateItem", viewmodel);
        }

        [HttpPost]
        public ActionResult EditItem(ItemMaster item)
        {
            ItemMaster viewmodel = new ItemMaster();
            List<SelectListItem> ItemTypeList = new List<SelectListItem>();
            List<DDLData> DlList = new List<DDLData>();
            foreach (var data in db.ItemType.ToList())
            {
                DDLData Dl = new DDLData();
                Dl.Text = data.TypeName;
                Dl.Value = data.TypeId.ToString();
                DlList.Add(Dl);
                ItemTypeList.Add(new SelectListItem { Text = data.TypeName, Value = data.TypeId.ToString() });

            }
            viewmodel.ItemTypeList = ItemTypeList;
            viewmodel.lst_itemType = DlList;
            ViewBag.Message = null;
            if (item != null)
            {
                if (String.IsNullOrEmpty(item.ItemName))
                {
                    ModelState.AddModelError("ItemName", "Please Enter ItemName");
                    //return View(viewmodel);
                    return View("CreateItem", viewmodel);
                }
                else if (item.ItemType == null)
                {
                    ModelState.AddModelError("ItemType", "Please Select Valid Item Type");
                    //return View(viewmodel);
                    return View("CreateItem", viewmodel);
                }
                var checkexist = db.ItemMaster.Where(x => x.ItemCode == item.ItemCode).FirstOrDefault();
                if (checkexist == null)
                {
                    ViewBag.Message = "Please Enter Valid Details";
                    return View(viewmodel);
                }
                checkexist.ItemName = item.ItemName;
                checkexist.ItemType = item.ItemType;
                checkexist.Gst = item.Gst;
                db.Entry(checkexist).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.Message = "Item " + item.ItemName + " Modify";
                ModelState.Clear();
                ItemMaster itemobj = new ItemMaster();
                var result = db.ItemMaster.ToList();
                List<ItemMaster> Itemlist = new List<ItemMaster>();
                foreach (var type in result)
                {
                    ItemMaster im = new ItemMaster();
                    var itemtypedata = db.ItemType.Where(x => x.TypeId == type.ItemType).FirstOrDefault();
                    im.ItemCode = type.ItemCode;
                    im.ItemName = type.ItemName;
                    im.ItemTypeName = itemtypedata.TypeName;
                    im.Gst = type.Gst;
                    Itemlist.Add(im);
                }
                return View("Index",Itemlist);
                //return View("Index");
            }
            else
            {
                ViewBag.Message = "Please Enter Valid Details";
                //return View(viewmodel);
                return View("CreateItem", viewmodel);
            }
        }
        public ActionResult Delete(Guid? id)
        {
            var result = db.ItemMaster.ToList();
            List<ItemMaster> Itemlist = new List<ItemMaster>();
            foreach (var type in result)
            {
                ItemMaster im = new ItemMaster();
                var itemtypedata = db.ItemType.Where(x => x.TypeId == type.ItemType).FirstOrDefault();
                im.ItemCode = type.ItemCode;
                im.ItemName = type.ItemName;
                im.ItemTypeName = itemtypedata.TypeName;
                im.Gst = type.Gst;
                Itemlist.Add(im);
            }
            var checkexist = db.ItemMaster.Where(x => x.ItemCode == id).FirstOrDefault();
            if (checkexist == null)
            {
                ViewBag.Message = "Please Enter Valid Details";
                return View("Index", Itemlist);
            }
            db.ItemMaster.Remove(checkexist);
            //db.Entry(checkexist).State = EntityState.Modified;
            db.SaveChanges();
            ViewBag.Message = "Item " + checkexist.ItemName + " Deleted";
            ModelState.Clear();
            var result1 = db.ItemMaster.ToList();
            List<ItemMaster> Itemlist1 = new List<ItemMaster>();
            foreach (var type in result1)
            {
                ItemMaster im = new ItemMaster();
                var itemtypedata = db.ItemType.Where(x => x.TypeId == type.ItemType).FirstOrDefault();
                im.ItemCode = type.ItemCode;
                im.ItemName = type.ItemName;
                im.ItemTypeName = itemtypedata.TypeName;
                im.Gst = type.Gst;
                Itemlist1.Add(im);
            }
            return View("Index", Itemlist1);
        }
    }
}