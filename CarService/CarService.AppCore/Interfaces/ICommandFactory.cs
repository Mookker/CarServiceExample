using CarService.AppCore.Models.EventModels;
using CarService.AppCore.Models.Events;
using CarService.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.AppCore.Interfaces
{
    public interface ICommandFactory
    {
        IBaseRequest CreateCommand<T>(BaseEvent<T> @event, RepairOrderRedisEventDataModel eventData) where T : class;
    }
}
