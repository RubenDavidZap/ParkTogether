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
            var ParkingCell = await _parkingCellService.GetParkingCellAsync();

            if (ParkingCell == null || !ParkingCell.Any()) return NotFound();

            return Ok(ParkingCell);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{Id}")]
        public async Task<ActionResult<ParkingCell>> GetParkingCellByIdAsync(Guid Id)
        {
            var ParkingCell = await _parkingCellService.GetParkingCellByIdAsync(Id);

            if (ParkingCell == null) return NotFound();

            return Ok(ParkingCell);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<ParkingCell>> CreateParkingCellAsync(ParkingCell parkingCell)
        {
            try
            {
                var newParkingCell = await _parkingCellService.CreateParkingCellAsync(parkingCell);
                if (newParkingCell == null) return NotFound();
                return Ok(newParkingCell);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe el parking"));
                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<ParkingCell>> EditParkingCellAsync(ParkingCell parkingCell)
        {
            try
            {
                var editedParkingCell = await _parkingCellService.EditParkingCellAsync(parkingCell);
                if (editedParkingCell == null) return NotFound();
                return Ok(editedParkingCell);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe el parking"));
                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete ")]
        public async Task<ActionResult<ParkingCell>> DeleteParkingCellAsync(Guid Id)
        {
            if (Id == null) return BadRequest();
            var deletedParkingCell = await _parkingCellService.DeleteParkingCellAsync(Id);
            if (deletedParkingCell == null) return NotFound();
            return Ok(deletedParkingCell);
        }

    }
}
