using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;

namespace Ms.Alquiler.Dominio.Entidades
{
    [CollectionProperty("DetalleAlquiler")]
    [BsonIgnoreExtraElements]
    public class DetalleAlquiler : EntityToLower<ObjectId>
    {
        public int IdDetalleAlquiler { get; set; }

        public int IdPelicula { get; set; }
    }
}
