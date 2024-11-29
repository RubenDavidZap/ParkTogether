using Microsoft.AspNetCore.Mvc;
using ParkTogether.DAL.Entities;
using ParkTogether.Domain.Interfaces;
using ParkTogether.DTOs;

namespace ParkTogether.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingCellsController : ControllerBase
    {
        private readonly IParkingCellService _parkingCellService;

        public ParkingCellsController(IParkingCellService parkingCellService)
        {
            _parkingCellService = parkingCellService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<ParkingCell>>> GetParkingCellsAsync()
        {
            var parkingCells = await _parkingCellService.GetParkingCellsAsync();
            if (parkingCells == null || !parkingCells.Any()) return NotFound();

            return Ok(parkingCells);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult<ParkingCell>> GetParkingCellByIdAsync(Guid id)
        {
            try
            {
                var parkingCell = await _parkingCellService.GetParkingCellByIdAsync(id);
                if (parkingCell == null) return NotFound();

                return Ok(parkingCell);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<ParkingCell>> CreateParkingCellAsync([FromBody] ParkingCellRequest request)
        {
            try
            {
                var newParkingCell = await _parkingCellService.CreateParkingCellAsync(
                    request.ParkingCell,
                    request.AdminName,
                    request.AdminPassword);

                return Ok(newParkingCell);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<ActionResult<ParkingCell>> EditParkingCellAsync([FromBody] ParkingCellRequest request)
        {
            try
            {
                // Verificamos si los datos requeridos están presentes
                if (request == null || request.ParkingCell == null || string.IsNullOrEmpty(request.AdminName) || string.IsNullOrEmpty(request.AdminPassword))
                {
                    return BadRequest("La solicitud no es válida. Se requieren los datos de la celda y las credenciales del administrador.");
                }

                // Llamamos al servicio para editar la celda
                var updatedParkingCell = await _parkingCellService.EditParkingCellAsync(
                    request.ParkingCell,
                    request.AdminName,
                    request.AdminPassword
                );

                if (updatedParkingCell == null) return NotFound("La celda de parqueo no fue encontrada.");

                return Ok(updatedParkingCell);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult<ParkingCell>> DeleteParkingCellAsync(Guid id, [FromHeader] string adminName, [FromHeader] string adminPassword)
        {
            try
            {
                // Validamos los parámetros
                if (id == Guid.Empty || string.IsNullOrEmpty(adminName) || string.IsNullOrEmpty(adminPassword))
                {
                    return BadRequest("La solicitud no es válida. Se requiere el ID de la celda y las credenciales del administrador.");
                }

                // Llamamos al servicio para eliminar la celda
                var deletedParkingCell = await _parkingCellService.DeleteParkingCellAsync(id, adminName, adminPassword);

                if (deletedParkingCell == null) return NotFound("La celda de parqueo no fue encontrada.");

                return Ok(deletedParkingCell);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }
    }
}
