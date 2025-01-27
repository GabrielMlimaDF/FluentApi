using FluentMappingApi.Data.Mappings;
using FluentMappingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FluentMappingApi.Data
{
    public class ContextApp : DbContext

    {
        public ContextApp(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<StatusAtivoInativo> StatusAtivosInativos { get; set; }
        public DbSet<Tecnico> Tecnicos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TipoMap());
            modelBuilder.ApplyConfiguration(new StatusAtivoInativoMap());
            modelBuilder.ApplyConfiguration(new TecnicoMap());

        }

    }
}
