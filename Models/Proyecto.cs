using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto3MVC.Models
{
    public class Proyecto
    {
        public List<IdeaDeNegocio> IdeasDeNegocio { get; set; }
        public List<Departamento> DepartamentosGlobal { get; set; }

        public Proyecto()
        {
            DepartamentosGlobal = new List<Departamento>();
            IdeasDeNegocio = new List<IdeaDeNegocio>();
        }



        public List<Departamento> generarDepatamento()
        {    
            List<string> nombresDeptos = new List<string>{ "Antioquia", "Cundinamarca", "Bolivar", "Cesar", "Armenia", "Arauca", "Valle del cauca", "Choco",
            "Cali", "Amazonas", "Florencia", "Ibague"};
            List<Departamento> deptos = new List<Departamento>();

            Random rand = new Random();
            int aleatorio = rand.Next(0, 4);
            for (int i = 0; i < aleatorio; i++)
            {
                int indice = rand.Next(0, 12);
                string nombre = nombresDeptos[indice];
                int codigo = rand.Next(0, 30);
                Departamento depto = new Departamento(codigo, nombre);
                deptos.Add(depto);
            }

            return deptos;
        }

        public List<IdeaDeNegocio> obtenerIdeasDeNegocio()
        {
            List<IdeaDeNegocio> ideas = new List<IdeaDeNegocio>();
            int codigo = 10;
            string nombre = "desarrollo";
            string impacto = "desarrllo sostenible";
            List<Departamento> departamentos = generarDepatamento();
            double valorInversion = 200000;
            double totalIngresos = 19999;
            List<String> herramientas4RI = new List<String> { "inteligencia artificial", "Dron" };


            IdeaDeNegocio idea = new IdeaDeNegocio(codigo, nombre, impacto, departamentos, valorInversion, totalIngresos, herramientas4RI);
            ideas.Add(idea);
            return ideas;
        }
        public Boolean registrarIdeaNegocio(string nombre, string impacto, List<string> nombreDepartamentos,
            double valorInversion, double totalIngresos, List<string> herramientas4RI)
        {
            int codigo = IdeasDeNegocio.Count + 1;
            List<Departamento> misDepartamentos = new List<Departamento>();
            foreach (string nombreDepto in nombreDepartamentos)
            {
                Departamento depto = buscarDepartamento(nombreDepto);
                if (depto == null)
                {
                    Departamento nuevoDepto = crearDepartamento(nombreDepto);
                    misDepartamentos.Add(nuevoDepto);
                }
                else misDepartamentos.Add(depto);
            }
            IdeaDeNegocio ideaNegocio = new IdeaDeNegocio(codigo, nombre, impacto, misDepartamentos, valorInversion,
                totalIngresos, herramientas4RI);
            agregarIdea(ideaNegocio);
            return true;

        }

        public IdeaDeNegocio buscarIdeaNegocio(int codigo)
        {
            if (IdeasDeNegocio.Count != 0)
            {
                foreach (IdeaDeNegocio negocio in IdeasDeNegocio)
                {
                    if (negocio.Codigo == codigo)
                    {
                        return negocio;
                    }
                }
            }
            return null;

        }

        public IdeaDeNegocio buscarIdeaNegocioPorNombre(string nombre)
        {
            if (IdeasDeNegocio.Count != 0)
            {
                foreach (IdeaDeNegocio negocio in IdeasDeNegocio)
                {
                    if (negocio.Nombre == nombre)
                    {
                        return negocio;
                    }
                }
            }
            return null;

        }



        public Departamento buscarDepartamento(string nombreDepartamento)
        {
            if (DepartamentosGlobal != null)
            {
                foreach (Departamento depto in DepartamentosGlobal)
                {
                    if (nombreDepartamento == depto.Nombre)
                    {
                        return depto;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            return null;

        }

        public Departamento crearDepartamento(string nombreDepartamento)
        {
            int codigo = DepartamentosGlobal.Count + 1;
            string nombre = nombreDepartamento;
            Departamento departamento = new Departamento(codigo, nombre);
            DepartamentosGlobal.Add(departamento);
            return departamento;
        }

        public Boolean agregarIntegrante(int codigoIdea, string id, string nombre, string apellido, string rol, string email)
        {
            IdeaDeNegocio ideaDeNegocio = buscarIdeaNegocio(codigoIdea);
            if (ideaDeNegocio != null)
            {
                Integrante integrante = new Integrante(id, nombre, apellido, rol, email);
                ideaDeNegocio.agregarIntegrante(integrante);
                return true;

            }
            else { return false; }

        }

        public Boolean eliminarIntegrante(IdeaDeNegocio idea, string id)
        {

            IdeaDeNegocio ideaNegocio = idea;
            if (ideaNegocio.eliminarIntegrante(id))
            {
                return true;
            }
            else { return false; }
        }

        public Boolean modificarValorInversion(IdeaDeNegocio idea, double nuevoValorInversion)
        {
            IdeaDeNegocio ideaDeNegocio = idea;
            if (nuevoValorInversion > 0)
            {
                ideaDeNegocio.ValorInversion = nuevoValorInversion;
                return true;
            }
            else { return false; }

        }

        public Boolean modificarTotalIngresos(IdeaDeNegocio idea, double totalIngresos)
        {
            IdeaDeNegocio ideaDeNegocio = idea;
            if (totalIngresos > 0)
            {
                ideaDeNegocio.TotalIngresos = totalIngresos;
                return true;
            }
            else { return false; }

        }

        //Comunicacion con el controlador
        //Acciones de la lista

        public List<IdeaDeNegocio> seleccionarListaIdeasDeNegocio()
        {

            return IdeasDeNegocio;
        }

        public void agregarIdea(IdeaDeNegocio idea) 
        {
            IdeasDeNegocio.Add(idea);

        }

    } 
}