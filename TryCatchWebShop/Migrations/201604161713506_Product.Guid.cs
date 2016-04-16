namespace TryCatchWebShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductGuid : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Products");
            AddColumn("dbo.Products", "Guid", c => c.Guid(nullable: false));
            AlterColumn("dbo.Products", "Id", c => c.String(maxLength: 32));
            AddPrimaryKey("dbo.Products", "Guid");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.Products", "Id", c => c.String(nullable: false, maxLength: 32));
            DropColumn("dbo.Products", "Guid");
            AddPrimaryKey("dbo.Products", "Id");
        }
    }
}
