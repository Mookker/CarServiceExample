using CarService.AppCore.Interfaces;
using CarService.AppCore.Models.Requests;
using CarService.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarService.Cqrs.Commands.Handlers
{
    public class UpdateCarOwnerCommandHandler : IRequestHandler<UpdateCarOwnerCommand, CarOwner>
    {
        private readonly IUsersService _usersService;

        public UpdateCarOwnerCommandHandler(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public Task<CarOwner> Handle(UpdateCarOwnerCommand request, CancellationToken cancellationToken)
        {
            var carOwnerRequest = new UpdateCarOwnerRequest
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                CarId = request.CarId,
                DoB = request.DoB
            };

            return _usersService.UpdateUser(carOwnerRequest);
        }
    }
}
