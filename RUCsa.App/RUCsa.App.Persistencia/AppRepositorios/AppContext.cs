using Microsoft.EntityFrameworkCore;
using RUCsa.App.Dominio;

namespace RUCsa.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Personas{get;set;}  //repet
        public DbSet<Administrativo> Administrativos{get;set;}
        public DbSet<Estudiante> Estudiantes{get;set;}
        public DbSet<Personal_Aseo> Aseadores{get;set;}
        public DbSet<Personal_Cocina> Cocineros{get;set;}
        public DbSet<Profesor> Profesores{get;set;}
        //public DbSet<Registro_Covid> Contagios{get;set;}
        public DbSet<Restaurante> Restaurantes{get;set;}
        public DbSet<Turno> Turnos{get;set;}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
              if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source =(localdb)\\MSSQLLocalDB; Initial Catalog= RestaurantUC");
            }
        }
    }
}