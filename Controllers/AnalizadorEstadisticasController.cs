using Proyecto3MVC.Models;
using Proyecto3MVC.Repositorio;
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
        ListaIdeasDeNegocioRepositorio listaIdeas = new ListaIdeasDeNegocioRepositorio();


        public ActionResult Index()
        {
            List<IdeaDeNegocio> ideasDeNegocio = listaIdeas.obtenerLista();


            IdeaDeNegocio ideaMayorDeptos = analizador.ideaMayorDepartamentos(ideasDeNegocio);
            IdeaDeNegocio ideaMayorTotalIngresos = analizador.ideaMayorTotalIngresos(ideasDeNegocio);
            IdeaDeNegocio ideaMasHerramientas4RI = analizador.ideaMayorHerramientas4RI(ideasDeNegocio);
            IdeaDeNegocio ideaMayorInversionInfraestructura = analizador.ideaMayorInversionInfraestructura(ideasDeNegocio);
            List<IdeaDeNegocio> ideasMayorRentabilidad = analizador.ideasMayorRentabilidad(ideasDeNegocio);
            List<IdeaDeNegocio> ideasMas3Departamentos = analizador.ideasMas3Departamentos(ideasDeNegocio);
            List<IdeaDeNegocio> ideasUsanDesarrolloSostenible = analizador.ideasUsanDesarrolloSostenible(ideasDeNegocio);
            List<IdeaDeNegocio> ideasRentabilidadMayorPromedio = analizador.ideasRentabilidadMayorPromedio(ideasDeNegocio);
            List<IdeaDeNegocio> ideasUsanTerritoriosOTransicion = analizador.ideasUsanTerritoriosOTransicion(ideasDeNegocio);
            double sumaTotalDeIngresos = analizador.SumarTotalIngresosIdeas(ideasDeNegocio);
            double sumaTotalInversiones = analizador.SumarTotalInversionIdeas(ideasDeNegocio);
            int totalIdeasUsanIA = analizador.ideasUsanIA(ideasDeNegocio);

            Estadistica estadistica = new Estadistica(ideaMayorDeptos, ideaMayorTotalIngresos, ideaMasHerramientas4RI, ideaMayorInversionInfraestructura, ideasMayorRentabilidad,
                ideasMas3Departamentos, ideasUsanDesarrolloSostenible, ideasRentabilidadMayorPromedio, ideasUsanTerritoriosOTransicion, sumaTotalDeIngresos, sumaTotalInversiones,
                totalIdeasUsanIA);

            return View(estadistica);
        }

       
    }
}