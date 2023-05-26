using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoPrimerParcial.Models;

namespace ProyectoPrimerParcial.Data
{
    public class InstructorContext : DbContext
    {
        public InstructorContext (DbContextOptions<InstructorContext> options)
            : base(options)
        {
        }

        public DbSet<ProyectoPrimerParcial.Models.Instructor> Instructor { get; set; } = default!;

        public DbSet<ProyectoPrimerParcial.Models.Aeronave> Aeronave { get; set; } = default!;
    }
}
