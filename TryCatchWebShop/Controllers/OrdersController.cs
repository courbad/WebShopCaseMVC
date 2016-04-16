using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TryCatchWebShop.DAL;
using TryCatchWebShop.Models;

namespace TryCatchWebShop.Controllers
{
    public class OrdersController : ApiController
    {
        private WebShopContext _db = new WebShopContext();

        public IHttpActionResult PostOrder(OrderVM orderVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = CreateFromView(orderVM);
            _db.Orders.Add(order);

            try
            {
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(new { Id = order.Id });
        }

        private Order CreateFromView(OrderVM viewModel)
        {
            var orderCfg = new MapperConfiguration(cfg => cfg.CreateMap<OrderVM, Order>());
            var orderMapper = orderCfg.CreateMapper();

            var productCfg = new MapperConfiguration(cfg => cfg.CreateMap<ProductVM, Product>());
            var productMapper = productCfg.CreateMapper();

            var order = orderMapper.Map<Order>(viewModel);
            order.Id = Guid.NewGuid();

            // didn't want to sophisticate with join and grouping, so I left flattened collection
            IEnumerable<ProductVM> products = ProductAccessor.Instance.LoadAllProducts()
                .Where(p => viewModel.ProductIds.Contains(p.Id));

            order.Products = productMapper.Map<IEnumerable<Product>>(products) as ICollection<Product>;

            // set fields not covered by mapper
            (order.Products as List<Product>).ForEach(p =>
            {
                p.Count = viewModel.ProductIds.Count(id => id == p.Id);
            });

            return order;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}