using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto3MVC.Models
{
    public class AnalizadorEstadisticas
    {
        

        public IdeaDeNegocio ideaMayorDepartamentos(List<IdeaDeNegocio> ideasDeNegocio)
        {
            IdeaDeNegocio mayorDepartamentos = ideasDeNegocio.OrderByDescending(i => i.Departamentos.Count).FirstOrDefault();
            return mayorDepartamentos;

        }

        public IdeaDeNegocio ideaMayorTotalIngresos(List<IdeaDeNegocio> ideasDeNegocio)
        {
            IdeaDeNegocio mayorIngresos = ideasDeNegocio.OrderByDescending(i => i.TotalIngresos).FirstOrDefault();
            return mayorIngresos;

        }

        public List<IdeaDeNegocio> ideasMayorRentabilidad(List<IdeaDeNegocio> ideasDeNegocio)
        {
            List<IdeaDeNegocio> ideasRentables = ideasDeNegocio.OrderByDescending(i => i.TotalIngresos).Take(3).ToList();
            return ideasRentables;

        }

        public List<IdeaDeNegocio> ideasMas3Departamentos(List<IdeaDeNegocio> ideasDeNegocio)
        {
            var ideasMasDepartamentos = ideasDeNegocio.Where(i => i.Departamentos.Count > 3).ToList();
            return ideasMasDepartamentos;
        }

        public double SumarTotalIngresosIdeas(List<IdeaDeNegocio> ideasDeNegocio)
        {
            double sumaTotalIngresos = ideasDeNegocio.Sum(i => i.TotalIngresos);
            return sumaTotalIngresos;
        }

        public double SumarTotalInversionIdeas(List<IdeaDeNegocio> ideasDeNegocio)
        {
            double sumaTotalInversion = ideasDeNegocio.Sum(i => i.ValorInversion);
            return sumaTotalInversion;
        }

        public IdeaDeNegocio ideaMayorHerramientas4RI(List<IdeaDeNegocio> ideasDeNegocio)
        {
            IdeaDeNegocio mayorHerramientas4RI = ideasDeNegocio.OrderByDescending(i => i.Herramientas4RI.Count).FirstOrDefault();
            return mayorHerramientas4RI;
        }

        public int ideasUsanIA(List<IdeaDeNegocio> ideasDeNegocio)
        {
            int ideasUsanIA = ideasDeNegocio.Where(i => i.Herramientas4RI.Contains("Inteligencia artificial")).Count();
            return ideasUsanIA;
        }

        public List<IdeaDeNegocio> ideasUsanDesarrolloSostenible(List<IdeaDeNegocio> ideasDeNegocio)
        {
            List<IdeaDeNegocio> ideasDesarrolloSostenible = ideasDeNegocio.Where(i => i.Impacto.ToLower().Contains("desarrollo sostenible")).ToList();
            return ideasDesarrolloSostenible;
        }

        public List<IdeaDeNegocio> ideasRentabilidadMayorPromedio(List<IdeaDeNegocio> ideasDeNegocio)
        {
            double promedio = ideasDeNegocio.Average(i => i.TotalIngresos);
            List<IdeaDeNegocio> ideasRentabilidadMayorPromedio = ideasDeNegocio.Where(i => i.TotalIngresos > promedio).ToList();

            return ideasRentabilidadMayorPromedio;

        }

        public IdeaDeNegocio ideaMayorInversionInfraestructura(List<IdeaDeNegocio> ideasDeNegocio)
        {


            IdeaDeNegocio ideaMayorInversion = ideasDeNegocio.OrderByDescending(idea => idea.ValorInversionInfraestructura).FirstOrDefault();

            return ideaMayorInversion;
        }

        public List<IdeaDeNegocio> ideasUsanTerritoriosOTransicion(List<IdeaDeNegocio> ideasDeNegocio)
        {
            List<IdeaDeNegocio> ideasUsanTerritoriosOTransicion = ideasDeNegocio.Where(i => i.Impacto.Contains("Transicion energetica") || i.Impacto.Contains("Territorios inteligentes") ).ToList();

            return ideasUsanTerritoriosOTransicion;
        }

      
    }
}