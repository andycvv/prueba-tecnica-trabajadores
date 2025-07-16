using backend_myper.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_myper.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Departamento>(entity => entity.ToTable("Departamento"));
            modelBuilder.Entity<Distrito>(entity => entity.ToTable("Distrito"));
            modelBuilder.Entity<Provincia>(entity => entity.ToTable("Provincia"));
            modelBuilder.Entity<Trabajador>(entity => entity.ToTable("Trabajadores"));
        }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<Distrito> Distritos { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }
        public virtual DbSet<Trabajador> Trabajadores { get; set; }
    }
}
