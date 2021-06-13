using System.Threading;
using System.Threading.Tasks;
using CarService.AppCore.Interfaces;
using CarService.AppCore.Models;
using CarService.AppCore.Models.Requests;
using CarService.Domain.Models;
using MediatR;

namespace CarService.Cqrs.Commands.Handlers.Handlers
{
    public class CreateCarOwnerCommandHandler: IRequestHandler<CreateCarOwnerCommand, CarOwner>
    {
        private readonly IUsersService _usersService;

        public CreateCarOwnerCommandHandler(IUsersService usersService)
        {
            _usersService = usersService;
        }
        public Task<CarOwner> Handle(CreateCarOwnerCommand request, CancellationToken cancellationToken)
        {
            return _usersService.CreateUser(new CreateCarOwnerRequest
            {
                CarId = request.CarId,
                DoB = request.DoB,
                FirstName = request.FirstName,
                LastName = request.LastName
            });
        }
    }
}
