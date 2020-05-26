using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoPr1mal.Models;
using ProyectoPr1mal.Models.TablaViewModels;
using ProyectoPr1mal.Models.UserViewModel;

namespace ProyectoPr1mal.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        //Inicio del mostrar datos personales
        public ActionResult Index()
        {
            List<UserTablaViewModels> lst = null;
            using(Pr1malRegistrosEntities db = new Pr1malRegistrosEntities())
            {
                lst = (from d
                      in db.RegistroEmple
                      where d.idState == 1
                      orderby d.Nip
                      select new UserTablaViewModels
                      {
                          Id = d.Id,
                          Nombre = d.Nombre,
                          Namiento = d.Namiento,
                          Genero = d.Genero,
                          Edad = d.Edad,
                          Celular = d.Celular,
                          Direccion = d.Direccion,
                          Registro = d.Registro,
                          Nip = d.Nip,
                          Email = d.Email
                      }).ToList();
            }

            return View(lst);
        }//Fin del mostrar datos personales

        //Inicio de mostrar datos fisicos

        public ActionResult IndexFisi()
        {
            List<UserTablaViewModels> fis = null;
            using (var db = new Pr1malRegistrosEntities())
            {
                fis = (from d
                       in db.RegistroEmple
                       where d.idState == 1
                       orderby d.Nip
                       select new UserTablaViewModels
                       {
                           Id = d.Id,
                           Nombre = d.Nombre,
                           Altura = d.Altura,
                           Peso = d.Peso,
                           Imc = d.Imc,
                           Corporal = d.Corporal,
                           Metabolismo = d.Metabolismo,
                           Grasa = d.Grasa,
                           Musculo = d.Musculo
                           
                       }).ToList();
            }
            return View(fis);
        }

        //Fin de mostrar daatos fisicos

        //Inicio del add
        [HttpGet]
        public ActionResult add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult add(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new Pr1malRegistrosEntities())
            {
                RegistroEmple oRegistro = new RegistroEmple();

                oRegistro.idState = 1;

                oRegistro.Nombre= model.Nombre;
                oRegistro.Namiento= model.Namiento;
                oRegistro.Genero= model.Genero;
                oRegistro.Edad= model.Edad;
                oRegistro.Celular= model.Celular;
                oRegistro.Direccion= model.Direccion;
                oRegistro.Registro= model.Registro;
                oRegistro.Nip= model.Nip;
                oRegistro.Email= model.Email;
                oRegistro.Pass= model.Pass;
                oRegistro.Altura= model.Altura;
                oRegistro.Peso= model.Peso;
                oRegistro.Imc= model.Imc;
                oRegistro.Corporal= model.Corporal;
                oRegistro.Metabolismo= model.Metabolismo;
                oRegistro.Grasa= model.Grasa;
                oRegistro.Musculo= model.Musculo;
                oRegistro.Numero= model.Numero;
                oRegistro.Observciones= model.Observciones;

                db.RegistroEmple.Add(oRegistro);

                db.SaveChanges();
            }
            return Redirect(Url.Content("~/User/"));
        }
        //Fin de add

        //Inicio del edit
        public ActionResult Edit(int id)
        {
            EditUserViewModel model = new EditUserViewModel();

            using (var db = new Pr1malRegistrosEntities())
            {
                var oRegistro = db.RegistroEmple.Find(id);

                model.Id = oRegistro.Id;
                model.Nombre = oRegistro.Nombre;
                /*model.Namiento = oRegistro.Namiento;
                model.Genero = oRegistro.Genero;
                model.Edad = oRegistro.Edad;*/
                model.Celular = oRegistro.Celular;
                model.Direccion = oRegistro.Direccion;
                /*model.Registro = oRegistro.Registro;
                model.Nip = oRegistro.Nip;
                model.Email = oRegistro.Email;*/
                model.Altura = oRegistro.Altura;
                model.Peso = oRegistro.Peso;
                model.Imc = oRegistro.Imc;
                model.Corporal = oRegistro.Corporal;
                model.Metabolismo = oRegistro.Metabolismo;
                model.Grasa = oRegistro.Grasa;
                model.Musculo = oRegistro.Musculo;
                model.Numero = oRegistro.Numero;
                model.Observciones = oRegistro.Observciones;

            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditUserViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new Pr1malRegistrosEntities())
            {
                var oRegistro = db.RegistroEmple.Find(model.Id);

                oRegistro.Nombre = model.Nombre;
                //oRegistro.Namiento = model.Namiento;
                //oRegistro.Genero = model.Genero;
                //oRegistro.Edad = model.Edad;
                oRegistro.Celular = model.Celular;
                oRegistro.Direccion = model.Direccion;
                //oRegistro.Registro = model.Registro;
                //oRegistro.Nip = model.Nip;
                //oRegistro.Email = model.Email;

                if (model.Pass!=null && model.Pass.Trim() != "")
                {
                    oRegistro.Pass = model.Pass;
                }

                oRegistro.Altura = model.Altura;
                oRegistro.Peso = model.Peso;
                oRegistro.Imc = model.Imc;
                oRegistro.Corporal = model.Corporal;
                oRegistro.Metabolismo = model.Metabolismo;
                oRegistro.Grasa = model.Grasa;
                oRegistro.Musculo = model.Musculo;
                oRegistro.Numero = model.Numero;
                oRegistro.Observciones = model.Observciones;

                db.Entry(oRegistro).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/"));
        }
        //Fin de edit
        
        //Inicio del delete
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            using (var db = new Pr1malRegistrosEntities())
            {
                var oRegistro = db.RegistroEmple.Find(Id);

                oRegistro.idState = 3;


                db.Entry(oRegistro).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }

            return Content("1");
        }
    }
}