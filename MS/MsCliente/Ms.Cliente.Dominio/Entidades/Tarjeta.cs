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
        public int TarId { get; set; }

        public string TarNumero { get; set; }

        public string TarFecVen{ get; set; }

        public string TarCvv { get; set; }

        public double TarSaldo { get; set; }

        public int TarTipo { get; set; }
    }
}
