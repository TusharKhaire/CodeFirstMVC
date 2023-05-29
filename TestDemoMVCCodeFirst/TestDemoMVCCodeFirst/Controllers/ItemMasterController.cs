using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestDemoCodeDAL.DAL.DataConnection;
using TestDemoMVCCodeFirst.Models;

namespace TestDemoMVCCodeFirst.Controllers
{
    public class ItemMasterController : Controller
    {
        DataContext db = new DataContext();
        // GET: ItemMaster
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateItem()
        {
           ItemMaster viewmodel = new ItemMaster();
            List<SelectListItem> ItemTypeList =new List<SelectListItem>();
            List<DDLData> DlList = new List<DDLData>();
            foreach (var data in db.ItemType.ToList())
            {
                DDLData Dl = new DDLData();
                Dl.Text = data.TypeName;
                Dl.Value = data.TypeId.ToString();
                DlList.Add(Dl);
            }

            viewmodel.lst_itemType = DlList;
            return View(viewmodel);
        }
    }
}