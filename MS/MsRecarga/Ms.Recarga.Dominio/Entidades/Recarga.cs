using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;

namespace Ms.Recarga.Dominio.Entidades
{
    [CollectionProperty("Recarga")]
    [BsonIgnoreExtraElements]
    public class Recarga : EntityToLower<ObjectId>
    {
        public int RecId { get; set; }

        public string RecFecha { get; set; }

        public double RecMonto { get; set; }

        public int RecCliId { get; set; }
    }
}
