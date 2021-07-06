using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirsrtWebAplication.Helps
{
    public class MyHendleError : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            Log(filterContext.Exception);
        }

        private void Log(Exception exception)
        {
            Debug.WriteLine(exception.Message);
        }
    }
}