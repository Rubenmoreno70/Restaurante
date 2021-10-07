using System;
using RUCsa.App.Dominio;
using RUCsa.App.Persistencia;
using System.Collections.Generic;

namespace RUCsa.App.Consola
{
    class Program
    { 
        private static IRepositorioEstudiante _repoEstudiante = new RepositorioEstudiante(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //CrearEstudiante();
            //ConsultarEstudiante(101112131);
            //ActualizarEstudiante();
            //BorrarEstudiante(1011121314);
            ConsultarEstudiantes();
        }
        //CRUD
        //CrearEstudiante
        private static void CrearEstudiante()
        {
            var estudiante = new Estudiante
            {
              nombre = "Alfonso",
              apellidos = "Saldarriaga",
              identificacion = 1011121314,
              edad =  "20",
              estadocovid = "negativo",
              programa = "Administración de Empresas"
            };
            Estudiante estudianteGuardado =_repoEstudiante.AddEstudiante(estudiante);
            if (estudianteGuardado!=null)
                Console.WriteLine("Se adicionó un estudiante en la lista");
                else
                {
                    Console.WriteLine("Error de conexion a la base de datos");
                }
        }

        //ConsultarEstudiante
        private static void ConsultarEstudiante(int identificacion)
        {
            var estudianteEncontrado = _repoEstudiante.GetEstudiante(identificacion);
            if (estudianteEncontrado!=null)
                Console.WriteLine(estudianteEncontrado.nombre);
            else
            {
                Console.WriteLine("Estudiante no registrado");
            }
        }
        //EditarEstudiante
        private static void ActualizarEstudiante()
        {
            var estudiante = new Estudiante
            {
              nombre = "Alfonso",
              apellidos = "Saldarriaga",
              identificacion = 101112131,
              edad =  "23",
              estadocovid = "negativo",
              programa = "Ingenieria Mecanica"
            };
             var estudianteActualizado =_repoEstudiante.UpdateEstudiante(estudiante);
             if (estudianteActualizado!=null)
                 Console.WriteLine("Actalizado el estudiante con identificación: " + estudianteActualizado.identificacion);
            else
            {
                Console.WriteLine("Estudiante no actualiado, no se encontró la identificacion: "+estudianteActualizado.identificacion);
            }
        }
        //BorrarEstudiante
        private static void BorrarEstudiante(int identificacion)
        {
            if(_repoEstudiante.DeleteEstudiante(identificacion))
                Console.WriteLine("Estudiante borrado de la base de datos.");
                else
                {
                    Console.WriteLine("Verifique identiicacion, no se pudo borrar estudiante.");
                }
        }
        //ConsultarEstudiantes
        private static void ConsultarEstudiantes()
        {
            IEnumerable<Estudiante> estudiantes = _repoEstudiante.GetAllEstudiantes();
            
            foreach (var estudiante in estudiantes)
            {
                Console.WriteLine(estudiante.nombre+" "+estudiante.apellidos+" Programa: "+estudiante.programa);
            }
        }   

    }
}
