using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemoCodeDAL.DAL.Entity.Masters
{
    public class GodownMaster       //New Add table 
    {
        [Key]
        public Guid G_id { get; set; }
        [Required]
        public string G_Name { get; set; }
        [Required]
        public string Address { get; set; }
        public string Details { get; set; }

    }
}
