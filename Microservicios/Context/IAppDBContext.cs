using Microservicios.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservicios.Context
{
    public interface IAppDBContext
    {
        DbSet<Categorias> Categorias { get; set; }
        DbSet<Director> Director { get; set; }
        DbSet<Genero> Generos { get; set; }
        DbSet<Pelicula> Pelicula { get; set; }
    }
}