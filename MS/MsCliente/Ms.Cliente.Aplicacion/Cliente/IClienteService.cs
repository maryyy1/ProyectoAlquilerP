using System.Collections.Generic;
using dominio = Ms.Cliente.Dominio.Entidades;

namespace Ms.Cliente.Aplicacion.Cliente
{
    public interface IClienteService
    {
        List<dominio.Cliente> ListarClientes();
        bool RegistrarCliente(dominio.Cliente cliente);
        dominio.Cliente BuscarCliente(int idCliente);
        void EliminarCliente(int idCliente);
    }
}