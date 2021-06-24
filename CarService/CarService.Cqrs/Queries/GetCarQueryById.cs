using System;
using CarService.Domain.Models;
using MediatR;

namespace CarService.Cqrs.Queries
{
    public record GetCarQueryById : IRequest<Car>
    {
        public GetCarQueryById(Guid id) => Id = id;

        public Guid Id { get; }
    }
}
