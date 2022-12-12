using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto_P1.Models;

namespace Proyecto_P1.Data
{
    public class Proyecto_P1Context : DbContext
    {
        public Proyecto_P1Context (DbContextOptions<Proyecto_P1Context> options)
            : base(options)
        {
        }

        public DbSet<Proyecto_P1.Models.Usuario> Usuario { get; set; } = default!;

        public DbSet<Proyecto_P1.Models.Zapatos> Zapatos { get; set; }

     
     
    }
}
