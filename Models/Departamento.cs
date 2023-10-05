using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto3MVC.Models
{
    public class Departamento
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public Departamento(int codigo, string nombre)
        {
            Codigo = codigo;
            Nombre = nombre;

        }
    }
}