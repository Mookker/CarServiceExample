using CarService.Users.Api.Interfaces;
using CarService.Users.Api.Models.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarService.Users.Api.Cqrs.Queries.Handlers
{
    public class GetUserByUsernameQueryHandler : IRequestHandler<GetUserByUsernameQuery, UserDto>
    {
        private readonly IUsersRepository _repository;

        public GetUserByUsernameQueryHandler(IUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserDto> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByUsername(request.Username);

            return new UserDto(user);
        }
    }
}
