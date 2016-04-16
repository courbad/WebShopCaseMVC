namespace TryCatchWebShop.Migrations
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orders");
        }
    }
}
