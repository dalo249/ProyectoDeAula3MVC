using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto3MVC.Models
{
    public class Exceptions
    {
        public class UsuarioNoEncontradoException : Exception
        {
            public UsuarioNoEncontradoException() : base("La idea de negocio con el id ingresado no se encuentra registrada")
            {

            }


        }
    }
}
