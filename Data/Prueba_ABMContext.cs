using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Prueba_ABM.Models;

namespace Prueba_ABM.Models
{
    public class Prueba_ABMContext : DbContext
    {
        public Prueba_ABMContext (DbContextOptions<Prueba_ABMContext> options)
            : base(options)
        {
        }

        public DbSet<Prueba_ABM.Models.Venta> Venta { get; set; }

        public DbSet<Prueba_ABM.Models.Vendedor> Vendedor { get; set; }

        public DbSet<Prueba_ABM.Models.Auto> Auto { get; set; }

        public DbSet<Prueba_ABM.Models.Modelo> Modelo { get; set; }

        public DbSet<Prueba_ABM.Models.Marca> Marca { get; set; }

        public DbSet<Prueba_ABM.Models.Cliente> Cliente { get; set; }
    }
}
