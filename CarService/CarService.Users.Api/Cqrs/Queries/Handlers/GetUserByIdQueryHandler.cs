using System;
using System.Threading;
using System.Threading.Tasks;
using CarService.Users.Api.Interfaces;
using CarService.Users.Api.Models.Dtos;
using MediatR;

namespace CarService.Users.Api.Cqrs.Queries.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUsersRepository _usersRepository;

        public GetUserByIdQueryHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _usersRepository.GetById(Guid.Parse(request.UserId));

            return new UserDto(user);
        }
    }
}
