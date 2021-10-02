using System;

namespace RUCsa.App.Dominio
{
    public class Registo_Covid
    {
        public int id{get;set;}
        public Sintoma sintoma{get;set;}
        public DateTime fecha{get;set;}
        public string periodo_aislamiento{get;set;}
    }
}