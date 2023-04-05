using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Carcode.Models
{
    public class CarModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int Make_ID { get; set; }
        public string Make_Name { get; set; }
        public int Model_ID { get; set; }
        public string Model_Name { get; set; }
        public string Mfr_Name { get; set; }
        public DateTimeOffset CreatedTime {get; set; }
    }
}
