using MongoDB.Bson.Serialization.Attributes;

namespace BlueSquare.Domain.Entities
{
    public class Customer
    {
        [BsonRequired]
        [BsonElement("client_firstname")]
        public string FirstName { get; set; }

        [BsonRequired]
        [BsonElement("client_lastname")]
        public string LastName { get; set; }

        [BsonRequired]
        [BsonElement("client_postcode")]
        public string Postcode { get; set; }

        [BsonRequired]
        [BsonElement("client_mobile")]
        public string PhoneNumber { get; set; }
    }
}
