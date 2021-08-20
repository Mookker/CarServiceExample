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
    public class GetRepairOrdersQueryHandler : IRequestHandler<GetRepairOrdersQuery, IEnumerable<RepairOrder>>
    {
        private IRepairOrdersRepository _repository;

        public GetRepairOrdersQueryHandler(IRepairOrdersRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RepairOrder>> Handle(GetRepairOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}
