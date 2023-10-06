using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto3MVC.Models
{
    public class IdeaDeNegocio
    {
        
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Impacto { get; set; }
        public List<Departamento> Departamentos { get; set; }
        public double ValorInversion { get; set; }
        public double TotalIngresos { get; set; }
        public double ValorInversionInfraestructura { get; set; }
        public List<Integrante> Integrantes { get; set; }
        public List<string> Herramientas4RI { get; set; }

        public List<Departamento> DepartamentosGlobal { get; set; }

        public IdeaDeNegocio(int codigo, string nombre, string impacto, List<Departamento> departamentos, double valorInversion,
            double totalIngresos, double valorInversionInfraestructura,List<string> herramientas4RI)
        {
            Codigo = codigo;
            Nombre = nombre;
            Impacto = impacto;
            Departamentos = departamentos;
            ValorInversion = valorInversion;
            TotalIngresos = totalIngresos;
            ValorInversionInfraestructura = valorInversionInfraestructura;
            Integrantes = new List<Integrante>();
            Herramientas4RI = herramientas4RI;


        }

        public void agregarIntegrante(Integrante nuevoIntegrante)
        {
            Integrantes.Add(nuevoIntegrante);

        }

        public Boolean eliminarIntegrante(string id)
        {
            foreach (Integrante integrante in Integrantes)
            {
                if (integrante.Id == id)
                {
                    Integrantes.Remove(integrante);
                    return true;
                }

            }
            return false;
        }


    }
}