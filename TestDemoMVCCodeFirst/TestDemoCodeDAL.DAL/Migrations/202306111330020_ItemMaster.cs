namespace TestDemoCodeDAL.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemMaster : DbMigration
    {
        public override void Up()
        {
            //AlterColumn("dbo.ItemMasters", "ItemType", c => c.Guid(nullable: false));

            CreateTable(
               "dbo.ItemMasters",
               c => new
               {
                   ItemCode = c.Guid(nullable: false),
                   ItemName = c.String(nullable: false),
                   ItemType = c.Guid(nullable: false),
                   Gst = c.Double(nullable: false),
               })
               .PrimaryKey(t => t.ItemCode);

        }

        public override void Down()
        {
            //AlterColumn("dbo.ItemMasters", "ItemType", c => c.Long(nullable: false));
            DropTable("dbo.ItemMasters");

        }
    }
}
