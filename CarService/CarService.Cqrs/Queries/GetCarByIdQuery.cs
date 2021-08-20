using System;
using CarService.Domain.Models;
using MediatR;

namespace CarService.Cqrs.Queries
{
    public record GetCarByIdQuery : IRequest<Car>
    {
        public GetCarByIdQuery(Guid id) => Id = id;

        public Guid Id { get; }
    }
}
