using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FirsrtWebAplication.Helps
{
    public class LogAttirbute
    {
        //public override void OnResultExecuting(ResultExecutingContext)
        //{
        //    Log("OnResultExecuting", filterContext.RouteData);
        //}

        private void Log(string methodName , RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = string.Format("{0} controller:{1} action{2}", methodName, controllerName, actionName);
            Debug.WriteLine(message);
            Debug.Flush();
        }
    }
}