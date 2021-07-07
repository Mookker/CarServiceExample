using CarService.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.EventProcessor.Cqrs.Commands
{
    public record CreateRepairOrderCommand : IRequest<RepairOrder>
    {
        public Guid Id { get; init; }
        public double Price { get; init; }
        public Guid CarId { get; init; }
        public DateTime OrderDate { get; init; }
    }
}
