using System.Threading.Tasks;
using AutoMapper;
using CarService.RepariOrders.Api.Interfaces;
using CarService.RepariOrders.Api.Models.Requests;
using CarService.RepariOrders.Api.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CarService.RepariOrders.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class RepairOrdersController : Controller
    {
        private readonly IRepairOrdersService _repairOrdersService;
        private readonly IMapper _mapper;

        public RepairOrdersController(IRepairOrdersService repairOrdersService, IMapper mapper)
        {
            _repairOrdersService = repairOrdersService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRepairOrder([FromBody]CreateRepairModelRequest createRepairModelRequest)
        {
            if (createRepairModelRequest == null)
            {
                return BadRequest("Body is missing");
            }

            var result = await _repairOrdersService.CreateRepairOrder(createRepairModelRequest);

            return Ok(_mapper.Map<RepairOrderResponse>(result));
        }
    }
}
