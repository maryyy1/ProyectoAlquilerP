using System.Collections.Generic;
using dominio = Ms.Alquiler.Dominio.Entidades;

namespace Ms.Alquiler.Aplicacion.DetalleAlquiler
{
    public interface IDetalleAlquilerService
    {
        List<dominio.DetalleAlquiler> ListarDetallesAlquileres();
        bool RegistrarDetalleAlquiler(dominio.DetalleAlquiler detalleAlquiler);
        dominio.DetalleAlquiler BuscarDetalleAlquiler(int idDetalleAlquiler);
        bool ModificarDetalleAlquiler(dominio.DetalleAlquiler detalleAlquiler);
        void EliminarDetalleAlquiler(int idDetalleAlquiler);
    }
}