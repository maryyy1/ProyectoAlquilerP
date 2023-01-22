using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ms.Pelicula.Dominio.Entidades
{
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public int IdCliente { get; set; }

        public string Dni { get; set; }

        public string Nombre { get; set; }

        public string ApePaterno { get; set; }

        public string ApeMaterno { get; set; }

        public string Correo { get; set; }

        public int Sexo { get; set; }
    }
}
