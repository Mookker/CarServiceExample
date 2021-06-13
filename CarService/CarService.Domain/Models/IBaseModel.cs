using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarService.Domain.Models
{
    public interface IBaseModel
    {
        [BsonId, BsonGuidRepresentation(GuidRepresentation.Standard)]
        Guid Id { get; set; }
    }
}
