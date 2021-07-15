using CarService.Users.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using MediatR;
using AutoMapper;
using System.Threading;
using CarService.Users.Api.Cqrs.Queries;
using CarService.Users.Api.Models.Dtos;
using CarService.Users.Api.Models.Domain;
using CarService.Users.Api.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using CarService.Users.Api.MapperProfiles;
using CarService.Users.Api.Cqrs.Commands;
using CarService.Users.Api.Models.Requests;

namespace CarService.Users.Api.Tests
{
    public class UsersControllerTest
    {
        private readonly UsersController _usersController;
        private readonly IMapper _mapper;
        private readonly Mock<IMediator> _mediator;

        public UsersControllerTest()
        {
            _mediator = new Mock<IMediator>();
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<UserMapperProfile>()).CreateMapper();
            _usersController = new UsersController(_mediator.Object, _mapper);
        }

        [Fact]
        public async Task Get_Users_Should_Return_All_Users()
        {
            // Arrange
            _mediator.Setup(m => m.Send(It.IsAny<GetAllUsersQuery>(), default)).ReturnsAsync(GetAllUsersExample());

            // Act
            var result = await _usersController.GetUsers(Guid.Empty);
            
            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<UserResponse>>(objectResult.Value);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public async Task Get_Users_Should_Return_Users_With_Particular_CarId()
        {
            // Arrange
            _mediator.Setup(m => m.Send(It.IsAny<GetAllUsersQuery>(), default)).ReturnsAsync(GetUsersByCarIdExample());
            var carId = Guid.Parse("73fdffd5-d192-4251-9dc1-a0693e28632c");

            // Act
            var result = await _usersController.GetUsers(carId);

            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<UserResponse>>(objectResult.Value);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public async Task Get_User_Should_Return_User_By_Id()
        {
            // Arrange
            var userId = Guid.Parse("C2314F29-5A95-43C8-B37A-4A3582AE9235");
            var user = new UserDto(new User
            {
                Id = userId,
                CarId = Guid.NewGuid(),
                DoB = DateTime.MaxValue,
                FirstName = "UpdatedTest",
                LastName = "UpdatedTest"
            });

            _mediator.Setup(m => m.Send(It.IsAny<GetUserByIdQuery>(), default)).ReturnsAsync(user);

            // Act
            var result = await _usersController.GetUserById(userId);

            // Assert
            var resultObject = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<UserResponse>(resultObject.Value);
            Assert.True(model.Id == user.Id && model.CarId == user.CarId && model.DoB == user.DoB
                && model.FirstName == user.FirstName && model.LastName == user.LastName);
        }

        [Fact]
        public async Task Create_User_Should_Return_Created_User()
        {
            // Arrange
            var userDto = new UserDto(new User
            {
                Id = Guid.NewGuid(),
                CarId = Guid.Parse("73fdffd5-d192-4251-9dc1-a0693e28632c"),
                DoB = DateTime.MinValue,
                FirstName = "Test",
                LastName = "Test"
            });

            _mediator.Setup(m => m.Send(It.IsAny<CreateUserCommand>(), default)).ReturnsAsync(userDto);

            var userRequest = new CreateUserRequest
            {
                CarId = Guid.Parse("73fdffd5-d192-4251-9dc1-a0693e28632c"),
                DoB = DateTime.MinValue,
                FirstName = "Test",
                LastName = "Test"
            };

            // Act
            var result = await _usersController.CreateUser(userRequest);

            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<UserResponse>(objectResult.Value);
            Assert.True(userRequest.CarId == model.CarId && userRequest.DoB == model.DoB
                && userRequest.FirstName == model.FirstName && userRequest.LastName == model.LastName);
        }

        [Fact]
        public async Task Delete_User_Should_Return_Success_Code()
        {
            // Arrange
            var userId = Guid.NewGuid();

            // Act
            var result = await _usersController.DeleteUser(userId);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Delete_User_Should_Return_BadRequest()
        {
            // Arrange
            var userId = Guid.Empty;

            // Act
            var result = await _usersController.DeleteUser(userId);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Update_User_Should_Return_Updated_User()
        {
            // Arrange
            var request = new UpdateUserRequest
            {
                CarId = Guid.NewGuid(),
                DoB = DateTime.MaxValue,
                FirstName = "UpdatedTest",
                LastName = "UpdatedTest"
            };

            var updated = new UserDto(new User
            {
                CarId = request.CarId,
                DoB = request.DoB,
                FirstName = request.FirstName,
                LastName = request.LastName
            });

            _mediator.Setup(m => m.Send(It.IsAny<UpdateUserCommand>(), default)).ReturnsAsync(updated);

            // Act
            var result = await _usersController.UpdateUser(Guid.NewGuid(), request);

            // Assert
            var resultObject = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<UserResponse>(resultObject.Value);
            Assert.True(model.CarId == request.CarId && model.DoB == request.DoB
                && model.FirstName == request.FirstName && model.LastName == request.LastName);
        }

        [Fact]
        public async Task Update_User_Should_Return_BadRequest_When_Body_Null()
        {
            // Act
            var result = await _usersController.UpdateUser(Guid.NewGuid(), null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        private IEnumerable<UserDto> GetAllUsersExample()
        {
            return new[]
            {
                new UserDto(new User
                {
                    Id = Guid.NewGuid(),
                    CarId = Guid.NewGuid(),
                    DoB = DateTime.Now,
                    FirstName = "TestName1",
                    LastName = "TestSurname1"
                }),

                new UserDto(new User
                {
                    Id = Guid.NewGuid(),
                    CarId = Guid.NewGuid(),
                    DoB = DateTime.Now,
                    FirstName = "TestName2",
                    LastName = "TestSurname2"
                }),
            };
        }

        private IEnumerable<UserDto> GetUsersByCarIdExample()
        {
            return new[]
            {
                new UserDto(new User
                {
                    Id = Guid.NewGuid(),
                    CarId = Guid.Parse("73fdffd5-d192-4251-9dc1-a0693e28632c"),
                    DoB = DateTime.Now,
                    FirstName = "TestName1",
                    LastName = "TestSurname1"
                }),

                new UserDto(new User
                {
                    Id = Guid.NewGuid(),
                    CarId = Guid.Parse("a9157875-4dc9-4b34-a70c-22049c2e8ba9"),
                    DoB = DateTime.Now,
                    FirstName = "TestName2",
                    LastName = "TestSurname2"
                }),

                new UserDto(new User
                {
                    Id = Guid.NewGuid(),
                    CarId = Guid.Parse("73fdffd5-d192-4251-9dc1-a0693e28632c"),
                    DoB = DateTime.Now,
                    FirstName = "TestName2",
                    LastName = "TestSurname2"
                })
            };
        }
    }
}
