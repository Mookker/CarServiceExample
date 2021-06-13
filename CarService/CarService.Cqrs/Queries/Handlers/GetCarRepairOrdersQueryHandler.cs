using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CarService.AppCore.Interfaces;
using CarService.Domain.Models;
using MediatR;

namespace CarService.Cqrs.Queries.Handlers
{
    public class GetCarRepairOrdersQueryHandler: IRequestHandler<GetCarRepairOrdersQuery, List<RepairOrder>>
    {
        private readonly IRepairOrdersRepository _repairOrdersRepository;

        public GetCarRepairOrdersQueryHandler(IRepairOrdersRepository repairOrdersRepository)
        {
            _repairOrdersRepository = repairOrdersRepository;
        }
        public Task<List<RepairOrder>> Handle(GetCarRepairOrdersQuery request, CancellationToken cancellationToken)
        {
            return _repairOrdersRepository.GetByCarId(request.CarId);
        }
    }
}
