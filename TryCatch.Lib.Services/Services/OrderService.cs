using System;
using System.Linq;
using System.Data.Entity;
using OrderDTO = TryCatch.Lib.DTO.Order;

namespace TryCatch.Lib.Services
{
    public class OrderService : IOrderService
    {
        public OrderDTO GetById(Guid id)
        {
            using (var context = new OrdersDbContext())
            {
                var entity = context.Orders
                    .Include(o => o.Products)
                    .FirstOrDefault(o => o.Id == id);

                return EntityMapper.MapOrderToDto(entity);
            }
        }

        public Guid Insert(OrderDTO order)
        {
            var entity = EntityMapper.MapOrderFromDto(order);
            entity.Id = Guid.NewGuid();

            using (var context = new OrdersDbContext())
            {
                context.Orders.Add(entity);
                context.SaveChanges();
            }

            return entity.Id;
        }
    }
}
