namespace TryCatch.Lib.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(maxLength: 10),
                        FirstName = c.String(nullable: false, maxLength: 66),
                        LastName = c.String(nullable: false, maxLength: 66),
                        Address = c.String(nullable: false, maxLength: 66),
                        HouseNumber = c.String(maxLength: 10),
                        ZipCode = c.String(nullable: false, maxLength: 12),
                        City = c.String(nullable: false, maxLength: 24),
                        Email = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Id = c.String(maxLength: 4000),
                        Name = c.String(nullable: false, maxLength: 255),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Count = c.Int(nullable: false),
                        Order_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Order_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Products", new[] { "Order_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
        }
    }
}
