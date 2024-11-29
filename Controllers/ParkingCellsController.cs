using Microsoft.AspNetCore.Mvc;
using ParkTogether.DAL.Entities;
using ParkTogether.Domain.Interfaces;
using ParkTogether.Domain.Services;

namespace ParkTogether.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingCellController : Controller
    {
        private readonly IParkingCellService _parkingCellService;

        public ParkingCellController(IParkingCellService parkingCellService)
        {
            _parkingCellService = parkingCellService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<ParkingCell>>> GetParkingCellAsync()
        {
            var parkingCells = await _parkingCellService.GetParkingCellAsync();

            if (parkingCells == null || !parkingCells.Any()) return NotFound();

            return Ok(parkingCells);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{Id}")]
        public async Task<ActionResult<ParkingCell>> GetParkingCellByIdAsync(Guid Id)
        {
            var parkingCell = await _parkingCellService.GetParkingCellByIdAsync(Id);

            if (parkingCell == null) return NotFound();

            return Ok(parkingCell);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<ParkingCell>> CreateParkingCellAsync([FromBody] ParkingCell parkingCell, [FromQuery] string adminName, [FromQuery] string adminPassword)
        {
            try
            {
                var newParkingCell = await _parkingCellService.CreateParkingCellAsync(parkingCell, adminName, adminPassword);
                if (newParkingCell == null) return NotFound();
                return Ok(newParkingCell);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("Credenciales de administrador no válidas.");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict($"{parkingCell.Location} ya existe la celda de parqueo.");
                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<ParkingCell>> EditParkingCellAsync([FromBody] ParkingCell parkingCell, [FromQuery] string adminName, [FromQuery] string adminPassword)
        {
            try
            {
                var editedParkingCell = await _parkingCellService.EditParkingCellAsync(parkingCell, adminName, adminPassword);
                if (editedParkingCell == null) return NotFound();
                return Ok(editedParkingCell);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("Credenciales de administrador no válidas.");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict($"{parkingCell.Location} ya existe la celda de parqueo.");
                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<ParkingCell>> DeleteParkingCellAsync([FromQuery] Guid Id, [FromQuery] string adminName, [FromQuery] string adminPassword)
        {
            try
            {
                var deletedParkingCell = await _parkingCellService.DeleteParkingCellAsync(Id, adminName, adminPassword);
                if (deletedParkingCell == null) return NotFound();
                return Ok(deletedParkingCell);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("Credenciales de administrador no válidas.");
            }
        }
    }
}

