using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemoCodeDAL.DAL.Entity.Masters
{
    public class UserMaster
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage ="Please Fill User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Fill Password")]
        public string PassWord { get; set; }
        public bool isActive { get; set; } = true;
    }
}
