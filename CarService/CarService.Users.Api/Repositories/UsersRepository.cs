using System;
using System.Threading.Tasks;
using CarService.Users.Api.Interfaces;
using CarService.Users.Api.Models.Domain;
using Dapper.Extensions;

namespace CarService.Users.Api.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IDapper _dapper;

        public UsersRepository(IDapper dapper)
        {
            _dapper = dapper;
        }

        public Task<User> GetById(Guid userId)
        {
            return _dapper.QueryFirstOrDefaultAsync<User>(
                @"SELECT ""Id"", ""FirstName"", ""LastName"", ""DoB"", ""CarId"" FROM users");
        }

        public Task Create(User user)
        {
            return _dapper.ExecuteAsync(
                @"INSERT INTO users ( ""Id"", ""FirstName"", ""LastName"", ""DoB"", ""CarId"") VALUES (@Id, @FirstName, @LastName, @DoB, @CarId)",
                user);
        }
    }
}
