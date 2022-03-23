using MongoDB.Bson.Serialization.Attributes;

namespace BlueSquare.Domain.Entities
{
    public class Product
    {
        [BsonRequired]
        [BsonElement("product_id")]
        public string Id { get; set; }

        [BsonRequired]
        [BsonElement("product_type")]
        public string Type { get; set; }
    }
}
