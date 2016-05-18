using System.Configuration;
using System.Web;

namespace TryCatch.Web.Shop
{
    public class JsResourcesConfig
    {
        public static void Init()
        {
            var fullPath = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["JsResourcesFileLocation"]);
            var generator = new JsResourcesGenerator(fullPath);
            throw new System.Exception("test ex");
            generator.GenerateJsResourcesFile();
        }
    }
}