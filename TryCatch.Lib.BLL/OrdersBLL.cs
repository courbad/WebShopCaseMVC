using System;
using System.Collections.Generic;
using System.Linq;
using TryCatch.Lib.DTO;
using TryCatch.Lib.Services;

namespace TryCatch.Lib.BLL
{
    public class OrdersBLL : IOrdersBLL
    {
        protected IOrderService _orderService;

        public OrdersBLL()
        {
            _orderService = new OrderService();
        }

        public Guid Create(Order order)
        {
            return _orderService.Insert(order);
        }

        public Order GetById(Guid id)
        {
            return _orderService.GetById(id);   
        }
    }
}
