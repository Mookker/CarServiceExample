using System.Threading;
using System.Threading.Tasks;
using CarService.AppCore.Interfaces;
using CarService.AppCore.Models.Requests;
using CarService.Domain.Models;
using MediatR;

namespace CarService.Cqrs.Commands.Handlers
{
    public class CreateRepairOrderCommandHandler: IRequestHandler<CreateRepairOrderCommand, RepairOrder>
    {
        private readonly IRepairOrdersService _repairOrdersService;

        public CreateRepairOrderCommandHandler(IRepairOrdersService repairOrdersService)
        {
            _repairOrdersService = repairOrdersService;
        }

        public Task<RepairOrder> Handle(CreateRepairOrderCommand request, CancellationToken cancellationToken)
        {
            return _repairOrdersService.CreateAsync(new CreateRepairOrderRequest
            {
                Price = request.Price,
                CarId = request.CarId,
                OrderDate = request.OrderDate
            });
        }
    }
}
