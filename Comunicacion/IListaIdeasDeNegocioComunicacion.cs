using Proyecto3MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto3MVC.Repositorio
{
    public interface IListaIdeasDeNegocioComunicacion
    {
        List<IdeaDeNegocio> obtenerLista();
        IdeaDeNegocio buscarIdeaPorCodigo(int codigo);
        void agregarIdea(IdeaDeNegocio idea);
        void actualizarIdeaEditada(IdeaDeNegocio idea, double valorInversion, double totalIngresos);
        void eliminarIntegrante(IdeaDeNegocio idea, string integranteId);
        void agregarIntegrante(IdeaDeNegocio idea, Integrante integrante);

    }
}