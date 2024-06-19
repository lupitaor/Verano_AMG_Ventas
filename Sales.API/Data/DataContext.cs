
using Microsoft.EntityFrameworkCore;
using Sales.Shared.Entities;

namespace Sales.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
        }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<State> States { get; set; }






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Se determina que el campo Name es el indice del modelo Country, no se puede repetir

            modelBuilder.Entity<Country>().HasIndex(c  => c.Name).IsUnique(); 
            modelBuilder.Entity<State>().HasIndex("CountryId","Name").IsUnique(); //El estado si se puede repetir en otros paises pero no en el mismo pais
            modelBuilder.Entity<City>().HasIndex("StateId","Name").IsUnique(); //Las ciudades si se pueden repetir en otros estados o en otros paises pero no en el mismo estado
        
        }
    }
}
