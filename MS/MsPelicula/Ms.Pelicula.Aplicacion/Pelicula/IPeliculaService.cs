using System.Collections.Generic;
using dominio = Ms.Pelicula.Dominio.Entidades;

namespace Ms.Pelicula.Aplicacion.Pelicula
{
    public interface IPeliculaService
    {
        List<dominio.Pelicula> ListarPeliculas();
        bool RegistrarPelicula(dominio.Pelicula pelicula);
        dominio.Pelicula BuscarPelicula(int idPelicula);
        bool ModificarPelicula(dominio.Pelicula pelicula);
        void EliminarPelicula(int idPelicula);
    }
}
