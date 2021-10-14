using System;
using System.ComponentModel.DataAnnotations;

namespace RUCsa.App.Dominio
{
    public class Persona
    {
        public int id{get;set;}
        [Required]
        public string nombre{get;set;}
        [Required]
        public string apellidos{get;set;}
        [Range(1,1999999999)]
        public int identificacion{get;set;}
        public string edad{get;set;}
        public string estadocovid{get;set;}
    }
}
