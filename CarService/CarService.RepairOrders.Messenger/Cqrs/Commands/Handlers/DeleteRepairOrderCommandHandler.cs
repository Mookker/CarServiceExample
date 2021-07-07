using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CarService.AppCore.Interfaces;
using MediatR;

namespace CarService.EventProcessor.Cqrs.Commands.Handlers
{
    public class DeleteRepairOrderCommandHandler : AsyncRequestHandler<DeleteRepairOrderCommand>
    {
        private readonly IRepairOrdersRepository _repairOrdersRepository;

        public DeleteRepairOrderCommandHandler(IRepairOrdersRepository repairOrdersRepository)
        {
            _repairOrdersRepository = repairOrdersRepository;
        }

        protected override Task Handle(DeleteRepairOrderCommand request, CancellationToken cancellationToken)
        {
            return _repairOrdersRepository.Delete(request.Id);
        }
    }
}
