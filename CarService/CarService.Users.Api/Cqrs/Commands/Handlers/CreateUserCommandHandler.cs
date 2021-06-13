using System;
using System.Threading;
using System.Threading.Tasks;
using CarService.Users.Api.Interfaces;
using CarService.Users.Api.Models.Domain;
using CarService.Users.Api.Models.Dtos;
using MediatR;

namespace CarService.Users.Api.Cqrs.Commands.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUsersRepository _usersRepository;

        public CreateUserCommandHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                CarId = request.CarId,
                DoB = request.DoB,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            await _usersRepository.Create(user);

            return new UserDto(user);
        }
    }
}
