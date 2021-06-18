using CarService.Users.Api.Interfaces;
using CarService.Users.Api.Models.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarService.Users.Api.Cqrs.Queries.Handlers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IList<UserDto>>
    {
        private readonly IUsersRepository _usersRepository;

        public GetAllUsersQueryHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<IList<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _usersRepository.GetAll();
            var usersDtoList = users.Select(u => new UserDto(u)).ToList();

            return usersDtoList;
        }
    }
}
