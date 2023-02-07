using MongoDB.Driver;
using Release.MongoDB.Repository;
using Serilog;
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
            try
            {
                Expression<Func<dominio.Cliente, bool>> filter = s => s.esEliminado == false;
                var items = (_cliente.Context().FindAsync(filter, null).Result).ToList();

                return items;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        public bool RegistrarCliente(dominio.Cliente cliente)
        {
            try
            {
                cliente.esEliminado = false;
                cliente.fechaCreacion = DateTime.Now;
                cliente.esActivo = true;
                _clienteR.InsertOne(cliente);

                return true;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return false;
        }

        public dominio.Cliente BuscarCliente(int idCliente)
        {
            try
            {
                Expression<Func<dominio.Cliente, bool>> filter = s => s.esEliminado == false && s.CliId == idCliente;
                var item = (_cliente.Context().FindAsync(filter, null).Result).FirstOrDefault();
                return item;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        public bool ModificarCliente(dominio.Cliente cliente)
        {
            try
            {
                dominio.Cliente clienteActual = BuscarCliente(cliente.CliId);
                if (clienteActual != null)
                {
                    clienteActual.CliDni = cliente.CliDni;
                    clienteActual.CliNombre = cliente.CliNombre;
                    clienteActual.CliApePat = cliente.CliApePat;
                    clienteActual.CliApeMat = cliente.CliApeMat;
                    clienteActual.CliCorreo = cliente.CliCorreo;
                    clienteActual.CliSexo = cliente.CliSexo;
                    clienteActual.fechaModificacion = cliente.fechaModificacion;
                    _clienteR.UpdateOne(clienteActual.id, clienteActual);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return false;
        }

        public void EliminarCliente(int idCliente)
        {
            try
            {
                Expression<Func<dominio.Cliente, bool>> filter = s => s.esEliminado == false && s.CliId == idCliente;
                var item = (_cliente.Context().FindOneAndDelete(filter, null));
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }            
        }
    }
}
