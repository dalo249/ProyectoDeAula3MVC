using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Proyecto3MVC.Models.ViewModels 
{
    public class IdeaDeNegocioViewModel

    {
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Impacto")]
        public string Impacto { get; set; }


        [Required]
        [Display(Name = "Departamentos beneficiados\n(Separados por comas)")]
        public string Departamentos { get; set; }
        

        [Required]
        [Display(Name = "Valor de inversion")]
        [Range(0, 9999999999, ErrorMessage = "La cantidad no puede ser negativa.")]
        public double ValorInversion { get; set; }     
        


        [Required]
        [Display(Name = "Total de ingresos")]
        [Range(0, 9999999999, ErrorMessage = "La cantidad no puede ser negativa.")]
        public double TotalIngresos { get; set; }     
        


        [Required]
        [Display(Name = "Valor de inversion \nEn infraestructura")]
        [Range(0, 9999999999, ErrorMessage = "La cantidad no puede ser negativa.")]
        public double ValorInversionInfraestructura { get; set; }       
        

       
        [Required]
        [Display(Name = "Herramientas de la 4R.I \n(Separadas por comas)")]
        public string Herramientas4RI { get; set; }
        


    }

}

    

        


