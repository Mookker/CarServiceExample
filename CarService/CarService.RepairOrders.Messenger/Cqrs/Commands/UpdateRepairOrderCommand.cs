using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.EventProcessor.Cqrs.Commands
{
    public record UpdateRepairOrderCommand : IRequest
    {
        public Guid Id { get; set; }
        public double Price { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid CarId { get; set; }
    }
}
