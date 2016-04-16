namespace TryCatchWebShop.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TryCatchWebShop.DAL.WebShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "TryCatchWebShop.DAL.WebShopContext";
        }

        protected override void Seed(TryCatchWebShop.DAL.WebShopContext context)
        {

        }
    }
}
