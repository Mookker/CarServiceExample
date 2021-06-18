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
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDto>
    {
        private readonly IUsersRepository _usersRepository;

        public UpdateUserCommandHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DoB = request.DoB,
                CarId = request.CarId
            };

            await _usersRepository.Update(user);

            return new UserDto(user);
        }
    }
}
