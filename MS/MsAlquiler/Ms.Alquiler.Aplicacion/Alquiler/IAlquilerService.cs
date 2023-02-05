using System.Collections.Generic;
using dominio = Ms.Alquiler.Dominio.Entidades;

namespace Ms.Alquiler.Aplicacion.Alquiler
{
    public interface IAlquilerService
    {
        List<dominio.Alquiler> ListarAlquileres();
        bool RegistrarAlquiler(dominio.Alquiler alquiler);
        dominio.Alquiler BuscarAlquiler(int idAlquiler);
        bool ModificarAlquiler(dominio.Alquiler alquiler);
        void EliminarAlquiler(int idAlquiler);
    }
}