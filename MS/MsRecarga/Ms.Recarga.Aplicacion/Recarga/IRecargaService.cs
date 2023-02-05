using System.Collections.Generic;
using dominio = Ms.Recarga.Dominio.Entidades;

namespace Ms.Recarga.Aplicacion.Recarga
{
    public interface IRecargaService
    {
        List<dominio.Recarga> ListarRecargas();
        bool RegistrarRecarga(dominio.Recarga recarga);
        dominio.Recarga BuscarRecarga(int idRecarga);
        bool ModificarRecarga(dominio.Recarga recarga);
        void EliminarRecarga(int idRecarga);
    }
}
