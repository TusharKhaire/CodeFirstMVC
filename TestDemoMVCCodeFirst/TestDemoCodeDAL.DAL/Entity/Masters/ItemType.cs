using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemoCodeDAL.DAL.Entity.Masters
{
   public  class ItemType
    {
        [Key]
        public Guid TypeId { get; set; }
        [Required,Display(Name ="Type Name")]
        public string TypeName { get; set; }
        public string Details { get; set; }
    }
}
