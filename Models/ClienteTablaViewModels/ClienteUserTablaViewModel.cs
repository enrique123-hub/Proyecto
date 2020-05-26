using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPr1mal.Models.ClienteTablaViewModels
{
    public class ClienteUserTablaViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Nacimiento { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public string Registro { get; set; }
        public string Nip { get; set; }
        public string Email { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public double Imc { get; set; }
        public double Corporal { get; set; }
        public int Metabolismo { get; set; }
        public double Grasa { get; set; }
        public double Musculo { get; set; }
        public string Numero { get; set; }
        public string Observaciones { get; set; }
    }
}