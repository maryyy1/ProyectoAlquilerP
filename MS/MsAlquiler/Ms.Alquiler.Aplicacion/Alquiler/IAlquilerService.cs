using System.Collections.Generic;
using dominio = Ms.Alquiler.Dominio.Entidades;

namespace Ms.Alquiler.Aplicacion.Alquiler
{
    public interface IAlquilerService
    {
        List<dominio.Alquiler> ListarAlquileres();
        bool RegistrarAlquiler(dominio.Alquiler alquiler);
        dominio.Alquiler BuscarAlquiler(int idAlquiler);
        void EliminarAlquiler(int idAlquiler);
    }
}