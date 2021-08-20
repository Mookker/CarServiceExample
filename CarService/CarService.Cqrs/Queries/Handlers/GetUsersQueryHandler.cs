using CarService.AppCore.Interfaces;
using CarService.Domain.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CarService.Cqrs.Queries.Handlers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<CarOwner>>
    {
        private readonly IUsersService _service;

        public GetUsersQueryHandler(IUsersService service)
        {
            _service = service;
        }

        public async Task<IEnumerable<CarOwner>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetUsers();
        }
    }
}
