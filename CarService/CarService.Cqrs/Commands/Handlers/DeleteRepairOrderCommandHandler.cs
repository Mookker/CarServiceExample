using CarService.AppCore.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CarService.Cqrs.Commands.Handlers
{
    public class DeleteRepairOrderCommandHandler : IRequestHandler<DeleteRepairOrderCommand, Guid>
    {
        private readonly IRepairOrdersService _service;

        public DeleteRepairOrderCommandHandler(IRepairOrdersService service)
        {
            _service = service;
        }

        public async Task<Guid> Handle(DeleteRepairOrderCommand request, CancellationToken cancellationToken)
        {
            await _service.DeleteAsync(request.Id);

            return request.Id;
        }
    }
}
