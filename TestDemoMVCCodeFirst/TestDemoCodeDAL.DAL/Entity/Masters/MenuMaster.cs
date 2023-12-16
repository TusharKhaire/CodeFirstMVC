using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemoCodeDAL.DAL.Entity.Masters
{
    public class MenuMaster
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
    }
}
