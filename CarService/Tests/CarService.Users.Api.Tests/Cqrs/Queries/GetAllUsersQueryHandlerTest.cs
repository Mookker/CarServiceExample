using CarService.Users.Api.Cqrs.Queries;
using CarService.Users.Api.Cqrs.Queries.Handlers;
using CarService.Users.Api.Interfaces;
using CarService.Users.Api.Models.Domain;
using CarService.Users.Api.Models.Dtos;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarService.Users.Api.Tests.Cqrs.Queries
{
    public class GetAllUsersQueryHandlerTest
    {
        private readonly Mock<IUsersRepository> _repository;
        private readonly GetAllUsersQueryHandler _handler;

        public GetAllUsersQueryHandlerTest()
        {
            _repository = new Mock<IUsersRepository>();
            _handler = new GetAllUsersQueryHandler(_repository.Object);
        }

        [Fact]
        public async Task Handler_Should_Handle_Command_And_Return_AllUsers()
        {
            // Arrange
            _repository.Setup(r => r.GetAll()).ReturnsAsync(GetAllUsersExample());

            // Act
            var users = await _handler.Handle(new GetAllUsersQuery(), default);

            // Assert
            Assert.Equal(2, users.Count());
        }

        private List<User> GetAllUsersExample()
        {
            return new List<User>
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    CarId = Guid.NewGuid(),
                    DoB = DateTime.Now,
                    FirstName = "TestName1",
                    LastName = "TestSurname1"
                },

                new User
                {
                    Id = Guid.NewGuid(),
                    CarId = Guid.NewGuid(),
                    DoB = DateTime.Now,
                    FirstName = "TestName2",
                    LastName = "TestSurname2"
                },
            };
        }
    }
}
