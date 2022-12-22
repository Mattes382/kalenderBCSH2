using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace kalendar.Models
{
    public class Poznamka
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string TextPoznamky { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateOnly Datum { get; set; }
    }
}
