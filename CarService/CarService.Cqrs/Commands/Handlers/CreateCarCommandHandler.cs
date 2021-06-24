using CarService.AppCore.Interfaces;
using CarService.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarService.Cqrs.Commands.Handlers
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Car>
    {
        private readonly ICarsRepository _carsRepository;

        public CreateCarCommandHandler(ICarsRepository carsRepository)
        {
            _carsRepository = carsRepository;
        }

        public Task<Car> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var model = new Car
            {
                Id = Guid.NewGuid(),
                Make = request.Make,
                Millage = request.Millage,
                Model = request.Model,
                Vin = request.Vin,
                Year = request.Year,
                OwnerId = request.OwnerId
            };

            return _carsRepository.Create(model);
        }
    }
}
