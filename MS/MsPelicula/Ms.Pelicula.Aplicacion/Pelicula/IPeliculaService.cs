using System.Collections.Generic;
using dominio = Ms.Pelicula.Dominio.Entidades;

namespace Ms.Pelicula.Aplicacion.Pelicula
{
    public interface IPeliculaService
    {
        List<dominio.Pelicula> ListarPeliculas();
        bool RegistrarPelicula(dominio.Pelicula pelicula);
        dominio.Pelicula Pelicula(int idPelicula);
        void Eliminar(int idPelicula);
    }
}
