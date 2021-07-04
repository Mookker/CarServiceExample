using CarService.AppCore.Models.Events;
using CarService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.AppCore.Interfaces
{
    public interface IEventFactory
    {
        BaseEvent<T> CreateEvent<T>(Type eventType) where T : class;
    }
}
