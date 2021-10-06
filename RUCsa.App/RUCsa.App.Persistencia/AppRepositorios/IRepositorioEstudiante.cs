using System.Collections.Generic;
using RUCsa.App.Dominio;

namespace RUCsa.App.Persistencia
{
    public interface IRepositorioEstudiante
    {
        //CRUD
        //GetAllEstudiante
        IEnumerable<Estudiante> GetAllEstudiantes();
        //AddEstudiante
        Estudiante AddEstudiante(Estudiante Estudiante);
        //UpdateEstudiante
        Estudiante UpdateEstudiante(Estudiante Estudiante);
        //DeleteEstudiante
        bool DeleteEstudiante(int identificacion);
        //GetEstudiante
        Estudiante GetEstudiante(int identificacion);
    }


}