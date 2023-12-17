using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemoCodeDAL.DAL.Entity.Masters
{
   public class MenuAccess
    {
        [Key]
        public int Id { get; set; }
        public int userId { get; set; }
        public int MenuId { get; set; }
    }
}
