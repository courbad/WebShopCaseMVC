using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;
using TryCatch.Web.Shop.Filters;

namespace TryCatch.Web.Shop
{
    public class FilterConfig
    {
        // mvc filters
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        // web api filters
        public static void RegisterHttpFilters(HttpFilterCollection filters)
        {
            filters.Add(new TryCatchHandleErrorAttribute());
        }
    }
}
