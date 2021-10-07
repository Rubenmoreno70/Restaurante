using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RUCsa.App.Persistencia;
using RUCsa.App.Dominio;

namespace RUCsa.App.Frontend.Pages
{
    public class EstudiantesModel : PageModel
    {
        private static IRepositorioEstudiante _repoEstudiante = new RepositorioEstudiante(new Persistencia.AppContext());

        public IEnumerable<Estudiante> Estudiantes{get;set;}
        public void OnGet()
        {
            Estudiantes = _repoEstudiante.GetAllEstudiantes();
        }
    }
}
