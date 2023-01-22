using MongoDB.Driver;
using System.Collections.Generic;
using Ms.Pelicula.Infraestructura.DBMongo;
using dominio = Ms.Pelicula.Dominio.Entidades;

namespace Ms.Pelicula.Aplicacion.Pelicula.Read
{
    public class PeliculaQueryAll
    {
        internal DBMongo _mongo = new DBMongo();
        private IMongoCollection<dominio.Pelicula> _pelicula;

        public PeliculaQueryAll()
        {
            _pelicula = _mongo.db.GetCollection<dominio.Pelicula>("Pelicula");
        }

        public IEnumerable<dominio.Pelicula> ListarPeliculas()
        {
            return _pelicula.Find(x => true).ToList();
        }

        public IMongoCollection<dominio.Pelicula> Coleccion()
        {
            return _pelicula;
        }
    }
}
