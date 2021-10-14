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
    public class EliminarModel : PageModel
    {
        private static IRepositorioEstudiante _repoEstudiante=new RepositorioEstudiante(new Persistencia.AppContext());
        [BindProperty]
        public Estudiante estudiante{get;set;}
        public IActionResult OnGet(int estudianteIdentificacion)
        {
            estudiante = _repoEstudiante.GetEstudiante(estudianteIdentificacion);
            return Page();
        }
        public IActionResult OnPost()
        {
            _repoEstudiante.DeleteEstudiante(estudiante.identificacion);
            return RedirectToPage("./Estudiantes");
        }
    }
}
