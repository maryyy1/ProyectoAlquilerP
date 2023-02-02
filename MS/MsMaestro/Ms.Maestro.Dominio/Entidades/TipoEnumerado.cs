using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;

namespace Ms.Maestro.Dominio.Entidades
{
    [CollectionProperty("TipoEnumerado")]
    [BsonIgnoreExtraElements]
    public class TipoEnumerado : EntityToLower<ObjectId>
    {
        public int IdTipoEnumerado { get; set; }

        public string Nombre { get; set; }

    }
}
