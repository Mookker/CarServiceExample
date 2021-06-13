using System;
using System.Collections.Generic;
using CarService.Domain.Models;
using MediatR;

namespace CarService.Cqrs.Queries
{
    public record GetCarRepairOrdersQuery : IRequest<List<RepairOrder>>
    {
        public Guid CarId { get; }

        public GetCarRepairOrdersQuery(Guid carId) => CarId = carId;
    }
}
