using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirsrtWebAplication.Helps
{
    public class AutorizeFilter : FilterAttribute, IAuthorizationFilter

    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if(filterContext.HttpContext.Session["RoleName"] != null)
            {
                if (filterContext.HttpContext.Session["RoleName"].ToString() != "Admin")
                {
                    filterContext.Result = 
                        
                        new ViewResult
                    {
                        ViewName = "LogInError"
                    };

                }
            }
          
        }
    }
}