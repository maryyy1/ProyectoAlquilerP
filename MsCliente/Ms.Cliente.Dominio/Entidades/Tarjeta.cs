using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ms.Cliente.Dominio.Entidades
{
    [BsonIgnoreExtraElements]
    public class Tarjeta
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public int IdTarjeta { get; set; }

        public string Numero { get; set; }

        public string FechaVencimiento { get; set; }

        public string Cvv { get; set; }

        public double Saldo { get; set; }

        public int Tipo { get; set; }
    }
}
