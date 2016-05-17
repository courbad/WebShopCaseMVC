using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using TryCatch.Lib.Services;
using TryCatch.Lib.DTO;

namespace TryCatch.Lib.BLL
{
    public class ProductsBLL : IProductsBLL
    {
        private IProductService _productService;

        public ProductsBLL(string xmlDataPath)
        {
            _productService = new ProductService(xmlDataPath);
        }

        public void GenerateXML()
        {
            _productService.GenerateXML();
        }

        public IEnumerable<Product> GetList(int skip, int take)
        {
            var products = _productService.LoadAll()
                  .OrderBy(p => p.Price)
                  .Skip(skip);

            if (take > 0)
            {
                products = products.Take(take);
            }

            return products;
        }

        IList<Product> IProductsBLL.GetManyById(string[] ids)
        {
            return _productService.LoadAll().Where(p => ids.Contains(p.Id)).ToList();
        }

        Product IProductsBLL.GetById(string id)
        {
            return _productService.LoadAll().FirstOrDefault(p => p.Id == id);
        }

        public int GetTotalCount()
        {
            return _productService.LoadAll().Count();
        }

        public ProductDetails GetDetailsById(string id)
        {
            return new ProductDetails()
            {
                ImageFileName = "product.jpg",
                Popularity = (new Random()).Next(100),
                ProductId = id
            };
        }
    }
}
