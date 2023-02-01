using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
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

        public string FechaVencimiento { get; set; }

        public string Cvv { get; set; }

        public double Saldo { get; set; }

        public int Tipo { get; set; }
    }
}
