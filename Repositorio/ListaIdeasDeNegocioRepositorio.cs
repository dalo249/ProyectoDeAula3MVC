using Proyecto3MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace Proyecto3MVC.Repositorio
{
    public class ListaIdeasDeNegocioRepositorio : IListaIdeasDeNegocioRepositorio
    {
        public List<Models.IdeaDeNegocio> obtenerLista()
        {
            return ListaIdeasDeNegocio.obtenerLista();
        }

        public Models.IdeaDeNegocio buscarIdeaPorCodigo(int codigo) 
        {
            IdeaDeNegocio idea = ListaIdeasDeNegocio.obtenerLista().Find(i => i.Codigo == codigo);
            return idea;
        }

        public void agregarIdea(Models.IdeaDeNegocio idea) 
        {
            ListaIdeasDeNegocio.agregarIdea(idea);
        }

        public void actualizarIdeaEditada(Models.IdeaDeNegocio idea)
        {
            ListaIdeasDeNegocio.actualizarIdeaEditada(idea);
        }

        public void eliminarIntegrante(int codigo, string integranteId) 
        {
            IdeaDeNegocio idea = buscarIdeaPorCodigo(codigo);
            ListaIdeasDeNegocio.eliminarIntegrante(idea, integranteId);
        }
    }
}