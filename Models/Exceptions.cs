using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto3MVC.Models
{
    public class Exceptions
    {
        public class IdeaDeNegocioNoEncontradaException : Exception
        {
            public IdeaDeNegocioNoEncontradaException() : base("La idea de negocio con el id ingresado no se encuentra registrada")
            {
            }

        }

        public class IdDeParticipanteInvalidoException : Exception 
        {
            public IdDeParticipanteInvalidoException() : base("El valor proporcionado es unicamente numerico, no contiene valores alfabeticos")
            {
            }
        }

        public class ParticipanteNoEncontradoException : Exception 
        {
            public ParticipanteNoEncontradoException(): base("El participante con el id ingresado no pertenece a la idea de negocio ") 
            {
            }
        }

        public class ValoresNumericosInvalidoException : Exception 
        {
            public ValoresNumericosInvalidoException() : base("Los valores de inversión, valor de ingresos y total ingreesos deben ser mayores que cero.")
            {
            }
        }

 
    }
}
