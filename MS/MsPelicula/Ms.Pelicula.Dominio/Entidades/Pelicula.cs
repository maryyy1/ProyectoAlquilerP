using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;

namespace Ms.Pelicula.Dominio.Entidades
{
    [CollectionProperty("Pelicula")]
    [BsonIgnoreExtraElements]
    public class Pelicula : EntityToLower<ObjectId>
    {
        public int PelId { get; set; }

        public string PelNombre { get; set; }

        public string PelDuracion { get; set; }

        public double PelPrecio { get; set; }
    }
}
