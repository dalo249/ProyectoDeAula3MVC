using Proyecto3MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto3MVC.Repositorio
{
    public interface IListaIdeasDeNegocioRepositorio
    {
        List<IdeaDeNegocio> obtenerLista();
        IdeaDeNegocio buscarIdeaPorCodigo(int codigo);
        void agregarIdea(IdeaDeNegocio idea);
        void actualizarIdeaEditada(IdeaDeNegocio idea);
        void eliminarIntegrante(int codigo, string integranteId);

    }
}