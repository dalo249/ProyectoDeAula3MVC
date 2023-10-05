using Proyecto3MVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto3MVC.Services
{
    public class IdeasDeNegocioServices
    {
        public List<Departamento> generarDepartamento() 
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
            List<Departamento> departamentos = generarDepartamento();
            double valorInversion = 200000;
            double totalIngresos = 19999;
            List<String> herramientas4RI = new List<String>{"inteligencia artificial", "Dron" };


            IdeaDeNegocio idea = new IdeaDeNegocio(codigo, nombre, impacto, departamentos, valorInversion, totalIngresos, herramientas4RI);
            ideas.Add(idea);
            return ideas;
        }


    }
}