using Microservicios.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Microservicios.Context
{
    public class AppDBContext : DbContext, IAppDBContext
    {

        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Director> Director { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Pelicula> Pelicula { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=127.0.0.1,1433;Database=Cinema;usuario:sa;password=1234");
        }

    }
}
