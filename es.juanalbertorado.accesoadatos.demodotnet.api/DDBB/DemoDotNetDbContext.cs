using es.juanalbertorado.accesoadatos.demodotnet.api.Entities;
using Microsoft.EntityFrameworkCore;

namespace es.juanalbertorado.accesoadatos.demodotnet.api.DDBB
{
    
    public class DemoDotNetDbContext : DbContext
    {
        public DemoDotNetDbContext(DbContextOptions<DemoDotNetDbContext> options) :base(options) { }
        public DbSet<Estudiante> Estudiantees { get; set; }
        public DbSet<Modulo> Modulos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Estudiante>().HasData();
        }
    }
}
