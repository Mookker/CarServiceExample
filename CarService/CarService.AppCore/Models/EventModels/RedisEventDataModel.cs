using CarService.AppCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.AppCore.Models.EventModels
{
    public class RedisEventDataModel : IBaseEventDataModel
    {
        public Guid Id { get; set; }
    }
}
