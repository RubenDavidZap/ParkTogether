using Microsoft.AspNetCore.Mvc;
using ParkTogether.DAL.Entities;
using ParkTogether.Domain.Interfaces;
using ParkTogether.Domain.Services;

namespace ParkTogether.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController:Controller
    {
        private readonly IReservationService _reservationService;


        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;

        }
        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservationAsync()
        {
            var reservation = await _reservationService.GetReservationAsync();

            if (reservation == null || !reservation.Any()) return NotFound();

            return Ok(reservation);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{Id}")]
        public async Task<ActionResult<Reservation>> GetReservationByIdAsync(Guid Id)
        {
            var reservation = await _reservationService.GetReservationByIdAsync(Id);

            if (reservation == null) return NotFound();

            return Ok(reservation);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Reservation>> CreateReservationAsync(Reservation reservation)
        {
            try
            {
                var newReservation = await _reservationService.CreateReservationAsync(reservation);
                if (newReservation == null) return NotFound();
                return Ok(newReservation);
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
        public async Task<ActionResult<Reservation>> EditReservationAsync(Reservation reservation)
        {
            try
            {
                var editedReservation = await _reservationService.EditReservationAsync(reservation);
                if (editedReservation == null) return NotFound();
                return Ok(editedReservation);
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
        public async Task<ActionResult<Reservation>> DeleteReservationAsync(Guid Id)
        {
            if (Id == null) return BadRequest();
            var deletedReservation = await _reservationService.DeleteReservationAsync(Id);
            if (deletedReservation == null) return NotFound();
            return Ok(deletedReservation);
        }
    }
}
