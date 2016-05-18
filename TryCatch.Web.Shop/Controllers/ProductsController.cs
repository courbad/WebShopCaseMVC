using System.Collections.Generic;
using TryCatch.Lib.DTO;
using TryCatch.Lib.BLL;
using System.Web.Http;

namespace TryCatch.Web.Shop.Controllers
{
    public class ProductsController : ApiController
    {
        private IProductsBLL _productsBLL;

        public ProductsController(IProductsBLL productsBLL)
        {
            _productsBLL = productsBLL;
        }

        [HttpGet]
        public IEnumerable<Product> GetList(uint offset = 0, uint count = 0)
        {
            throw new System.Exception("test ex");
            return _productsBLL.GetList((int)offset, (int)count);
        }

        [HttpGet]
        public IEnumerable<Product> GetMany([FromUri] string[] ids)
        {
            return _productsBLL.GetManyById(ids);
        }

        [HttpGet]
        public Product Get(string id)
        {
            return _productsBLL.GetById(id);
        }

        [HttpGet]
        public ProductDetails GetDetails(string id)
        {
            return _productsBLL.GetDetailsById(id);
        }

        [HttpGet]
        public int GetTotalCount()
        {
            return _productsBLL.GetTotalCount();
        }
    }
}
