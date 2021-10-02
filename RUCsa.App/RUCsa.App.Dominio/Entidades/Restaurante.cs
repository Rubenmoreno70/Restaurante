using System;

namespace RUCsa.App.Dominio
{
    public class Restaurante
    {
        public int id{get;set;}
        public int aforo{get;set;}
        public int numero_mesas{get;set;}
        public int personas_por_mesa{get;set;}
        public System.Collections.Generic.List<Persona> personas{get;set;}
        public string menu{get;set;}
        public string tunos{get;set;}
    }
}