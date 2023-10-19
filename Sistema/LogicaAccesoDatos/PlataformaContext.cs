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
using Microsoft.EntityFrameworkCore.Infrastructure;

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

        public DbSet<Log> Log { get; set; }

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

        /*
        public override int SaveChanges()
        {
            this.ChangeTracker.DetectChanges();
            var added = this.ChangeTracker.Entries()
                        .Where(t => t.State == EntityState.Added)
                        .Select(t => t.Entity)
                        .ToArray();            

            var modified = this.ChangeTracker.Entries()
                        .Where(t => t.State == EntityState.Modified)
                        .Select(t => t.Entity)
                        .ToArray();

            foreach (var entity in added)
            {
                if (!(entity is Log))
                {
                    var log = new Log()
                    {
                        TipoEntidad = entity.GetType().Name,
                        //IdEntidad = entity.ToString().
                        FechaHora = DateTime.Now,
                        NombreUsuario = RepositorioUsuario.NombreUsuario
                    };



                }
            }

            foreach (var entity in modified)
            {
                if (entity is ITrack)
                {
                    var track = entity as ITrack;
                    track.ModifiedDate = DateTime.Now;
                    track.ModifiedBy = UserId;
                }
            }






            var modifiedEntities = ChangeTracker.Entries()
                .Where(p => p.State == EntityState.Modified || p.State == EntityState.Added);

            foreach (var entry in modifiedEntities)
            {
                // Aquí, puedes acceder a las propiedades de la entidad y registrar los cambios
                Console.WriteLine($"Entidad: {entry.Entity.GetType().Name}");
                Console.WriteLine("Propiedades Modificadas:");

                foreach (var prop in entry.CurrentValues.Properties.GetColumnNames() .PropertyNames)
                {
                    var originalValue = entry.State == EntityState.Added ? null : entry.GetDatabaseValues().GetValue<object>(prop);
                    var currentValue = entry.CurrentValues[prop];

                    Console.WriteLine($"Propiedad: {prop}, Valor Original: {originalValue}, Valor Actual: {currentValue}");
                }
            }

            return base.SaveChanges();




            return base.SaveChanges();
        }
        */
    }
    
}
