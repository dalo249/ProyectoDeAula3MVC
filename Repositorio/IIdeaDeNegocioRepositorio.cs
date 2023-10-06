using Proyecto3MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto3MVC.Repositorio
{
    public interface IIdeaDeNegocioRepositorio
    {
        List<IdeaDeNegocio> obtenerLista();
        IdeaDeNegocio buscarIdeaPorCodigo();
    }
}