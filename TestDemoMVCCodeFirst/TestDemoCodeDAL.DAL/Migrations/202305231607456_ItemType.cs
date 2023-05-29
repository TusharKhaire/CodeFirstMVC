namespace TestDemoCodeDAL.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemTypes",
                c => new
                    {
                        TypeId = c.Guid(nullable: false),
                        TypeName = c.String(nullable: false),
                        Details = c.String(),
                    })
                .PrimaryKey(t => t.TypeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ItemTypes");
        }
    }
}
