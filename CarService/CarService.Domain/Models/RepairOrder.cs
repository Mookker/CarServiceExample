using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;

namespace CarService.Domain.Models
{
    public class RepairOrder: IBaseModel
    {
        public Guid Id { get; set; }

        [BsonElement("price")]
        public double Price { get; set; }

        [BsonElement("orderDate")]
        public DateTime OrderDate { get; set; }

        [BsonElement("carId")]
        public Guid CarId { get; set; }
    }
}
