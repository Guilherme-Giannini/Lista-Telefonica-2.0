using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace ListaTelefonica.Infrastructure.Persistence
{
    public class MongoContato
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("nome")]
        public string Nome { get; set; } = null!;

        [BsonElement("telefone")]
        public string Telefone { get; set; } = null!;

        [BsonElement("email")]
        public string Email { get; set; } = null!;

        [BsonElement("dataNascimento")]
        public DateTime? DataNascimento { get; set; }

        [BsonElement("enderecos")]
        public List<string>? Enderecos { get; set; }
    }
}
