using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TryCatchWebShop.DAL;
using TryCatchWebShop.Models;

namespace TryCatchWebShop.Controllers
{
    public class ProductsController : ApiController
    {
        public IEnumerable<ProductVM> GetList(uint offset = 0, uint count = 0)
        {
            // Normally I would only use IQueryable and convert to a list onlt at the very end, 
            // but we have to read the whole XML file anyway.

            var products = ProductAccessor.Instance.LoadAllProducts()
                .OrderBy(p => p.Price)
                .Skip((int)offset);

            if (count > 0)
            {
                products = products.Take(count > 0 ? (int)count : 10); // Normally count would be taken from UI or default value from config
            }

            return products;
        }

        public ProductVM Get(Guid id)
        {
            return ProductAccessor.Instance.LoadAllProducts().First(p => p.Id == id);
        }

        public int GetTotalCount()
        {
            return ProductAccessor.Instance.LoadAllProducts().Count();
        }


    }
}
