using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace kalendar.Models
{
    public class Udalost
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Nazev { get; set; }

        public string? Popis { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime datumod { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? datumdo { get; set; }

    }
}
