using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoPr1mal.Models;
using ProyectoPr1mal.Models.ClienteTablaViewModels;
using ProyectoPr1mal.Models.ClienteUserViewModel;

namespace ProyectoPr1mal.Controllers
{
    public class ClienteUserController : Controller
    {
        // GET: ClienteUser

        //inicio de mostrar datos personales del cliente
        public ActionResult DatosCliente()
        {
            List<ClienteUserTablaViewModel> lst = null;

            using (Pr1malRegistrosEntities db = new Pr1malRegistrosEntities())
            {
                lst = (from c
                       in db.RegistroClien
                       where c.isState == 1
                       orderby c.Nip
                       select new ClienteUserTablaViewModel
                       {
                           Id = c.Id,
                           Nombre = c.Nombre,
                           Nacimiento = c.Nacimiento,
                           Genero = c.Genero,
                           Edad = c.Edad,
                           Celular = c.Celular,
                           Direccion= c.Direccion,
                           Registro = c. Registro,
                           Nip = c.Nip,
                           Email = c.Email
                       }).ToList();
            }

            return View(lst);
        }
        //Fin de mostrar datos personales del cliente

        //Inicio de mostrar datos fisicos del cliente

        public ActionResult ClienteFisi()
        {
            List<ClienteUserTablaViewModel> lst = null;

            using (Pr1malRegistrosEntities db = new Pr1malRegistrosEntities())
            {
                lst = (from c
                       in db.RegistroClien
                       where c.isState == 1
                       orderby c.Nip
                       select new ClienteUserTablaViewModel
                       {
                           Id = c.Id,
                           Nombre = c.Nombre,
                           Altura = c.Altura,
                           Peso = c.Peso,
                           Imc = c.Imc,
                           Corporal = c.Corporal,
                           Metabolismo = c.Metabolismo,
                           Grasa = c.Grasa,
                           Musculo = c.Musculo
                       }).ToList();
            }
            return View(lst);
        }

        //Fin de mostrar datos fisicos del cliente

        //Inicio de registros de clientes
        [HttpGet]
        public ActionResult RegistroClientes()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegistroClientes(ClienteUserViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new Pr1malRegistrosEntities())
            {
                RegistroClien oCliente = new RegistroClien();

                oCliente.isState = 1;

                oCliente.Nombre = model.Nombre;
                oCliente.Nacimiento = model.Nacimiento;
                oCliente.Genero = model.Genero;
                oCliente.Edad = model.Edad;
                oCliente.Celular = model.Celular;
                oCliente.Direccion = model.Direccion;
                oCliente.Registro = model.Registro;
                oCliente.Nip = model.Nip;
                oCliente.Email = model.Email;
                oCliente.Altura = model.Altura;
                oCliente.Peso = model.Peso;
                oCliente.Imc = model.Imc;
                oCliente.Corporal = model.Corporal;
                oCliente.Metabolismo = model.Metabolismo;
                oCliente.Grasa = model.Grasa;
                oCliente.Musculo = model.Musculo;
                oCliente.Numero = model.Numero;
                oCliente.Observaciones = model.Observaciones;

                db.RegistroClien.Add(oCliente);

                db.SaveChanges();
            }

            return Redirect(Url.Content("~/Home/"));
        }
        //Fin del registro de clientes

        //Inicio de la edicion de datos del cliente
        public ActionResult EditarCliente(int Id)
        {
            EditUserViewModel model = new EditUserViewModel();

            using (var db = new Pr1malRegistrosEntities())
            {
                var oCliente = db.RegistroClien.Find(Id);

                model.Id = oCliente.Id;
                model.Nombre = oCliente.Nombre;
                //model.Nacimiento = oCliente.Nacimiento;
                //model.Genero = oCliente.Genero;
                //model.Edad = oCliente.Edad;
                model.Celular = oCliente.Celular;
                model.Direccion = oCliente.Direccion;
                //model.Registro = oCliente.Registro;
                //model.Nip = oCliente.Nip;
                //model.Email = oCliente.Email;
                model.Altura = oCliente.Altura;
                model.Peso = oCliente.Peso;
                model.Imc = oCliente.Imc;
                model.Corporal = oCliente.Corporal;
                model.Metabolismo = oCliente.Metabolismo;
                model.Grasa = oCliente.Grasa;
                model.Musculo = oCliente.Musculo;
                model.Numero = oCliente.Numero;
                model.Observaciones = oCliente.Observaciones;
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult EditarCliente(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using(var db = new Pr1malRegistrosEntities())
            {
                var oCliente = db.RegistroClien.Find(model.Id);

                oCliente.Nombre = model.Nombre;
                //oCliente.Nacimiento = model.Nacimiento;
                //oCliente.Genero = model.Genero;
                //oCliente.Edad = model.Edad;
                oCliente.Celular = model.Celular;
                oCliente.Direccion = model.Direccion;
                //oCliente.Registro = model.Registro;
                //oCliente.Nip = model.Nip;
                //oCliente.Email = model.Email;
                oCliente.Altura = model.Altura;
                oCliente.Peso = model.Peso;
                oCliente.Imc = model.Imc;
                oCliente.Corporal = model.Corporal;
                oCliente.Metabolismo = model.Metabolismo;
                oCliente.Grasa = model.Grasa;
                oCliente.Musculo = model.Musculo;
                oCliente.Numero = model.Numero;
                oCliente.Observaciones = model.Observaciones;

                db.Entry(oCliente).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }

            return Redirect(Url.Content("~/Home/"));
        }
        //Fin de la edicion de datos del cliente

        //Inicio de la elimicion de cliente
        [HttpPost]
        public ActionResult EliminarCliente(int Id)
        {
            using (var db = new Pr1malRegistrosEntities())
            {
                var ocliente = db.RegistroClien.Find(Id);
                ocliente.isState = 3;

                db.Entry(ocliente).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

            return Content("1");
        }
        //Fin de la eliminacio de cliente
    }
}