using Proyecto3MVC.Models;
using Proyecto3MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Proyecto3MVC.Models.Exceptions;

namespace Proyecto3MVC.Repositorio
{
    public class ListaIdeasDeNegocio
    {
        Exception excepciones = new Exception();
        static List<IdeaDeNegocio> IdeasDeNegocio;

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

        public static void actualizarListaDeIdeas(IdeaDeNegocio idea) 
        {
            IdeaDeNegocio ideaActualizada = IdeasDeNegocio.Find(i => i.Codigo == idea.Codigo);
            ideaActualizada.ValorInversion = idea.ValorInversion;
            ideaActualizada.TotalIngresos = idea.TotalIngresos;

        }

        public static void eliminarIntegrante(IdeaDeNegocio idea, string integranteId)
        {
            try
            {
                int integranteIdInt = int.Parse(integranteId);
                IdeaDeNegocio ideaIntegrante = IdeasDeNegocio.Find(i => i.Codigo == idea.Codigo);
                Integrante integrante = ideaIntegrante.Integrantes.Find(i => i.Id == integranteId);

                if (integrante == null)
                {
                    throw InvalidIntegranteIdException("No se encontró un integrante con el ID proporcionado.");
                }

                ideaIntegrante.Integrantes.Remove(integrante);
            }
            catch (FormatException)
            {
                throw IdDeParticipanteInvalidoException("El valor proporcionado no es un número entero válido.");

            }



    } 
}