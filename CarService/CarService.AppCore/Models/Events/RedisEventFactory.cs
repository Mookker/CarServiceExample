using CarService.AppCore.Interfaces;
using CarService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.AppCore.Models.Events
{
    public class RedisEventFactory : IEventFactory
    {
        public BaseEvent<T> CreateEvent<T>(Type eventType) where T : class
        {
            return Activator.CreateInstance(eventType) as BaseEvent<T>;
        }
    }
}
