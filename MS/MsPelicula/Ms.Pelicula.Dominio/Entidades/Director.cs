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
        public int DirId { get; set; }

        public string DirNombre { get; set; }

        public string DirApePat { get; set; }

        public string DirApeMat { get; set; }

        public int DirSexo { get; set; }
    }
}
