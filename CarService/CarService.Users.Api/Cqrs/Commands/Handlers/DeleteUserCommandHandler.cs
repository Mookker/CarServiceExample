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
    public class DeleteUserCommandHandler : AsyncRequestHandler<DeleteUserCommand>
    {
        private readonly IUsersRepository _usersRepository;

        public DeleteUserCommandHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        protected override async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _usersRepository.Delete(request.Id);
        }
    }
}
