using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto3MVC.Models
{
    public class Estadistica
    {
        public IdeaDeNegocio ideaMayorDeptos;
        public IdeaDeNegocio ideaMayorTotalIngresos;
        public IdeaDeNegocio ideaMasHerramientas4RI;
        public IdeaDeNegocio ideaMayorInversionInfraestructura;
        public List<IdeaDeNegocio> ideasMayorRentabilidad;
        public List<IdeaDeNegocio> ideasMas3Departamentos;
        public List<IdeaDeNegocio> ideasUsanDesarrolloSostenible;
        public List<IdeaDeNegocio> ideasRentabilidadMayorPromedio;
        public List<IdeaDeNegocio> ideasUsanTerritoriosOTransicion;
        public double sumaTotalDeIngresos;
        public double sumaTotalInversiones;
        public int totalIdeasUsanIA;


        public Estadistica(IdeaDeNegocio ideaMayorDeptos, IdeaDeNegocio ideaMayorTotalIngresos, IdeaDeNegocio ideaMasHerramientas4RI, IdeaDeNegocio ideaMayorInversionInfraestructura,
            List<IdeaDeNegocio> ideasMayorRentabilidad, List<IdeaDeNegocio> ideasMas3Departamentos, List<IdeaDeNegocio> ideasUsanDesarrolloSostenible,
            List<IdeaDeNegocio> ideasRentabilidadMayorPromedio, List<IdeaDeNegocio> ideasUsanTerritoriosOTransicion, double sumaTotalDeIngresos, double sumaTotalInversiones, int totalIdeasUsanIA)
        {
            this.ideaMayorDeptos = ideaMayorDeptos;
            this.ideaMayorTotalIngresos = ideaMayorTotalIngresos;
            this.ideaMasHerramientas4RI = ideaMasHerramientas4RI;
            this.ideaMayorInversionInfraestructura = ideaMayorInversionInfraestructura;
            this.ideasMayorRentabilidad = ideasMayorRentabilidad;
            this.ideasMas3Departamentos = ideasMas3Departamentos;
            this.ideasUsanDesarrolloSostenible = ideasUsanDesarrolloSostenible;
            this.ideasRentabilidadMayorPromedio = ideasRentabilidadMayorPromedio;
            this.ideasUsanTerritoriosOTransicion = ideasUsanTerritoriosOTransicion;
            this.sumaTotalDeIngresos = sumaTotalDeIngresos;
            this.sumaTotalInversiones = sumaTotalInversiones;
            this.totalIdeasUsanIA = totalIdeasUsanIA;
        }



    }
}