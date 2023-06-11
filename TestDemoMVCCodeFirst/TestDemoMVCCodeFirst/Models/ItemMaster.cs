using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TestDemoCodeDAL.DAL.Entity.Masters;
using System.Web.Mvc;

namespace TestDemoMVCCodeFirst.Models
{
    public class ItemMaster
    {
        public ItemMaster() {
            lst_itemType = new List<DDLData>();
        }
        [Key]
        public Guid ItemCode { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public Guid ItemType { get; set; }
        [Range(0, 100, ErrorMessage = "Please enter Valid Gst up to 100 %")]
        public double Gst { get; set; }
        public string ItemTypeName { get; set; }
        public IList<SelectListItem> ItemListName { get; set; }
        public List<DDLData> lst_itemType { get;set;}
        public IList<SelectListItem> ItemTypeList { get; set; }
    }
    public class DDLData
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}