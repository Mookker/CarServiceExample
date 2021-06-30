using CarService.AppCore.Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.AppCore.Interfaces
{
    interface IEventFactory<T> where T : class
    {
        BaseEvent<T> CreateEvent(Type eventType);
    }
}
