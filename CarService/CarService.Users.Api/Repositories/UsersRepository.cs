using System;
using System.Collections.Generic;
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
                $@"SELECT ""Id"", ""FirstName"", ""LastName"", ""DoB"", ""CarId"" FROM users WHERE ""Id"" = '{userId}'");
        }

        public Task Create(User user)
        {
            return _dapper.ExecuteAsync(
                @"INSERT INTO users ( ""Id"", ""FirstName"", ""LastName"", ""DoB"", ""CarId"") VALUES (@Id, @FirstName, @LastName, @DoB, @CarId)",
                user);
        }

        public Task<List<User>> GetAll()
        {
            string query = "SELECT * FROM users";
            return _dapper.QueryAsync<User>(query);
        }

        public Task Update(User user)
        {
            string query = @"UPDATE users SET 
                           ""FirstName"" = @FirstName, 
                           ""LastName"" = @LastName, 
                           ""DoB"" = @DoB, 
                           ""CarId"" = @CarId 
                             WHERE ""Id"" = @Id";

            return _dapper.ExecuteAsync(query, user);
        }

        public Task Delete(User user)
        {
            string query = $@"DELETE FROM users WHERE ""Id"" = '{user.Id}'";

            return _dapper.ExecuteAsync(query);
        }

        public Task<User> GetByCarId(Guid carId)
        {
            string query = $@"SELECT * FROM users WHERE ""CarId"" = '{carId}'";

            return _dapper.QueryFirstOrDefaultAsync<User>(query);
        }
    }
}
