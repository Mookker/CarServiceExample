using CarService.Users.Api.Interfaces;
using CarService.Users.Api.Models.Domain;
using CarService.Users.Api.Models.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarService.Users.Api.Cqrs.Commands.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, UserDto>
    {
        private readonly IUsersRepository _usersRepository;

        public DeleteUserCommandHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<UserDto> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User { Id = request.Id };

            await _usersRepository.Delete(user);

            return new UserDto(user);
        }
    }
}
