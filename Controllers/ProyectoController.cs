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
            IdeaDeNegocio idea = listaIdeas.buscarIdeaPorCodigo(codigo);

            return View(idea);
        }


        //Metodo Post: Actualiza las variables editadas por las nuevas.
        [HttpPost]
        public ActionResult EditarIdea()
        {
            return View();
        }

        //Metodo Get: Muestra formulario para ingresar nuevos datos del integrante
        public ActionResult AgregarIntegrante(int codigo)
        {
            IdeaDeNegocio idea = listaIdeas.buscarIdeaPorCodigo(codigo);
            return View(idea);
        }

        //Metodo Post: recibe datos y registra al nuevo integrante
        [HttpPost]
        public ActionResult BtnAgregarIntegrante(IdeaDeNegocio idea )
        {
            string id = Request.Form["Id"];
            string nombre = Request.Form["Nombre"];
            string apellidos = Request.Form["Apellidos"];
            string Rol = Request.Form["Rol"];
            string Email = Request.Form["Email"];

            Integrante integrante = new Integrante(id, nombre, apellidos, Rol, Email);
            listaIdeas.agregarIntegrante(idea, integrante);

            return View();
        }

        //Metodo Get: Eliminar integrante, confirma elimino el integrante de la tabla

        public ActionResult EliminarIntegrante() 
        {
            return View();
        }



    }
}