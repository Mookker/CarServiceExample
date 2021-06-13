using System;
using CarService.Domain.Models;
using MediatR;

namespace CarService.Cqrs.Queries
{
    public record GetCarQuery : IRequest<Car>
    {
        public GetCarQuery(Guid id) => Id = id;

        public Guid Id { get; }
    }
}
