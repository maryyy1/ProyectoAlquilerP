using MongoDB.Driver;
using Ms.Pelicula.Infraestructura.DBSetting;
using System.Collections.Generic;
using dominio = Ms.Pelicula.Dominio.Entidades;

namespace Ms.Pelicula.Dominio.Servicios
{
    public class PeliculaService
    {
        private IMongoCollection<dominio.Pelicula> _pelicula;

        public PeliculaService(IDBSettings dBSettings)
        {
            var cliente = new MongoClient(dBSettings.Server);
            var database = cliente.GetDatabase(dBSettings.Database);
            _pelicula = database.GetCollection<dominio.Pelicula>(dBSettings.Collection);
        }

        public List<dominio.Pelicula> ListarPeliculas()
        {
            return _pelicula.Find(x => true).ToList();
        }
    }
}
