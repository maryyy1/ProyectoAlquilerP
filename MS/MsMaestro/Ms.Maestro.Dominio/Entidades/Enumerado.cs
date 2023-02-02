using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;

namespace Ms.Maestro.Dominio.Entidades
{
    [CollectionProperty("Enumerado")]
    [BsonIgnoreExtraElements]
    public class Enumerado : EntityToLower<ObjectId>
    {
        public int IdEnumerado { get; set; }

        public string Nombre { get; set; }

    }
}
