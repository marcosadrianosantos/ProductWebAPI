using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductProject.Domain.Models.Response
{
    public class Product
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name"), BsonRequired]
        public string Name { get; set; }

        [BsonElement("Description"), BsonRequired]
        public string Description { get; set; }

        [BsonElement("Price"), BsonRequired, BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }

        [BsonElement("Color")]
        public string Color { get; set; }

        [BsonElement("CategoryId"), BsonRequired, BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }

        [BsonElement("Category")]
        public Category Category { get; set; }
    }
}
