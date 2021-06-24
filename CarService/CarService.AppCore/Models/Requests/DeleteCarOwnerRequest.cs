using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.AppCore.Models.Requests
{
    public record DeleteCarOwnerRequest
    {
        public Guid Id { get; init; }
    }
}
