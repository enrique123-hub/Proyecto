using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProyectoPr1mal.Models.UserViewModel
{
    public class UserViewModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre Completo")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name ="Fecha de namiento AÑO-MES-DIA")]
        public string Namiento { get; set; }

        [Required]
        [Display(Name = "Sexo")]
        public string Genero { get; set; }

        [Required]
        [Display(Name ="Edad")]
        public int Edad { get; set; }

        [Required]
        [Display(Name = "Numero de celular xxx-xxx-xx-xx")]
        public string Celular { get; set; }

        [Required]
        [Display(Name ="Direccion de domicilio")]
        public string Direccion { get; set; }

        [Required]
        [Display(Name = "Dia de registro AÑO-MES-DIA")]
        public string Registro { get; set; }

        [Required]
        [NipValid]
        [Display(Name = "Nip creado por el Administrador")]
        public string Nip { get; set; }

        [Required]
        [EmailAddress]
        [EmailValid]
        [Display(Name = "Correo Electronico")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        public string Pass { get; set; }
 
        [Display(Name = "Confirmar contraseña")]
        [Compare("Pass",ErrorMessage = "Las contraselas no coinciden")]
        public string ConfirmPass { get; set; }

        [Required]
        [Display(Name = "Altura en Metros")]
        public double Altura { get; set; }

        [Required]
        [Display(Name = "Peso en Kg")]
        public double Peso { get; set; }

        [Required]
        [Display(Name = "porcentaje de imc")]
        public double Imc { get; set; }

        [Required]
        [Display(Name = "Grasa corporal en %")]
        public double Corporal { get; set; }

        [Required]
        [Display(Name = "Metabolismo basal en Kg")]
        public int Metabolismo { get; set; }

        [Required]
        [Display(Name = "Grasa Diseral en %")]
        public double Grasa { get; set; }

        [Required]
        [Display(Name = "Musculo esqueletico en Kg")]
        public double Musculo { get; set; }

        [Required]
        [Display(Name = "Contacto de emergencia (Numero y nombre)")]
        public string Numero { get; set; }

        [Required]
        [Display(Name = "Observaciones")]
        public string Observciones { get; set; }
    }

    public class EmailValidAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            using (Pr1malRegistrosEntities db = new Pr1malRegistrosEntities())
            {
                String email = (String)value;

                if (db.RegistroEmple.Where(c => c.Email == email).Count() > 0)
                {
                    return new ValidationResult("Email ya existente");
                }
            }
            return ValidationResult.Success;
        }
    }

    public class NipValidAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            using (Pr1malRegistrosEntities db = new Pr1malRegistrosEntities())
            {
                String nip = (String)value;

                if (db.RegistroEmple.Where(d=>d.Nip == nip).Count()>0)
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

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre Completo")]
        public string Nombre { get; set; }

        /*[Required]
        [Display(Name = "Fecha de namiento AÑO-MES-DIA")]
        public string Namiento { get; set; }

        [Required]
        [Display(Name = "Sexo")]
        public string Genero { get; set; }

        [Required]
        [Display(Name = "Edad")]
        public int Edad { get; set; }*/

        [Required]
        [Display(Name = "Numero de celular xxx-xxx-xx-xx")]
        public string Celular { get; set; }

        [Required]
        [Display(Name = "Direccion de domicilio")]
        public string Direccion { get; set; }

        /*[Required]
        [Display(Name = "Dia de registro AÑO-MES-DIA")]
        public string Registro { get; set; }

        [Required]
        [Display(Name = "Nip creado por el Administrador")]
        public string Nip { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Correo Electronico")]
        public string Email { get; set; }*/

        [Display(Name = "Contraseña")]
        public string Pass { get; set; }

        [Display(Name = "Confirmar contraseña")]
        [Compare("Pass", ErrorMessage = "Las contraselas no coinciden")]
        public string ConfirmPass { get; set; }

        [Required]
        [Display(Name = "Altura en Metros")]
        public double Altura { get; set; }

        [Required]
        [Display(Name = "Peso en Kg")]
        public double Peso { get; set; }

        [Required]
        [Display(Name = "porcentaje de imc")]
        public double Imc { get; set; }

        [Required]
        [Display(Name = "Grasa corporal en %")]
        public double Corporal { get; set; }

        [Required]
        [Display(Name = "Metabolismo basal en Kg")]
        public int Metabolismo { get; set; }

        [Required]
        [Display(Name = "Grasa Diseral en %")]
        public double Grasa { get; set; }

        [Required]
        [Display(Name = "Musculo esqueletico en Kg")]
        public double Musculo { get; set; }

        [Required]
        [Display(Name = "Contacto de emergencia (Numero y nombre)")]
        public string Numero { get; set; }

        [Required]
        [Display(Name = "Observaciones")]
        public string Observciones { get; set; }
    }
}