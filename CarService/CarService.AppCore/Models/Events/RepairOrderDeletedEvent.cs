using CarService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.AppCore.Models.Events
{
    public record RepairOrderDeletedEvent : BaseEvent<RepairOrder>
    {
    }
}
