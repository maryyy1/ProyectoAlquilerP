using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;

namespace Ms.Cliente.Dominio.Entidades
{
    [CollectionProperty("Tarjeta")]
    [BsonIgnoreExtraElements]
    public class Tarjeta : EntityToLower<ObjectId>
    {
        public int IdTarjeta { get; set; }

        public string Numero { get; set; }

        public string FechaVen { get; set; }

        public string CV { get; set; }

        public double Saldo { get; set; }

    }
}

