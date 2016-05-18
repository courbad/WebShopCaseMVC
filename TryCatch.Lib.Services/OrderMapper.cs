using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using OrderDTO = TryCatch.Lib.DTO.Order;
using OrderEntity = TryCatch.Lib.Services.Entities.Order;
using ProductDTO = TryCatch.Lib.DTO.Product;
using ProductEntity = TryCatch.Lib.Services.Entities.Product;

namespace TryCatch.Lib.Services
{
    public class EntityMapper
    {
        public static OrderEntity MapOrderFromDto(OrderDTO orderDto)
        {
            var orderCfg = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<OrderDTO, OrderEntity>()
                .ForMember(o => o.Products, opt => opt.Ignore());
            });

            var productCfg = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDTO, ProductEntity>();
            });

            var orderMapper = orderCfg.CreateMapper();
            var productMapper = productCfg.CreateMapper();

            var order = orderMapper.Map<OrderEntity>(orderDto);

            orderDto.Products.Distinct().All(productDto => 
            {
                var product = productMapper.Map<ProductEntity>(productDto);
                product.Count = orderDto.Products.Count(p => p.Id == productDto.Id);
                order.Products.Add(product);
                return true;
            });

            return order;
        }

        public static OrderDTO MapOrderToDto(OrderEntity orderEntity)
        {
            var orderCfg = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OrderEntity, OrderDTO>();
                cfg.CreateMap<ProductEntity, ProductDTO>();
            });

            var orderMapper = orderCfg.CreateMapper();

            return orderMapper.Map<OrderDTO>(orderEntity);
        }

    }
}
