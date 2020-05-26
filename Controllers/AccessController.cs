using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoPr1mal.Models;

namespace ProyectoPr1mal.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter (string Nip, string Pass)
        {
            try
            {

                using (Pr1malRegistrosEntities db = new Pr1malRegistrosEntities())
                {
                    var lst = from d
                              in db.RegistroEmple
                              where d.Nip == Nip && d.Pass == Pass && d.idState == 1
                              select d;
                    if (lst.Count() > 0)
                    {
                        RegistroEmple oRegistro = lst.First();
                        Session["RegistroEmple"] = oRegistro;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Nip ó contrasela no encontrados");
                    }
                }

                
            }
            catch(Exception e)
            {
                return Content("Ocurrio un error" + e.Message);
            }
        }
    }
}