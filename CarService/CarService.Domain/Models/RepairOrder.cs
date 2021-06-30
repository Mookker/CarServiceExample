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

        public override bool Equals(object obj)
        {
            return obj is RepairOrder order &&
                   Id.Equals(order.Id) &&
                   Price == order.Price &&
                   OrderDate == order.OrderDate &&
                   CarId.Equals(order.CarId);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Price, OrderDate, CarId);
        }
    }
}
