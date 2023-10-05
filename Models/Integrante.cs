using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto3MVC.Models
{
    public class Integrante
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Rol { get; set; }
        public string Email { get; set; }

        public Integrante(string id, string nombre, string apellido, string rol, string email)
        {
            Id = id;
            Nombre = nombre;
            Apellidos = apellido;
            Rol = rol;
            Email = email;
        }
    }
}