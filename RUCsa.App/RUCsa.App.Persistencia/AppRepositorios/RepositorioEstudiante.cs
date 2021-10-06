using RUCsa.App.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace RUCsa.App.Persistencia
{
    public class RepositorioEstudiante : IRepositorioEstudiante
    {
        private readonly AppContext _appContext;

        public RepositorioEstudiante(AppContext appContext)
        {
            _appContext = appContext;
        }
        
        //AdicionarEstudiante
        Estudiante IRepositorioEstudiante.AddEstudiante(Estudiante estudiante)
        {
            var estudianteAdicionado = _appContext.Estudiantes.Add(estudiante);
            _appContext.SaveChanges();
            return estudianteAdicionado.Entity;
        }
        //BuscarEstudiante
        Estudiante IRepositorioEstudiante.GetEstudiante(int identificacion)
        {
            var estudianteEncontrado= _appContext.Estudiantes.FirstOrDefault(p => p.identificacion == identificacion);
            return estudianteEncontrado;
        }
        //ActualiarEstudiante
        Estudiante IRepositorioEstudiante.UpdateEstudiante(Estudiante estudiante)
        {
            var estudianteEncontrado = _appContext.Estudiantes.FirstOrDefault(p => p.identificacion == estudiante.identificacion);
            if (estudianteEncontrado != null)
            {
                estudianteEncontrado.nombre = estudiante.nombre;
                estudianteEncontrado.apellidos = estudiante.apellidos;
                estudianteEncontrado.identificacion = estudiante.identificacion;
                estudianteEncontrado.edad = estudiante.edad;
                estudianteEncontrado.estadocovid =estudiante.estadocovid;
                estudianteEncontrado.programa = estudiante.programa;
                _appContext.SaveChanges();
            }
            return estudianteEncontrado;
        }
        //BorrarEstudiante
        bool IRepositorioEstudiante.DeleteEstudiante (int identificacion)
        {
            var estudianteEncontrado = _appContext.Estudiantes.FirstOrDefault(p => p.identificacion == identificacion);
            if (estudianteEncontrado == null)
                return false;
            _appContext.Estudiantes.Remove(estudianteEncontrado);
            _appContext.SaveChanges();
            return true;
        }
        //BuscarEstudiantes
        IEnumerable<Estudiante> IRepositorioEstudiante.GetAllEstudiantes()
        {
            return _appContext.Estudiantes;
        }



    }
}