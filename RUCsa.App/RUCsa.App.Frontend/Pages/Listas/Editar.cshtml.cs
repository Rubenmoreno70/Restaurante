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
    public class EditarModel : PageModel
    {
        private static IRepositorioEstudiante _repoEstudiante=new RepositorioEstudiante(new Persistencia.AppContext());
        [BindProperty]
        public Estudiante estudiante{get;set;}
        public IActionResult OnGet(int? estudianteIdentificacion)
        {
            
            if(estudianteIdentificacion.HasValue)
            {
                estudiante = _repoEstudiante.GetEstudiante(estudianteIdentificacion.Value);
            }else
            {
                estudiante = new Estudiante();
            }
            if (estudiante==null)
            {
                return RedirectToPage("./Estudiantes");
            }else
            {
                return Page();
            }
        }
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }else
            {
               if(estudiante.id>0)
            {
                _repoEstudiante.UpdateEstudiante(estudiante);
            }else
            {
                _repoEstudiante.AddEstudiante(estudiante);
            } 
            }
            return RedirectToPage("./Estudiantes");
        }
    }
}
