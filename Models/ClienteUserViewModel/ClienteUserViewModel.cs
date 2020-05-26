using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProyectoPr1mal.Models.ClienteUserViewModel
{
    public class ClienteUserViewModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name="Nombre completo")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name="Fecha de nacimiento AÑO-MES-DIA")]
        public string Nacimiento { get; set; }

        [Required]
        [Display(Name ="Sexo")]
        public string Genero { get; set; }

        [Required]
        [Display(Name ="Edad")]
        public int Edad { get; set; }

        [Required]
        [Display(Name = "celular xxx-xxx-xx-xx")]
        public string Celular { get; set; }

        [Required]
        [Display(Name ="Direccion de casa")]
        public string Direccion { get; set; }

        [Required]
        [Display(Name ="Fecha de registro AÑO-MES-DIA")]
        public string Registro { get; set; }

        [Required]
        [Display(Name = "Nip creado por el Administrador")]
        [Nipvalid]
        public string Nip { get; set; }

        [Required]
        [EmailAddress]
        [EmailValid]
        [Display(Name ="correo electronico")]
        public string Email { get; set; }

        [Required]
        [Display(Name ="Altura en metros")]
        public double Altura { get; set; }

        [Required]
        [Display(Name ="peso en Kg")]
        public double Peso { get; set; }

        [Required]
        [Display(Name ="Imc en %")]
        public double Imc { get; set; }

        [Required]
        [Display(Name ="peso corporal en Kg")]
        public double Corporal { get; set; }

        [Required]
        [Display(Name ="Metabolismo basal en Kg")]
        public int Metabolismo { get; set; }

        [Required]
        [Display(Name ="Grasa diseral en Kg")]
        public double Grasa { get; set; }

        [Required]
        [Display(Name ="musculo esqueletico en Kg")]
        public double Musculo { get; set; }

        [Required]
        [Display(Name ="numero y nombre de contacto de emergencia")]
        public string Numero { get; set; }

        [Required]
        [Display(Name ="Observaciones del cliente")]
        public string Observaciones { get; set; }
    }

    public class EmailValidAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            using (Pr1malRegistrosEntities db = new Pr1malRegistrosEntities())
            {
                String email = (String)value;

                if (db.RegistroClien.Where(d => d.Email == email).Count() > 0) 
                {
                    return new ValidationResult("Email ya existente");
                }
            }

            return ValidationResult.Success;
        }
    }

    public class NipvalidAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            String nip = (String)value;

            using (Pr1malRegistrosEntities db = new Pr1malRegistrosEntities())
            {
                if (db.RegistroClien.Where(d=>d.Nip == nip).Count()>0)
                {
                    return new ValidationResult("Nip ya utilizado");
                }
            }

            return ValidationResult.Success;
        }
    }

    public class EditUserViewModel
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Display(Name = "Nombre completo")]
        public string Nombre { get; set; }

        /*[Display(Name = "Fecha de nacimiento AÑO-MES-DIA")]
        public string Nacimiento { get; set; }*/

        /*[Display(Name = "Sexo")]
        public string Genero { get; set; }*/

        /*[Display(Name = "Edad")]
        public int Edad { get; set; }*/

        [Display(Name = "celular xxx-xxx-xx-xx")]
        public string Celular { get; set; }

        [Display(Name = "Direccion de casa")]
        public string Direccion { get; set; }

        /*[Display(Name = "Fecha de registro AÑO-MES-DIA")]
        public string Registro { get; set; }*/

        /*[Display(Name = "Nip creado por el Administrador")]
        [Nipvalid]
        public string Nip { get; set; }*/

        /*[Display(Name = "correo electronico")]
        [EmailAddress]
        [EmailValid]
        public string Email { get; set; }*/

        [Display(Name = "Altura en metros")]
        public double Altura { get; set; }

        [Display(Name = "peso en Kg")]
        public double Peso { get; set; }

        [Display(Name = "Imc en %")]
        public double Imc { get; set; }

        [Display(Name = "peso corporal en Kg")]
        public double Corporal { get; set; }

        [Display(Name = "Metabolismo basal en Kg")]
        public int Metabolismo { get; set; }

        [Display(Name = "Grasa diseral en Kg")]
        public double Grasa { get; set; }

        [Display(Name = "musculo esqueletico en Kg")]
        public double Musculo { get; set; }

        [Display(Name = "numero y nombre de contacto de emergencia")]
        public string Numero { get; set; }

        [Display(Name = "Observaciones del cliente")]
        public string Observaciones { get; set; }
    }

}