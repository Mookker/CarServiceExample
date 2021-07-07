using CarService.AppCore.Interfaces;
using System;

namespace CarService.AppCore.Models.EventModels
{
    public record RepairOrderCreatedDataModel : IBaseEventDataModel
    {
        public Guid Id { get; set; }
        public double Price { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid CarId { get; set; }
    }
}
