using MongoDB.Driver;
using Ms.Pelicula.Infraestructura.DBMongo;
using System;
using System.Collections.Generic;
using System.Text;
using dominio = Ms.Pelicula.Dominio.Entidades;

namespace Ms.Pelicula.Aplicacion.Pelicula.Read
{
    public class DirectorQueryAll
    {
        internal DBMongo _mongo = new DBMongo();
        private IMongoCollection<dominio.Director> _director;

        public DirectorQueryAll(){
            _director = _mongo.db.GetCollection<dominio.Director>("director");
        }

        public IEnumerable<dominio.Director> ListarDirectores()
        {
            return _director.Find(x => true).ToList();
        }
    }
}
