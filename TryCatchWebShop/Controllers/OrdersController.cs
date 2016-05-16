using System.Linq;
using System.Collections.Generic;
using OrderViewModel = TryCatch.Web.ViewModels.Order;
using ProductViewModel = TryCatch.Web.ViewModels.Product;
using OrderDTO = TryCatch.Lib.DTO.Order;
using ProductDTO = TryCatch.Lib.DTO.Product;
using TryCatch.Lib.BLL;
using AutoMapper;
using System.Web.Http;

namespace TryCatch.Web.Shop.Controllers
{
    public class OrdersController : ApiController
    {
        private IOrdersBLL _ordersBLL;
        private IProductsBLL _productsBLL;

        public OrdersController(IOrdersBLL ordersBLL, IProductsBLL productsBLL )
        {
            _ordersBLL = ordersBLL;
            _productsBLL = productsBLL;
        }

        [HttpPost]
        public IHttpActionResult PostOrder([FromBody] OrderViewModel order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _ordersBLL.Create(CreateFromView(order));

            return Ok(new { }); // empty object to please jQuery
        }

        private OrderDTO CreateFromView(OrderViewModel viewModel)
        {
            var orderCfg = new MapperConfiguration(cfg => cfg.CreateMap<OrderViewModel, OrderDTO>());
            var orderMapper = orderCfg.CreateMapper();

            //var productCfg = new MapperConfiguration(cfg => cfg.CreateMap<ProductViewModel, ProductDTO>());
            //var productMapper = productCfg.CreateMapper();

            var order = orderMapper.Map<OrderDTO>(viewModel);

            var productInfo = _productsBLL.GetManyById(viewModel.ProductIds);

            order.Products = new List<ProductDTO>();
            foreach (string id in viewModel.ProductIds)
            {
                //productMapper.Map<ProductDTO>(entity)
                order.Products.Add(productInfo.First(p => p.Id == id));
            }

            return order;
        }
    }
}
