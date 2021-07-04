using CarService.AppCore.Interfaces;
using CarService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.AppCore.Models.EventModels
{
    public class RepairOrderRedisEventDataModel : IBaseEventDataModel
    {
        public Guid Id { get; set; }
        public double Price { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid CarId { get; set; }
    }
}
