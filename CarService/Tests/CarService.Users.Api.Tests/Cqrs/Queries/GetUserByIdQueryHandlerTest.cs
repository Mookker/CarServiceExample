using CarService.Users.Api.Cqrs.Queries;
using CarService.Users.Api.Cqrs.Queries.Handlers;
using CarService.Users.Api.Interfaces;
using CarService.Users.Api.Models.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarService.Users.Api.Tests.Cqrs.Queries
{
    public class GetUserByIdQueryHandlerTest
    {
        private readonly Mock<IUsersRepository> _repository;
        private readonly GetUserByIdQueryHandler _handler;

        public GetUserByIdQueryHandlerTest()
        {
            _repository = new Mock<IUsersRepository>();
            _handler = new GetUserByIdQueryHandler(_repository.Object);
        }

        [Fact]
        public async Task Handler_Shoud_Handle_Query_And_Return_UserById()
        {
            // Arrange
            _repository.Setup(r => r.GetById(It.IsAny<Guid>())).ReturnsAsync(
                new User { Id = Guid.Parse("a7e39df3-3fe4-4944-81f1-8c013687f8cb") });

            // Act
            var user = await _handler.Handle(new GetUserByIdQuery("a7e39df3-3fe4-4944-81f1-8c013687f8cb"), default);

            // Assert
            Assert.Equal(user.Id, Guid.Parse("a7e39df3-3fe4-4944-81f1-8c013687f8cb"));
        }
    }
}
