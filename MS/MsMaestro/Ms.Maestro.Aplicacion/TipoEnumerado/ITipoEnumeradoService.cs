using System.Collections.Generic;
using dominio = Ms.Maestro.Dominio.Entidades;

namespace Ms.Maestro.Aplicacion.TipoEnumerado
{
    public interface ITipoEnumeradoService
    {
        List<dominio.TipoEnumerado> ListarTiposEnumerados();
        bool RegistrarTipoEnumerado(dominio.TipoEnumerado tipoEnumerado);
        dominio.TipoEnumerado TipoEnumerado(int idTipoEnumerado);
        void Eliminar(int idTipoEnumerado);
    }
}