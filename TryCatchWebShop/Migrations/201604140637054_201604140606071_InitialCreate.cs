namespace TryCatchWebShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201604140606071_InitialCreate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "Title", c => c.String(maxLength: 10));
            AlterColumn("dbo.Orders", "FirstName", c => c.String(nullable: false, maxLength: 66));
            AlterColumn("dbo.Orders", "LastName", c => c.String(nullable: false, maxLength: 66));
            AlterColumn("dbo.Orders", "Address", c => c.String(nullable: false, maxLength: 66));
            AlterColumn("dbo.Orders", "HouseNumber", c => c.String(maxLength: 10));
            AlterColumn("dbo.Orders", "ZipCode", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Orders", "City", c => c.String(nullable: false, maxLength: 24));
            AlterColumn("dbo.Orders", "EMail", c => c.String(nullable: false, maxLength: 55));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "EMail", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Orders", "City", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Orders", "ZipCode", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Orders", "HouseNumber", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Orders", "Address", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Orders", "LastName", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Orders", "FirstName", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Orders", "Title", c => c.String(maxLength: 4000));
        }
    }
}
