using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductProject.Domain.Models.Response
{
    public class Category
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name"), BsonRequired]
        public string Name { get; set; }

        [BsonElement("Description"), BsonRequired]
        public string Description { get; set; }

    }
}
