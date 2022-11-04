using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace kalendar.Models
{
    public class Upominka
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string NazevUpominky { get; set; }

        public int Dulezitost { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Datum { get; set; }

    }
}
