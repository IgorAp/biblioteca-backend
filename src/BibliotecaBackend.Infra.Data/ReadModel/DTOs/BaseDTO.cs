using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace BibliotecaBackend.Infra.Data.ReadModel.DTOs
{
    public class BaseDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public Guid Key { get; set; }
    }
}
