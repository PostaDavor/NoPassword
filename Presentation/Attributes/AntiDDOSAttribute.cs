using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace Presentation.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AntiDDOSAttribute : ActionFilterAttribute
    {
            public string ActionName { get; set; }
            public int ForbidRefreshIntervalInSeconds { get; set; }

            public override void OnActionExecuting(ActionExecutingContext context)
            {
                var key = string.Concat(ActionName, "-", context.HttpContext.Request.UserHostAddress);
                var allowExecute = false;

                if (HttpRuntime.Cache[key] == null)
                {
                    HttpRuntime.Cache.Add(key, true, null, DateTime.Now.AddSeconds(ForbidRefreshIntervalInSeconds), Cache.NoSlidingExpiration, CacheItemPriority.Low, null); 
                    allowExecute = true;
                }

                if (!allowExecute)
                {
                    context.Result = new ContentResult { Content = $"DDOS protection {ForbidRefreshIntervalInSeconds.ToString()} seconds." };
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.ServiceUnavailable;
                }
            }
    }
}