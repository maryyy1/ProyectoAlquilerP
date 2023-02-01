using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;

namespace Ms.Pelicula.Dominio.Entidades
{
    [CollectionProperty("Director")]
    [BsonIgnoreExtraElements]
    public class Director : EntityToLower<ObjectId>
    { 
        public int IdDirector { get; set; }

        public string Nombre { get; set; }

        public string ApePaterno { get; set; }

        public string ApeMaterno { get; set; }

        public int Sexo { get; set; }
    }
}
