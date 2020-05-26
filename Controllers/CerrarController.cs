using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoPr1mal.Controllers
{
    public class CerrarController : Controller
    {
        public ActionResult LogOff()
        {
            Session["RegistroEmple"] = null;
            return RedirectToAction("Index", "Access");
        }
    }
}
