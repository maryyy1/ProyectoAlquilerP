using MongoDB.Driver;
using Ms.Pelicula.Infraestructura.DBMongo;
using System;
using System.Collections.Generic;
using System.Text;
using dominio = Ms.Pelicula.Dominio.Entidades;

namespace Ms.Pelicula.Aplicacion.Cliente.Read
{
    public class ClienteQueryAll
    {
        internal DBMongo _mongo = new DBMongo();
        private IMongoCollection<dominio.Cliente> _cliente;

        public ClienteQueryAll()
        {
            _cliente = _mongo.db.GetCollection<dominio.Cliente>("Cliente");
        }

        public IEnumerable<dominio.Cliente> ListarClientes()
        {
            return _cliente.Find(x => true).ToList();
        }

        public IMongoCollection<dominio.Cliente> Coleccion()
        {
            return _cliente;
        }
    }
}
