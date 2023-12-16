using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDemoCodeDAL.DAL.Entity;
using TestDemoCodeDAL.DAL.DataConnection;
using TestDemoCodeDAL.DAL.Entity.Customer;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using TestDemoCodeDAL.DAL.Entity.Masters;

namespace TestDemoCodeDAL.DAL.DataConnection
{
   public class DataContext : IdentityDbContext<Users>
    {
        public DataContext(): base("TestDemoCodeFirst"){}
        public DbSet<CustomerDetails> CustomerDetails { get; set; }
       
        public DbSet<ItemType> ItemType { get; set; }
        public DbSet<ItemMaster> ItemMaster { get; set; }
        public DbSet<GodownMaster> godownMaster { get; set; }  //31-05-2023
        public DbSet<UserMaster> UserMaster { get; set; }  //16-12-2023
        public DbSet<MenuMaster> MenuMaster { get; set; }  //16-12-2023

    }
}
