using BlueSquare.Domain.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace BlueSquare.Domain.Entities
{
    public class Update
    {
        [BsonRequired]
        public string Timestamp { get; set; }

        [BsonRequired]
        public JobStatus Status { get; set; }
    }
}
