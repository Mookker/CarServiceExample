using CarService.AppCore.Interfaces;
using System;

namespace CarService.AppCore.Models.EventModels
{
    public record RepairOrderDeletedDataModel : IBaseEventDataModel
    {
        public Guid Id { get; set; }
    }
}
