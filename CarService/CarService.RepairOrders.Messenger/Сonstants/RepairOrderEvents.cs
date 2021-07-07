using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.EventProcessor.Сonstants
{
    public static class RepairOrderEvents
    {
        public const string CreatedEvent = "RepairOrderCreatedEvent";
        public const string UpdatedEvent = "RepairOrderUpdatedEvent";
        public const string DeletedEvent = "RepairOrderDeletedEvent";
    }
}
