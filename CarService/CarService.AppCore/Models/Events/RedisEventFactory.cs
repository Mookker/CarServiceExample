using CarService.AppCore.Interfaces;
using CarService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.AppCore.Models.Events
{
    class RedisEventFactory : IEventFactory<RepairOrder>
    {
        public BaseEvent<RepairOrder> CreateEvent(Type eventType)
        {
            return Activator.CreateInstance(eventType) as BaseEvent<RepairOrder>;
        }
    }
}
