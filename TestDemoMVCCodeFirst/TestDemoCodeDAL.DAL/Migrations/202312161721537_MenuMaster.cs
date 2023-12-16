namespace TestDemoCodeDAL.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MenuMaster : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuMasters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentId = c.Int(nullable: false),
                        Url = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MenuMasters");
        }
    }
}
