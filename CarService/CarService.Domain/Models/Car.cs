using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;

namespace CarService.Domain.Models
{
    public class Car: IBaseModel
    {
        [BsonId, BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id { get; set; }

        [BsonElement("make")]
        public string Make { get; set; }

        [BsonElement("model")]

        public string Model { get; set; }
        [BsonElement("year")]

        public int Year { get; set; }
        [BsonElement("vin")]

        public string Vin { get; set; }
        [BsonElement("millage")]

        public int Millage { get; set; }
        [BsonElement("ownerId")]

        public string OwnerId { get; set; }
    }
}
