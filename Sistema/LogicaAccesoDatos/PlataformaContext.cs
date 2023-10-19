using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LogicaNegocio.Dominio;
using System.Drawing;
using System.Reflection.Metadata;
using System.Reflection.Emit;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using LogicaNegocio.Parametros;

namespace LogicaAccesoDatos
{   
    public class PlataformaContext : DbContext
    {
        public DbSet<Amenaza> Amenazas { get; set; }
        public DbSet<Ecosistema> Ecosistemas { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<EstadoConservacion> EstadoConservacion { get; set; } // CONVIENE HACER DBSET DE ESTE ATRIBUTO?
        public DbSet<Pais> Pais { get; set; }            
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Parametro> Parametros { get; set; }

        public PlataformaContext(DbContextOptions<PlataformaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Autor>().OwnsOne(au => au.Nombre).HasIndex(nom => nom.Value).IsUnique();
            modelBuilder.Entity<Especie>().OwnsOne(especie => especie.NombreCientifico);
            modelBuilder.Entity<Especie>().OwnsOne(especie => especie.Descripcion);

            modelBuilder.Entity<Usuario>()
                        .HasIndex(u => u.Alias)
                        .IsUnique();

            modelBuilder.Entity<Ecosistema>()
                .HasMany(e => e.Especies)
                .WithMany(e => e.Ecosistemas)
                .UsingEntity<Dictionary<string, object>>(
                    "EcosistemasEspecies",
                    x => x.HasOne<Especie>().WithMany().OnDelete(DeleteBehavior.NoAction),
                    x => x.HasOne<Ecosistema>().WithMany().OnDelete(DeleteBehavior.NoAction)
                );

            modelBuilder.Entity<Ecosistema>()
                .HasMany(e => e.EspeciesPosibles)
                .WithMany(e => e.EcosistemasPosibles)
                .UsingEntity<Dictionary<string, object>>(
                    "EcosistemasEspeciesPosibles",
                    x => x.HasOne<Especie>().WithMany().OnDelete(DeleteBehavior.NoAction),
                    x => x.HasOne<Ecosistema>().WithMany().OnDelete(DeleteBehavior.NoAction)
                );

            modelBuilder.Entity<Especie>()
                .HasMany(ec => ec.Ecosistemas)
                .WithMany(es => es.Especies)
                .UsingEntity(j => j.ToTable("EcosistemasEspecies"));

            modelBuilder.Entity<Ecosistema>()
                .HasMany(es => es.Especies)
                .WithMany(ec => ec.Ecosistemas)
                .UsingEntity(j => j.ToTable("EcosistemasEspecies"));

            modelBuilder.Entity<Especie>()
                .HasMany(ecp => ecp.EcosistemasPosibles)
                .WithMany(ep => ep.EspeciesPosibles)
                .UsingEntity(j => j.ToTable("EcosistemasEspeciesPosibles"));

            modelBuilder.Entity<Ecosistema>()
                .HasMany(es => es.EspeciesPosibles)
                .WithMany(ecp => ecp.EcosistemasPosibles)
                .UsingEntity(j => j.ToTable("EcosistemasEspeciesPosibles"));
           

            base.OnModelCreating(modelBuilder);
        } 

    }
    
}
