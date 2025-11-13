using Microsoft.EntityFrameworkCore;
using Actividad5LengProg3.Models;
using System.Collections.Generic;

namespace Actividad5LengProg3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Recinto> Recintos { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
    }
}

