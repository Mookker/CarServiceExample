using System.Threading;
using System.Threading.Tasks;
using CarService.AppCore.Interfaces;
using CarService.AppCore.Models;
using CarService.Domain.Models;
using MediatR;

namespace CarService.Cqrs.Queries.Handlers
{
    public class GetUserByIdQueryHandler: IRequestHandler<GetUserByIdQuery, CarOwner>
    {
        private readonly IUsersService _usersService;

        public GetUserByIdQueryHandler(IUsersService usersService)
        {
            _usersService = usersService;
        }
        public Task<CarOwner> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return _usersService.GetUserById(request.UserId);
        }
    }
}
