using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Cqrs.Commands
{
    public class DeleteRepairOrderCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public DeleteRepairOrderCommand(Guid id)
        {
            Id = id;
        }
    }
}
