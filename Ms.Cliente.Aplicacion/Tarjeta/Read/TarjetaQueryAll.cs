using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using Ms.Cliente.Infraestructura.DBMongo;
using dominio = Ms.Cliente.Dominio.Entidades;

namespace Ms.Cliente.Aplicacion.Tarjeta.Read
{
    public class TarjetaQueryAll
    {
        internal DBMongo _mongo = new DBMongo();
        private IMongoCollection<dominio.Tarjeta> _tarjeta;

        public TarjetaQueryAll()
        {
            _tarjeta = _mongo.db.GetCollection<dominio.Tarjeta>("Tarjeta");
        }

        public IEnumerable<dominio.Tarjeta> ListarTarjetas()
        {
            return _tarjeta.Find(x => true).ToList();
        }

        public IMongoCollection<dominio.Tarjeta> Coleccion()
        {
            return _tarjeta;
        }
    }
}
