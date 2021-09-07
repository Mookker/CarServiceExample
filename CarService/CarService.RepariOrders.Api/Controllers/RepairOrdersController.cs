using AutoMapper;
using CarService.AppCore.Interfaces;
using CarService.AppCore.Models.Requests;
using CarService.RepariOrders.Api.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRepairOrderById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var model = await _repairOrdersService.GetById(id);

            if (model == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<RepairOrderResponse>(model);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetRepairOrderByCarId([FromQuery] Guid carId)
        {
            if (carId == Guid.Empty)
            {
                return BadRequest();
            }

            var model = await _repairOrdersService.GetByCarId(carId);

            if (model == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<RepairOrderResponse>(model);

            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> CreateRepairOrder([FromBody] CreateRepairOrderRequest request)
        {
            if (request == null)
            {
                return BadRequest("Body is missing");
            }

            var result = await _repairOrdersService.CreateAsync(request);

            return Ok(_mapper.Map<RepairOrderResponse>(result));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRepairOrder([FromBody] AppCore.Models.Requests.UpdateRepairOrderRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var foundOrder = await _repairOrdersService.GetById(request.Id);

            if (foundOrder == null)
            {
                return NotFound();
            }

            await _repairOrdersService.UpdateAsync(request);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepairOrder(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var foudOrder = await _repairOrdersService.GetById(id);

            if (foudOrder == null)
            {
                return NotFound();
            }

            await _repairOrdersService.DeleteAsync(id);

            return Ok();
        }
    }
}
