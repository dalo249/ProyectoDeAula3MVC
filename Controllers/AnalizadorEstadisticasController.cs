using Proyecto3MVC.Models;
using Proyecto3MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto3MVC.Controllers
{
    public class AnalizadorEstadisticasController : Controller
    {

        AnalizadorEstadisticas analizador = new AnalizadorEstadisticas();
        List<IdeaDeNegocio> listaIdeasDeNegocio = new List<IdeaDeNegocio>();
        public ActionResult Index()
        {
            var ideasService = new IdeasDeNegocioServices();
            List<IdeaDeNegocio> ideas = ideasService.obtenerIdeasDeNegocio();
            listaIdeasDeNegocio = ideas;
            return View();
        }

       
    }
}