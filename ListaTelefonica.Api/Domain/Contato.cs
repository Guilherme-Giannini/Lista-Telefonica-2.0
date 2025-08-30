using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace ListaTelefonica.Api.Domain
{
    public class Contato
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("nome")]
        public string? Nome { get; set; }

        [BsonElement("telefone")]
        public string? Telefone { get; set; }

        [BsonElement("email")]
        public string? Email { get; set; }

        [BsonElement("dataNascimento")]
        public DateTime? DataNascimento { get; set; }

        [BsonElement("enderecos")]
        public IEnumerable<string>? Enderecos { get; set; }
    }
}