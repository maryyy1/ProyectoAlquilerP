using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;

namespace Ms.Alquiler.Dominio.Entidades
{
    [CollectionProperty("DetalleAlquiler")]
    [BsonIgnoreExtraElements]
    public class DetalleAlquiler : EntityToLower<ObjectId>
    {
        public int IdDetalleAlquiler { get; set; }
    }
}
