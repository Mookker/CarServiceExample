using CarService.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Cqrs.Commands
{
    public record CreateCarCommand : IRequest<Car>
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Vin { get; set; }
        public int Millage { get; set; }
        public string OwnerId { get; set; }

        public CreateCarCommand(Car car)
        {
            Make = car.Make;
            Model = car.Model;
            Year = car.Year;
            Vin = car.Vin;
            Millage = car.Millage;
            OwnerId = car.OwnerId;
        }
    }
}
