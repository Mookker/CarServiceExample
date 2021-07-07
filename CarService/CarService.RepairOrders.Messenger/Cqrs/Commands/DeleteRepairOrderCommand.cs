using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.EventProcessor.Cqrs.Commands
{
    public record DeleteRepairOrderCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
