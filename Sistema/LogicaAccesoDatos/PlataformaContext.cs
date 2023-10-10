using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LogicaNegocio;
using LogicaNegocio.Dominio;

namespace LogicaAccesoDatos
{
   
        public class PlataformaContext : DbContext
        {
            public DbSet<Amenaza> Amenazas { get; set; }

            public DbSet<Ecosistema> Ecosistemas { get; set; }

            public DbSet<EspecieMarina> EspecieMarinas { get; set; }

            public DbSet<EstadoConservacion> EstadoConservacions { get; set; } // CONVIENE HACER DBSET DE ESTE ATRIBUTO?

            public DbSet<Pais> Pais { get; set; }

            

            public DbSet<Usuario> UsuarioAutorizado { get; set; }




            public PlataformaContext(DbContextOptions<PlataformaContext> options) : base(options)
            {
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Usuario>().HasIndex(u => u.Alias)
                                                .IsUnique();
            }
        }
    }

