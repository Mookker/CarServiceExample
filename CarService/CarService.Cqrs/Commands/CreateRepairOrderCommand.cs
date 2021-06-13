using System;
using CarService.Domain.Models;
using MediatR;

namespace CarService.Cqrs.Commands
{
    public record CreateRepairOrderCommand: IRequest<RepairOrder>
    {
        public CreateRepairOrderCommand(RepairOrder repairOrder)
        {
            Price = repairOrder.Price;
            CarId = repairOrder.CarId;
            OrderDate = repairOrder.OrderDate;
        }


        public double Price { get; }
        public Guid CarId { get; }
        public DateTime OrderDate { get; }
    }
}
