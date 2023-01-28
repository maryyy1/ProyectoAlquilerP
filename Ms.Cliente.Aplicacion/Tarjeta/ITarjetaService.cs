using System.Collections.Generic;
using dominio = Ms.Cliente.Dominio.Entidades;

namespace Ms.Cliente.Aplicacion.Pelicula
{
    public interface ITarjetaService
    {
        List<dominio.Tarjeta> ListarTarjeta();
        bool RegistrarTarjeta(dominio.Tarjeta tarjeta);
        dominio.Tarjeta Tarjeta(int idTarjeta);
        void Eliminar(int idTarjeta);
    }
}

