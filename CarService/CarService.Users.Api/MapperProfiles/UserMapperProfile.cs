using AutoMapper;
using CarService.Users.Api.Models.Dtos;
using CarService.Users.Api.Models.Responses;

namespace CarService.Users.Api.MapperProfiles
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<UserDto, UserResponse>();
        }
    }
}
