namespace TestDemoCodeDAL.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_UserID_in_MenuMaster : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MenuMasters", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MenuMasters", "UserId");
        }
    }
}
