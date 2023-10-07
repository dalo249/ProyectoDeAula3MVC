using Proyecto3MVC.Repositorio;
using Proyecto3MVC.Services;
using Proyecto3MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using Proyecto3MVC.Models.ViewModels;

namespace Proyecto3MVC.Controllers
{
    public class ProyectoController : Controller
    {

        ListaIdeasDeNegocioComunicacion listaIdeas = new ListaIdeasDeNegocioComunicacion();

        // GET: Muestra la lista de las ideas de negocio.
      public ActionResult Index() 
        {
            List<IdeaDeNegocio> ideas = listaIdeas.obtenerLista();
            return View(ideas);
        }


        //Metodo Get: muestra formulario registrar idea para llenar
        [HttpGet]
        public ActionResult RegistrarIdea() 
        {
            return View();
        }


        //Metodo Post: recibe datos y registra
        [HttpPost]
        public ActionResult RegistrarIdea(IdeaDeNegocioViewModel ideaVista)
        {
            if(!ModelState.IsValid) 
            {
                return View();
            }
 
            List<IdeaDeNegocio> ideas = listaIdeas.obtenerLista();
            int Codigo = ideas.Count()+1;


            List<Departamento> departamentos = new List<Departamento>();
            foreach (string nombreDepto in (ideaVista.Departamentos.Split(',')))
            {
                int codigoDepto = ideas.Count;
                Departamento depto = new Departamento(codigoDepto, nombreDepto);
                departamentos.Add(depto);
            }

            List<string> herramientas4RI = new List<string>();
            foreach (string herramienta in (ideaVista.Herramientas4RI.Split(',')))
            {
                herramientas4RI.Add(herramienta);
            }
    
            IdeaDeNegocio idea = new IdeaDeNegocio(Codigo, ideaVista.Nombre, ideaVista.Impacto, departamentos, ideaVista.ValorInversion,
                ideaVista.TotalIngresos, ideaVista.ValorInversionInfraestructura, herramientas4RI);

            listaIdeas.agregarIdea(idea);
            return RedirectToAction("Index");
        }
       

        public ActionResult MostrarIdea(int codigo)
        {

            IdeaDeNegocio idea = listaIdeas.buscarIdeaPorCodigo(codigo);
            return View(idea);
        }


        //Metodo Get: muestra el formulario para editar
        [HttpGet]
        public ActionResult EditarIdea(int codigo)
        {
            var ideaVista = new EditarIdeaDeNegocioViewModel();
            IdeaDeNegocio idea = listaIdeas.buscarIdeaPorCodigo(codigo);

            ideaVista.Codigo = idea.Codigo;
            ideaVista.ValorInversion = idea.ValorInversion;
            ideaVista.TotalIngresos = idea.TotalIngresos;

            return View(ideaVista);
        }


        //Metodo Post: Actualiza las variables editadas por las nuevas.
        [HttpPost]
        public ActionResult EditarIdea(EditarIdeaDeNegocioViewModel ideaVista)
        {
            if (!ModelState.IsValid) 
            {
                return View(ideaVista);
            }

            int codigo = ideaVista.Codigo;
            double valorInversion = ideaVista.ValorInversion;
            double totalIngresos = ideaVista.TotalIngresos;

            IdeaDeNegocio idea = listaIdeas.buscarIdeaPorCodigo(codigo);
            listaIdeas.actualizarIdeaEditada(idea, valorInversion, totalIngresos);

            return RedirectToAction("Index");
        }

        public ActionResult MostrarIntegrantes(int codigo)
        {
            IdeaDeNegocio idea = listaIdeas.buscarIdeaPorCodigo(codigo);
            return View(idea);
        }

        //Metodo Get: Muestra formulario para ingresar nuevos datos del integrante
   
        public ActionResult AgregarIntegrante(int codigo)
        {
            var integranteVista = new IntegranteIdeaDeNegocioViewModel();
            integranteVista.Codigo = codigo;

            return View(integranteVista);
        }

        //Metodo Post: recibe datos y registra al nuevo integrante
        [HttpPost]
        public ActionResult BtnAgregarIntegrante(IntegranteIdeaDeNegocioViewModel integranteVista )
        {

            Integrante integrante = new Integrante(integranteVista.Id, integranteVista.Nombre, integranteVista.Apellidos,
                integranteVista.Rol, integranteVista.Email);

            IdeaDeNegocio idea = listaIdeas.buscarIdeaPorCodigo(integranteVista.Codigo);

            listaIdeas.agregarIntegrante(idea, integrante);

            return View(idea);
        }

        //Metodo Get: Eliminar integrante, confirma elimino el integrante de la tabla

        public ActionResult EliminarIntegrante(string id) 
        {
            listaIdeas.eliminarIntegrante(id);

            return Content("El integrante se elimino correctamente de la idea de negocio");
        }



    }
}