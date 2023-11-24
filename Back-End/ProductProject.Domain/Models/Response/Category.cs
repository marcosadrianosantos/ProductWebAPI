using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductProject.Domain.Models.Response
{
    public class Category
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonRequired]
        public string Name { get; set; } = string.Empty;

        [BsonRequired]
        public string Description { get; set; } = string.Empty;

    }
}
