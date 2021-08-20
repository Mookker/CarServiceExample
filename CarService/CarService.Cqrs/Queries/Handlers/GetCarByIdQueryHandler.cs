using System.Threading;
using System.Threading.Tasks;
using CarService.AppCore.Interfaces;
using CarService.Domain.Models;
using MediatR;

namespace CarService.Cqrs.Queries.Handlers
{
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, Car>
    {
        private readonly ICarsRepository _carsRepository;

        public GetCarByIdQueryHandler(ICarsRepository carsRepository)
        {
            _carsRepository = carsRepository;
        }

        public Task<Car> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            return _carsRepository.GetById(request.Id);
        }
    }
}
