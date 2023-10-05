using Microsoft.Ajax.Utilities;
using Proyecto3MVC.Services;
using Proyecto3MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;

namespace Proyecto3MVC.Controllers
{
    public class ProyectoController : Controller
    {
        Proyecto miProyecto = new Proyecto();
        // GET: Proyecto
        public ActionResult Index()
        {
  
            return View(miProyecto);
        }

        public ActionResult IdeasDeNegocio() 
        {
            IEnumerable<IdeaDeNegocio> ideasDeNegocio = miProyecto.seleccionarListaIdeasDeNegocio();
    
            return View(ideasDeNegocio);
        }
        //Metodo Get: muestra formulario usuario llenar
        public ActionResult RegistrarIdea() 
        {
            return View();
        }

        //Metodo Post: recibe datos y registra
        [HttpPost]
        public ActionResult BtnRegistrarIdea()
        {

            if (Request.Form["Nombre"].Length == 0 || Request.Form["Impacto"].Length == 0 || Request.Form["Departamentos"].Length == 0 ||
                Request.Form["ValorInversion"].Length == 0 || Request.Form["TotalIngresos"].Length == 0 || Request.Form["Herramientas4RI"].Length == 0) 
            {
                return Content("Debe llenar todos los campos requeridos.");
            }


            string nombre = Request.Form["Nombre"].ToString();
            string impacto = Request.Form["Impacto"].ToString();
            List<string> departamentos = new List<string>(Request.Form["Departamentos"].Split(','));
            double valorInversion = Convert.ToDouble(Request.Form["ValorInversion"]);
            double totalIngresos = Convert.ToDouble(Request.Form["TotalIngresos"]);
            List<string> herramientas4RI = new List<string>(Request.Form["Herramientas4RI"].Split(','));


            bool registro = miProyecto.registrarIdeaNegocio(nombre, impacto, departamentos, valorInversion, totalIngresos, herramientas4RI);

            if(registro) 
            {
                IdeaDeNegocio ideaDeNegocio = miProyecto.buscarIdeaNegocioPorNombre(nombre);
                miProyecto.agregarIdea(ideaDeNegocio);
                return View(ideaDeNegocio);
            }
            return Content("Error: El registro no fue realizado.");

        }
       


        public ActionResult MostrarIdea()
        {
            return View();
        }

        //Metodo Get: muestra el formulario para editar
        public ActionResult EditarIdea()
        {
            return View();
        }

        //Metodo Get: habilita la casilla para editar
        public ActionResult EditarValorInversion()
        {
            return View();
        }

        //Metodo Post: Cambia el valor nuevo por el antiguo
        public ActionResult EjecutarEditarValorInversion()
        {
            return View();
        }

        //Metodo Get: habilita la casilla para editar
        public ActionResult EditarTotalIngresos()
        {
            return View();
        }

        //Metodo Post: Cambia el valor nuevo por el antiguo
        public ActionResult EjecutarEditarTotalIngresos()
        {
            return View();
        }

        //Metodo Get: Muestra formulario para ingresar nuevos datos del integrante
        public ActionResult AgregarIntegrante()
        {
            return View();
        }

        //Metodo Post: recibe datos y registra al nuevo integrante
        public ActionResult BtnAgregarIntegrante()
        {
            return View();
        }



    }
}