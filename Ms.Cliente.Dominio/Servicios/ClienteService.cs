using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using Ms.Cliente.Infraestructura.DBSetting;
using dominio = Ms.Cliente.Dominio.Entidades;

namespace Ms.Cliente.Dominio.Servicios
{
    public class ClienteService
    {
        private IMongoCollection<dominio.Cliente> _cliente;

        public ClienteService(IDBSettings dBSettings)
        {
            var cliente = new MongoClient(dBSettings.Server);
            var database = cliente.GetDatabase(dBSettings.Database);
            _cliente = database.GetCollection<dominio.Cliente>(dBSettings.Collection);
        }

        public List<dominio.Cliente> ListarClientes()
        {
            return _cliente.Find(x => true).ToList();
        }
    }
}
