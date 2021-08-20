using CarService.Domain.Models;
using MediatR;
using System.Collections.Generic;

namespace CarService.Cqrs.Queries
{
    public class GetUsersQuery : IRequest<IEnumerable<CarOwner>>
    {
    }
}
