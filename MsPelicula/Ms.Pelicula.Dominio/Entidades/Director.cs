using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Ms.Pelicula.Dominio.Entidades
{
    public class Director
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public int IdDirector { get; set; }

        public string Nombre { get; set; }

        public string ApePaterno { get; set; }

        public string ApeMaterno { get; set; }

        public int Sexo { get; set; }
    }
}
