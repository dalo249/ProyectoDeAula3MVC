using Proyecto3MVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace Proyecto3MVC.Services
{
    public class IdeasDeNegocioServices
    {

        public List<IdeaDeNegocio> ideasNegocioService = new List<IdeaDeNegocio>();
        List<List<Departamento>> listasDepartamentos = new List<List<Departamento>>();
        List<List<string>> listasHerramientas4RI = new List<List<string>>();
        Random rand = new Random();

        public int generarCodigo()
        {
            int codigo = ideasNegocioService.Count + 1;
            return codigo;
        }

        public string generarNombre() 
        {
            List<string> nombres = new List<string> { "Claro", "Tigo", "Tecno s.a", "powered", "Fusion tree", "Asun", "Biopaper", "EcoMovil", "Cargos s.a",
            "Etnias", "zafiro", "Union", "Maderas s.a", "Prefabricadas y asociados", "Ferreteria L", "Economatric", "Haceb", "Asus", "Dynamo", "Cartel los Angeles"};

            string nombreI = nombres[rand.Next(0, nombres.Count)];
            nombres.Remove(nombreI);
 
            return nombreI;
        }

        public string generarimpactoSocial() 
        {
            List<String> impactos = new List<String> { "Ecologico", "Desarrollo sostenible", "Industria y comercio", "agropecuario", "reutilizacion", "economia circular",
            "Territorios inteligentes", "Transicion energetica"};
            string impactoI = impactos[rand.Next(0, impactos.Count)];
            return impactoI;
        }
        public void generarDepartamentos()
        {

            List<string> nombresDeptos = new List<string>{ "Antioquia", "Cundinamarca", "Bolivar", "Cesar", "Armenia", "Arauca", "Valle del cauca", "Choco",
            "Cali", "Amazonas", "Florencia", "Ibague"};

            for (int i = 0; i < 13; i++)
            {
                int tamano = rand.Next(2, 5);
                List<Departamento> listaAleatoria = new List<Departamento>();

                for (int j = 0; j < tamano; j++)
                {
                    int indiceAleatorio = rand.Next(0, nombresDeptos.Count);
                    string nombre = nombresDeptos[indiceAleatorio];
                    int codigo = rand.Next(0, 30);
                    Departamento depto = new Departamento(codigo, nombre);
                    listaAleatoria.Add(depto);
                }
                listasDepartamentos.Add(listaAleatoria);
            }
        }

        public double generarValorInversion()
        {
            double valorInversionI = rand.Next(0, 99999);
            return valorInversionI;
        }

        public double generarTotalIngresos()
        {
            double totalIngresosI = rand.Next(0, 99999);
            return totalIngresosI;
        }
        public double generarValorInversionIngraestructura() 
        {
            double valorInversionInfraestructura = rand.Next(0, 99999);
            return valorInversionInfraestructura;
        }

        public void generarHerramientas()
        {
            
            List<string> nombresHerramientas4RI = new List<string> {"Inteligencia artificial", "Drones", "Internet de las cosas", "Big data",
                "Cloud computing", "Biometria", "Frima digital", "Robotica", "Realidad virtual", "realidad aumentada", "Nanotecnologia"};

            for (int i = 0; i < 13; i++)
            {
                int tamano = rand.Next(2, 5);
                List<string> listaAleatoria = new List<string>();

                for (int j = 0; j < tamano; j++)
                {
                    int indiceAleatorio = rand.Next(0, nombresHerramientas4RI.Count);
                    string herramienta = nombresHerramientas4RI[indiceAleatorio];
                    listaAleatoria.Add(herramienta);
                }
                listasHerramientas4RI.Add(listaAleatoria);
            }
        }


        public void obtenerIdeasDeNegocio() 
        {
            generarDepartamentos();
            generarHerramientas();
            for (int i = 0; i < 6; i++)
            {
                List<IdeaDeNegocio> ideas = new List<IdeaDeNegocio>();
                int codigo = generarCodigo();
                string nombre = generarNombre();
                string impacto = generarimpactoSocial();
                List<Departamento> departamentos = listasDepartamentos[i+1];
                double valorInversion = generarValorInversion();
                double totalIngresos = generarTotalIngresos();
                double valorInversionInfraestructura = generarValorInversionIngraestructura();
                List<String> herramientas4RI = listasHerramientas4RI[i+1];
                IdeaDeNegocio idea = new IdeaDeNegocio(codigo, nombre, impacto, departamentos, valorInversion, totalIngresos, valorInversionInfraestructura, herramientas4RI);
                ideasNegocioService.Add(idea);

            }
        }

 
        


    }
}