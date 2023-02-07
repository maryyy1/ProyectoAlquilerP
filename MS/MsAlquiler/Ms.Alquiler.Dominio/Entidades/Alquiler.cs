﻿using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;

namespace Ms.Alquiler.Dominio.Entidades
{
    [CollectionProperty("Alquiler")]
    [BsonIgnoreExtraElements]
    public class Alquiler : EntityToLower<ObjectId>
    {
        public int AlqId { get; set; }

        public string AlqFecIni { get; set; }

        public string AlqFecFin { get; set; }

        public string AlqEnlace { get; set; }

        public int AlqIdCli { get; set; }

    }
}
