namespace TestDemoCodeDAL.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeUserid : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MenuMasters", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MenuMasters", "UserId", c => c.Int(nullable: false));
        }
    }
}
