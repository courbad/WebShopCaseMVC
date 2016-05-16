using System.Configuration;
using System.Web;
using TryCatch.Lib.BLL;

namespace TryCatch.Web.Shop
{
    public class ProductRepositoryConfig
    {
        public static void Init()
        {
            var fullPath = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ProductsXmlFileLocation"]);
            var productsBll = new ProductsBLL(fullPath);

            productsBll.GenerateXML();
        }
    }
}