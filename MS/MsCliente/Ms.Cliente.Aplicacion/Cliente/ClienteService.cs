using MongoDB.Driver;
using Release.MongoDB.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using dominio = Ms.Cliente.Dominio.Entidades;

namespace Ms.Cliente.Aplicacion.Cliente
{

    public class ClienteService : IClienteService
    {
        private readonly ICollectionContext<dominio.Cliente> _cliente;
        private readonly IBaseRepository<dominio.Cliente> _clienteR;

        public ClienteService(ICollectionContext<dominio.Cliente> cliente,
                                IBaseRepository<dominio.Cliente> clienteR)
        {
            _cliente = cliente;
            _clienteR = clienteR;
        }

        public List<dominio.Cliente> ListarClientes()
        {
            Expression<Func<dominio.Cliente, bool>> filter = s => s.esEliminado == false;
            var items = (_cliente.Context().FindAsync(filter, null).Result).ToList();
            return items;
        }

        public bool RegistrarCliente(dominio.Cliente cliente)
        {
            cliente.esEliminado = false;
            cliente.fechaCreacion = DateTime.Now;
            cliente.esActivo = true;

            _clienteR.InsertOne(cliente);

            return true;
        }

        public dominio.Cliente Cliente (int idCliente)
        {
            Expression<Func<dominio.Cliente, bool>> filter = s => s.esEliminado == false && s.IdCliente == idCliente;
            var item = (_cliente.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return item;
        }

        public void Eliminar(int idCliente)
        {
            Expression<Func<dominio.Cliente, bool>> filter = s => s.esEliminado == false && s.IdCliente == idCliente;
            var item = (_cliente.Context().FindOneAndDelete(filter, null));

        }
    }
}

