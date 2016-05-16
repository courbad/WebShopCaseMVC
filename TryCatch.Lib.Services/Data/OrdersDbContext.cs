using System.Data.Entity;
using TryCatch.Lib.Services.Entities;

namespace TryCatch.Lib.Services
{
    public class OrdersDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
    }
}