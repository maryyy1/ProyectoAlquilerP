using System.Collections.Generic;
using dominio = Ms.Pelicula.Dominio.Entidades;

namespace Ms.Pelicula.Aplicacion.Director
{
    public interface IDirectorService
    {
        List<dominio.Director> ListarDirectores();
        bool RegistrarDirector(dominio.Director director);
        dominio.Director Director(int idDirector);
        void Eliminar(int idDirector);
    }
}
