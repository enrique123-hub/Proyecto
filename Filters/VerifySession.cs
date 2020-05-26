using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoPr1mal.Controllers;
using ProyectoPr1mal.Models;

namespace ProyectoPr1mal.Filters
{
    public class VerifySession  :   ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

            var oRegistro = (RegistroEmple)HttpContext.Current.Session["RegistroEmple"];

            if (oRegistro == null)
            {
                if (filterContext.Controller is AccessController == false)
                {
                    filterContext.HttpContext.Response.Redirect("/Access/index");
                }
            }

            base.OnActionExecuted(filterContext);
        }
    }
}