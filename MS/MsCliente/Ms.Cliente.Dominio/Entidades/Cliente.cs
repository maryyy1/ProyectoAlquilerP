using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;

namespace Ms.Cliente.Dominio.Entidades
{
    [CollectionProperty("Cliente")]
    [BsonIgnoreExtraElements]
    public class Cliente : EntityToLower<ObjectId>
    {
        public int IdCliente { get; set; }

        public string Dni { get; set; }

        public string Nombre { get; set; }

        public string ApePaterno { get; set; }

        public string ApeMaterno { get; set; }

        public string Correo { get; set; }

        public int Sexo { get; set; }
    }
}
