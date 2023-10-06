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

        private static ListaIdeasDeNegocio listaIdeasDeNegocio = new ListaIdeasDeNegocio();

        // GET: Lista de las ideas de negocio.
      public ActionResult Index() 
        {
            List<IdeaDeNegocio> ideas = listaIdeasDeNegocio.obtenerLista();
            return View(ideas);
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
            List<IdeaDeNegocio> ideas = listaIdeasDeNegocio.obtenerLista();
            int codigo = ideas.Count + 1;
            string nombre = Request.Form["Nombre"].ToString();
            string impacto = Request.Form["Impacto"].ToString();
            List<string> nombresDepartamentos = new List<string>(Request.Form["Departamentos"].Split(','));
            double valorInversion = Convert.ToDouble(Request.Form["ValorInversion"]);
            double totalIngresos = Convert.ToDouble(Request.Form["TotalIngresos"]);
            double valorInversionEnInfraestructura = Convert.ToDouble(Request.Form["ValorInversionInfraestructura"]);
            List<string> herramientas4RI = new List<string>(Request.Form["Herramientas4RI"].Split(','));

            List<Departamento> departamentos = new List<Departamento>();
            foreach(string nombreDepto in nombresDepartamentos) 
            {
                int codigoDepto = ideas.Count;
                Departamento depto = new Departamento(codigoDepto, nombreDepto);
                departamentos.Add(depto);
            }

            if (valorInversion <= 0 || totalIngresos <= 0 || valorInversionEnInfraestructura <= 0)
            {
                throw new ValoresNumericosInvalidoException("Los valores de inversión, valor de ingresos y total ingreesos deben ser mayores que cero.");
            }

            IdeaDeNegocio idea = new IdeaDeNegocio(codigo, nombre, impacto, departamentos, valorInversion, totalIngresos,
            valorInversionEnInfraestructura, herramientas4RI);
            listaIdeasDeNegocio.agregarIdea(idea);


            return View(idea);
    

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

        //Metodo Post: Actualiza las variables editadas por las nuevas.
        public ActionResult btn_EditarIdea()
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