using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDemoCodeDAL.DAL.Entity.Masters;


namespace TestDemoCodeDAL.DAL.Entity.Masters
{
    public class ItemMaster   
    {
        [Key]
        public Guid ItemCode { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public long ItemType { get; set; }
        [Range (0,100,ErrorMessage ="Please enter Valid Gst up to 100 %")]
        public double Gst { get; set; }
    }
    
}
