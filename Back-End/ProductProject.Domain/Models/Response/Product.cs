using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductProject.Domain.Models.Response
{
    public class Product
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonRequired]
        public string Name { get; set; } = string.Empty;

        [ BsonRequired]
        public string Description { get; set; } = string.Empty;

        [BsonRequired, BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }
        public string Color { get; set; } = string.Empty;

        [BsonRequired, BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; } = string.Empty;
        public Category Category { get; set; }
    }
}
