﻿using Proyecto3MVC.Models;
using Proyecto3MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Proyecto3MVC.Models.Exceptions;

namespace Proyecto3MVC.Repositorio
{
    public static class ListaIdeasDeNegocio
    {
        static List<IdeaDeNegocio> IdeasDeNegocio = null;

        static ListaIdeasDeNegocio()
        {
            IdeasDeNegocio = new List<IdeaDeNegocio>(cargarIdeasDeNegocio());
        }

        public static List<IdeaDeNegocio> cargarIdeasDeNegocio() 
        {
            var ideasService = new IdeasDeNegocioServices();
            ideasService.obtenerIdeasDeNegocio();
            List<IdeaDeNegocio> ideasDeNegocio = ideasService.ideasNegocioService;
            return ideasDeNegocio;
        }

        //Comunicacion con el controlador
        //Acciones de la lista

        public static List<IdeaDeNegocio> obtenerLista()
        {
            return IdeasDeNegocio;

        }

        public static void agregarIdea(IdeaDeNegocio idea)
        {
            IdeasDeNegocio.Add(idea);

        }

        public static void actualizarIdeaEditada(IdeaDeNegocio idea) 
        {
            IdeaDeNegocio ideaActualizada = IdeasDeNegocio.Find(i => i.Codigo == idea.Codigo);
            ideaActualizada.ValorInversion = idea.ValorInversion;
            ideaActualizada.TotalIngresos = idea.TotalIngresos;

        }

        public static void eliminarIntegrante(IdeaDeNegocio idea, string integranteId)
        {

            int integranteIdInt = int.Parse(integranteId);
            Integrante integrante = idea.Integrantes.Find(i => i.Id == integranteId);
            idea.Integrantes.Remove(integrante);
        }
  



    } 
}