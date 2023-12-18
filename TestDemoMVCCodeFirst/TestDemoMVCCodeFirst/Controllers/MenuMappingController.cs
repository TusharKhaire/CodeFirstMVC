using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using TestDemoCodeDAL.DAL.DataConnection;
using TestDemoCodeDAL.DAL.Entity.Masters;
using TestDemoMVCCodeFirst.ViewModel;

namespace TestDemoMVCCodeFirst.Controllers
{
    public class MenuMappingController : Controller
    {
        DataContext db = new DataContext();
        // GET: MenuMapping
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult setMenuMapping() {
            SetMenu menu = new SetMenu();
            menu.UserList = db.UserMaster.ToList();
            menu.MenuList = db.MenuMaster.ToList();
            return View(menu);
        }
        [HttpPost]
        public ActionResult setMenuMapping(SetMenu menu)
        {
            int selectedUserId = menu.SelectedUserId;
            var records = db.MenuAccess.Where(a => a.userId == selectedUserId).ToList();
            if (records.Any())
            {
                db.MenuAccess.RemoveRange(records);
                db.SaveChanges();
            }
            List<int> selectedMenuIds = menu.MenuList.Where(m => m.IsChecked).Select(m => m.ID).ToList();

            foreach (int menuId in selectedMenuIds)
            {
                var mapping = new MenuAccess()
                {
                    userId = selectedUserId,
                    MenuId = menuId
                };
                db.MenuAccess.Add(mapping);
                db.SaveChanges();
            }
            return RedirectToAction("setMenuMapping", "MenuMapping"); 
        }

    }
}