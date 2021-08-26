using CarService.AppCore.Interfaces;
using CarService.AppCore.Models.EventModels;
using CarService.AppCore.Models.Events;
using CarService.Domain.Models;
using CarService.Users.Api.Interfaces;
using CarService.Users.Api.Models.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CarService.Cqrs.Commands.Handlers
{
    public class SeedDataCommandHandler : AsyncRequestHandler<SeedDataCommand>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IRepairOrdersRepository _repairOrdersRepository;
        private readonly ICarsRepository _carsRepository;
        private readonly IEventPublisher _eventPublisher;

        public SeedDataCommandHandler(
            IUsersRepository usersRepository,
            IRepairOrdersRepository repairOrdersRepository,
            ICarsRepository carsRepository,
            IEventPublisher eventPublisher)
        {
            _usersRepository = usersRepository;
            _repairOrdersRepository = repairOrdersRepository;
            _carsRepository = carsRepository;
            _eventPublisher = eventPublisher;
        }

        protected override async Task Handle(SeedDataCommand request, CancellationToken cancellationToken)
        {
            var cars = new[]
            {
                new Car
                {
                    Id = Guid.NewGuid(),
                    Make = "Toyota",
                    Model = "Camry",
                    Millage = 50000,
                    Year = 2018,
                    Vin = "1LNHM82W13Y707794",
                    OwnerId = Guid.Empty.ToString()
                },

                new Car
                {
                    Id = Guid.NewGuid(),
                    Make = "Honda",
                    Model = "Accord",
                    Millage = 90500,
                    Year = 2015,
                    Vin = "YV1SZ58D721086613",
                    OwnerId = Guid.Empty.ToString()
                },

                new Car
                {
                    Id = Guid.NewGuid(),
                    Make = "Skoda",
                    Model = "Fabia",
                    Millage = 230000,
                    Year = 2008,
                    Vin = "3TMJU4GN0BM147887",
                    OwnerId = Guid.Empty.ToString()
                }
            };

            var users = new[]
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    DoB = new DateTime(2001, 9, 25),
                    FirstName = "Albert",
                    LastName = "Terry",
                    CarId = cars[0].Id
                },

                new User
                {
                    Id = Guid.NewGuid(),
                    DoB = new DateTime(2000, 1, 16),
                    FirstName = "Ford",
                    LastName = "James",
                    CarId = cars[1].Id
                },

                new User
                {
                    Id = Guid.NewGuid(),
                    DoB = new DateTime(1990, 8, 4),
                    FirstName = "Alexander",
                    LastName = "Angelo",
                    CarId = cars[2].Id
                }
            };

            for (int i = 0; i < users.Length; i++)
            {
                cars[i].OwnerId = users[i].Id.ToString();
            }

            var repairOrders = new[]
            {
                new RepairOrder
                {
                    Id = Guid.NewGuid(),
                    OrderDate = DateTime.Now,
                    Price = 500,
                    CarId = cars[0].Id
                },

                new RepairOrder
                {
                    Id = Guid.NewGuid(),
                    OrderDate = DateTime.Now,
                    Price = 200,
                    CarId = cars[1].Id
                },

                new RepairOrder
                {
                    Id = Guid.NewGuid(),
                    OrderDate = DateTime.Now,
                    Price = 100,
                    CarId = cars[2].Id
                },
            };

            for (int i = 0; i < users.Length; i++)
            {
                var user = users[i];
                var car = cars[i];
                var repairOrder = repairOrders[i];

                await _usersRepository.Create(user);
                await _carsRepository.Create(car);
                await _repairOrdersRepository.Create(repairOrder);

                await _eventPublisher.PublishEvent("repairOrders", new RepairOrderCreatedEvent 
                { 
                    Type = nameof(RepairOrderCreatedEvent),
                    Data = new RepairOrderCreatedDataModel
                    {
                        Id = repairOrder.Id,
                        CarId = repairOrder.CarId,
                        OrderDate = repairOrder.OrderDate,
                        Price = repairOrder.Price
                    }
                });
            }
        }
    }
}
