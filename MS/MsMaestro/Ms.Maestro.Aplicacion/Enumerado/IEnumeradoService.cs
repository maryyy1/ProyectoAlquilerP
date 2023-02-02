using System.Collections.Generic;
using dominio = Ms.Maestro.Dominio.Entidades;

namespace Ms.Maestro.Aplicacion.Enumerado
{
    public interface IEnumeradoService
    {
        List<dominio.Enumerado> ListarEnumerados();
        bool RegistrarEnumerado(dominio.Enumerado enumerado);
        dominio.Enumerado Enumerado(int idEnumerado);
        void Eliminar(int idEnumerado);
    }
}