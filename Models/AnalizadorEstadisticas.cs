using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto3MVC.Models
{
    public class AnalizadorEstadisticas
    {
        public IdeaDeNegocio ideaMayorDepartamentos(Proyecto proyecto)
        {
            IdeaDeNegocio mayorDepartamentos = proyecto.seleccionarListaIdeasDeNegocio().OrderByDescending(i => i.Departamentos.Count).FirstOrDefault();
            return mayorDepartamentos;

        }

        public IdeaDeNegocio ideaMayorTotalIngresos(Proyecto proyecto)
        {
            IdeaDeNegocio mayorIngresos = proyecto.seleccionarListaIdeasDeNegocio().OrderByDescending(i => i.TotalIngresos).FirstOrDefault();
            return mayorIngresos;

        }

        public List<IdeaDeNegocio> ideasMayorRentabilidad(Proyecto proyecto)
        {
            List<IdeaDeNegocio> ideasRentables = proyecto.seleccionarListaIdeasDeNegocio().OrderByDescending(i => i.TotalIngresos).Take(3).ToList();
            return ideasRentables;

        }

        public List<IdeaDeNegocio> ideasMas3Departamentos(Proyecto proyecto)
        {
            var ideasMasDepartamentos = proyecto.seleccionarListaIdeasDeNegocio().Where(i => i.Departamentos.Count > 3).ToList();
            return ideasMasDepartamentos;
        }

        public double SumarTotalIngresosIdeas(Proyecto proyecto)
        {
            double sumaTotalIngresos = proyecto.seleccionarListaIdeasDeNegocio().Sum(i => i.TotalIngresos);
            return sumaTotalIngresos;
        }

        public double SumarTotalInversionIdeas(Proyecto proyecto)
        {
            double sumaTotalInversion = proyecto.seleccionarListaIdeasDeNegocio().Sum(i => i.ValorInversion);
            return sumaTotalInversion;
        }

        public IdeaDeNegocio ideaMayorHerramientas4RI(Proyecto proyecto)
        {
            IdeaDeNegocio mayorHerramientas4RI = proyecto.seleccionarListaIdeasDeNegocio().OrderByDescending(i => i.Herramientas4RI.Count).FirstOrDefault();
            return mayorHerramientas4RI;
        }

        public int ideasUsanIA(Proyecto proyecto)
        {
            int ideasUsanIA = proyecto.seleccionarListaIdeasDeNegocio().Where(i => i.Herramientas4RI.Contains("inteligencia artificial")).Count();
            return ideasUsanIA;
        }

        public List<IdeaDeNegocio> ideasUsanDesarrolloSostenible(Proyecto proyecto)
        {
            List<IdeaDeNegocio> ideasDesarrolloSostenible = proyecto.seleccionarListaIdeasDeNegocio().Where(i => i.Impacto.ToLower().Contains("desarrollo sostenible")).ToList();
            return ideasDesarrolloSostenible;
        }

        public List<IdeaDeNegocio> ideasRentabilidadMayorPromedio(Proyecto proyecto)
        {
            double promedio = proyecto.seleccionarListaIdeasDeNegocio().Average(i => i.TotalIngresos);
            List<IdeaDeNegocio> ideasRentabilidadMayorPromedio = proyecto.seleccionarListaIdeasDeNegocio().Where(i => i.TotalIngresos > promedio).ToList();
            return ideasRentabilidadMayorPromedio;


        }
    }
}