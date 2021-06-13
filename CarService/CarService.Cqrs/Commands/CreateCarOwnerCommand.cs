using System;
using CarService.AppCore.Models;
using CarService.Domain.Models;
using MediatR;

namespace CarService.Cqrs.Commands
{
    public class CreateCarOwnerCommand: IRequest<CarOwner>
    {
        public CreateCarOwnerCommand(CarOwner carOwner)
        {
            _ = carOwner ?? throw new ArgumentNullException(nameof(carOwner));
            FirstName = carOwner.FirstName;
            LastName = carOwner.LastName;
            DoB = carOwner.DoB;
            CarId = carOwner.CarId;
        }

        public string FirstName { get; init; }
        public string LastName { get; init; }
        public DateTime DoB { get; init; }
        public Guid CarId { get; init; }
    }
}
