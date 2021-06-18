using System.Threading;
using System.Threading.Tasks;
using CarService.AppCore.Interfaces;
using CarService.Domain.Models;
using MediatR;

namespace CarService.Cqrs.Queries.Handlers
{
    public class GetCarQueryHandler : IRequestHandler<GetCarQueryById, Car>
    {
        private readonly ICarsRepository _carsRepository;

        public GetCarQueryHandler(ICarsRepository carsRepository)
        {
            _carsRepository = carsRepository;
        }

        public Task<Car> Handle(GetCarQueryById request, CancellationToken cancellationToken)
        {
            return _carsRepository.GetById(request.Id);
        }
    }
}
