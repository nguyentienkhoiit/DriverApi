using DriversApi.Models;
using DriversApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DriversApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly DriverService _driverService;

        public DriverController(DriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpGet("{id:length(24)}")]    
        public async Task<IActionResult> Get(string id)
        {
            var existingDriver = await _driverService.GetAsync(id);
            if (existingDriver is null)
            {
                return NotFound();
            }
            return Ok(existingDriver);
        }

        [HttpGet]
        public async Task<IActionResult> Get() { 
            var allDrivers = await _driverService.GetAsync();
            if(allDrivers.Any()) return Ok(allDrivers);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(DriverDtoRequest dtoRequest)
        {
            var dtoResponse = await _driverService.CreateAsync(dtoRequest);
            return CreatedAtAction(nameof(Get), new {id = dtoResponse.Id}, dtoResponse);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<ActionResult<DriverDtoResponse>> Update(string id, DriverDtoRequest dtoRequest)
        {
            var existingDriver = await _driverService.GetAsync(id);
            if(existingDriver is null) return NotFound();
            
           return await _driverService.UpdateAsync(id, dtoRequest);
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existingDriver = await _driverService.GetAsync(id);
            if (existingDriver is null) return NotFound();

            await _driverService.RemoveAsync(id);
            return NoContent();
        }
    }
}
