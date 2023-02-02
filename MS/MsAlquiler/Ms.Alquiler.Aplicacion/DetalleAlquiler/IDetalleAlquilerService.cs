using System.Collections.Generic;
using dominio = Ms.Alquiler.Dominio.Entidades;

namespace Ms.Alquiler.Aplicacion.DetalleAlquiler
{
    public interface IDetalleAlquilerService
    {
        List<dominio.DetalleAlquiler> ListarDetallesAlquileres();
        bool RegistrarDetalleAlquiler(dominio.DetalleAlquiler detalleAlquiler);
        dominio.DetalleAlquiler DetalleAlquiler(int idDetalleAlquiler);
        void Eliminar(int idDetalleAlquiler);
    }
}