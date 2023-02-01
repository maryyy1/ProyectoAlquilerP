using System.Collections.Generic;
using dominio = Ms.Cliente.Dominio.Entidades;

namespace Ms.Cliente.Aplicacion.Tarjeta
{
    public interface ITarjetaService
    {
        List<dominio.Tarjeta> ListarTarjetas();
        bool RegistrarTarjeta(dominio.Tarjeta tarjeta);
        dominio.Tarjeta Tarjeta(int idTarjeta);
        void Eliminar(int idTarjeta);
    }
}