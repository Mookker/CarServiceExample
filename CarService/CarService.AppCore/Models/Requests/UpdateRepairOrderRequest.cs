using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.AppCore.Models.Requests
{
    public record UpdateRepairOrderRequest
    {
        public Guid Id { get; init; }
        public double Price { get; init; }
        public DateTime OrderDate { get; init; }
        public Guid CarId { get; init; }
    }
}
