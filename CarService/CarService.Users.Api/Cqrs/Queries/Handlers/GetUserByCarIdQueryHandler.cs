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
    public class GetUserByCarIdQueryHandler : IRequestHandler<GetUserByCarIdQuery, UserDto>
    {
        private readonly IUsersRepository _usersRepository;

        public GetUserByCarIdQueryHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<UserDto> Handle(GetUserByCarIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _usersRepository.GetByCarId(request.CarId);

            return new UserDto(user);
        }
    }
}
