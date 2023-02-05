using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;

namespace Ms.Cliente.Dominio.Entidades
{
    [CollectionProperty("Cliente")]
    [BsonIgnoreExtraElements]
    public class Cliente : EntityToLower<ObjectId>
    {
        public int CliId { get; set; }

        public string CliDni { get; set; }

        public string CliNombre { get; set; }

        public string CliApePat { get; set; }

        public string CliApeMat { get; set; }

        public string CliCorreo { get; set; }

        public int CliSexo { get; set; }
    }
}
