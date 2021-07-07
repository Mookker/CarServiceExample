using CarService.AppCore.Interfaces;
using CarService.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarService.EventProcessor.Cqrs.Commands.Handlers
{
    public class UpdateRepairOrderCommandHandler : AsyncRequestHandler<UpdateRepairOrderCommand>
    {
        private readonly IRepairOrdersRepository _repairOrdersRepository;

        public UpdateRepairOrderCommandHandler(IRepairOrdersRepository repairOrdersRepository)
        {
            _repairOrdersRepository = repairOrdersRepository;
        }

        protected override async Task Handle(UpdateRepairOrderCommand request, CancellationToken cancellationToken)
        {
            var repairOrder = new RepairOrder
            {
                Id = request.Id,
                CarId = request.CarId,
                OrderDate = request.OrderDate,
                Price = request.Price
            };

            await _repairOrdersRepository.Update(repairOrder);

            var updatedOrder = await _repairOrdersRepository.GetById(repairOrder.Id);

            if (!repairOrder.Equals(updatedOrder))
            {
                throw new Exception("Repair order was not updated");
            }
        }
    }
}
