using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace Zuko.Data.Models
{
    public abstract class BaseModel
    {
        [BsonId, BsonElement("_id")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ModifiedAt { get; set; } = DateTime.Now;
        public string LastModifiedBy { get; set; } = "zuko-api";
    }
}
