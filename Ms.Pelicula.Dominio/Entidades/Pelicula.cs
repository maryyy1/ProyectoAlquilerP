using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ms.Pelicula.Dominio.Entidades
{
    [BsonIgnoreExtraElements]
    public class Pelicula
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public int IdPelicula { get; set; }

        public string Nombre { get; set; }

        public string Duracion { get; set; }

        public double Precio { get; set; }
    }
}
