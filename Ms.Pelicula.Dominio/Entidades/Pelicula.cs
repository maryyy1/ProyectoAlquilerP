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
        public int IdPelicula { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Duracion { get; set; }
        [Required]
        public double Precio { get; set; }
        [Required]
        public Director Director { get; set; }
    }
}
