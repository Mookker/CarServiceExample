using AutoMapper;
using CarService.RepariOrders.Api.Models.Domain;
using CarService.RepariOrders.Api.Models.Responses;

namespace CarService.RepariOrders.Api.MapperProfiles
{
    public class RepairOrderMapperProfile: Profile
    {
        public RepairOrderMapperProfile()
        {
            CreateMap<RepairOrder, RepairOrderResponse>();
        }
    }
}
