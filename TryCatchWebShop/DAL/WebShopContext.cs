using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TryCatchWebShop.DAL
{
    public class WebShopContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
    }
}