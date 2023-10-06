using Proyecto3MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace Proyecto3MVC.Repositorio
{
    public class ListaIdeasDeNegocioComunicacion : IListaIdeasDeNegocioComunicacion
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

        public void actualizarIdeaEditada(Models.IdeaDeNegocio idea, double valorInversion, double totalIngresos)
        {
            ListaIdeasDeNegocio.actualizarIdeaEditada(idea, valorInversion, totalIngresos);
        }

        public void eliminarIntegrante(IdeaDeNegocio idea, string integranteId) 
        {
            ListaIdeasDeNegocio.eliminarIntegrante(idea, integranteId);
        }

        public void agregarIntegrante(IdeaDeNegocio idea, Integrante integrante) 
        {
            ListaIdeasDeNegocio.agregarIntegrante(idea, integrante);
        }
    }
}