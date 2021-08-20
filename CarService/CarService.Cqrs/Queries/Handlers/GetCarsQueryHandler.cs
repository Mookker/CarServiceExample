using CarService.AppCore.Interfaces;
using CarService.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarService.Cqrs.Queries.Handlers
{
    public class GetCarsQueryHandler : IRequestHandler<GetCarsQuery, IEnumerable<Car>>
    {
        private ICarsRepository _carsRepository;

        public GetCarsQueryHandler(ICarsRepository carsRepository)
        {
            _carsRepository = carsRepository;
        }

        public async Task<IEnumerable<Car>> Handle(GetCarsQuery request, CancellationToken cancellationToken)
        {
            return await _carsRepository.GetAll();
        }
    }
}
