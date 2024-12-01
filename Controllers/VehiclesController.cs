using Microsoft.AspNetCore.Mvc;
using ParkTogether.DAL.Entities;
using ParkTogether.Domain.Interfaces;
using ParkTogether.Domain.Services;

namespace ParkTogether.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController:Controller
    {
        private readonly IVehicleService _vehicleService;


        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;

        }
        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicleAsync()
        {
            var vehicle = await _vehicleService.GetVehicleAsync();

            if (vehicle == null || !vehicle.Any()) return NotFound();

            return Ok(vehicle);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{Id}")]
        public async Task<ActionResult<Vehicle>> GetVehicleByIdAsync(Guid Id)
        {
            var vehicle = await _vehicleService.GetVehicleByIdAsync(Id);

            if (vehicle == null) return NotFound();

            return Ok(vehicle);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Vehicle>> CreateVehicleAsync(Vehicle vehicle)
        {
            try
            {
                var newVehicle = await _vehicleService.CreateVehicleAsync(vehicle);
                if (newVehicle == null) return NotFound();
                return Ok(newVehicle);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe"));
                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Vehicle>> EditVehicleAsync(Vehicle vehicle)
        {
            try
            {
                var editedVehicle = await _vehicleService.EditVehicleAsync(vehicle);
                if (editedVehicle == null) return NotFound();
                return Ok(editedVehicle);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe"));
                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete ")]
        public async Task<ActionResult<Vehicle>> DeleteVehicleAsync(Guid Id)
        {
            if (Id == null) return BadRequest();
            var deletedVehicle = await _vehicleService.DeleteVehicleAsync(Id);
            if (deletedVehicle == null) return NotFound();
            return Ok(deletedVehicle);
        }
    }
}
