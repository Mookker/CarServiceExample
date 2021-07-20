using AutoMapper;
using CarService.Users.Api.MapperProfiles;
using CarService.Users.Api.Models.Domain;
using CarService.Users.Api.Models.Dtos;
using CarService.Users.Api.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarService.Tests.CarService.Users.Api.Tests
{
    public class UserMapperTest
    {
        private readonly IMapper _userMapper;

        public UserMapperTest()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<UserMapperProfile>());
            _userMapper = config.CreateMapper();
        }

        [Fact]
        public void User_Mapper_Configuration_IsValid()
        {
            // Arrange
            var config = new MapperConfiguration(cfg => cfg.AddProfile<UserMapperProfile>());

            // Assert
            config.AssertConfigurationIsValid();
        }

        [Fact]
        public void User_Mapper_Correct_Mapping()
        {
            // Arrange
            var user = new User
            {
                Id = Guid.NewGuid(),
                CarId = Guid.NewGuid(),
                FirstName = "testName",
                LastName = "testLastName",
                DoB = DateTime.Now
            };

            var userDto = new UserDto(user);

            // Act
            var userResponse = _userMapper.Map<UserResponse>(userDto);

            // Assert
            Assert.True(userDto.Id == userResponse.Id && userDto.FirstName == userResponse.FirstName
                && userDto.LastName == userResponse.LastName && userDto.DoB == userResponse.DoB
                && userDto.CarId == userResponse.CarId);
        }
    }
}
