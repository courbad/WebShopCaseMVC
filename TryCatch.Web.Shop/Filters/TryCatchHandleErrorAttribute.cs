using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using NLog;
using System.Web.Mvc;
using System.Net.Http;
using System.Net;

namespace TryCatch.Web.Shop.Filters
{
    public class TryCatchHandleErrorAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            Logger.Instance.Error(context.Exception);
        }
    }
}