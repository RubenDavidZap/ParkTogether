using Microsoft.AspNetCore.Mvc;
using ParkTogether.DAL.Entities;
using ParkTogether.Domain.Interfaces;

namespace ParkTogether.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController:Controller
    {
        private readonly IGuestService _GuestService;


        public GuestController(IGuestService guestService)
        {
            _GuestService = guestService;

        }
        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Guest>>> GetGuestAsync()
        {
            var guest = await _GuestService.GetGuestAsync();

            if (guest == null || !guest.Any()) return NotFound();

            return Ok(guest);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{Id}")]
        public async Task<ActionResult<Guest>> GetGuestByIdAsync(Guid Id)
        {
            var guest = await _GuestService.GetGuestByIdAsync(Id);

            if (guest == null) return NotFound();

            return Ok(guest);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Guest>> CreateGuestAsync(Guest guest)
        {
            try
            {
                var newGuest = await _GuestService.CreateGuestAsync(guest);
                if (newGuest == null) return NotFound();
                return Ok(newGuest);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe el Invitado", guest.Name));
                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Guest>> EditGuestAsync(Guest guest)
        {
            try
            {
                var editedGuest = await _GuestService.EditGuestAsync(guest);
                if (editedGuest == null) return NotFound();
                return Ok(editedGuest);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", guest.Name));
                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete ")]
        public async Task<ActionResult<Guest>> DeleteGuestAsync(Guid Id)
        {
            if (Id == null) return BadRequest();
            var deletedGuest = await _GuestService.DeleteGuestAsync(Id);
            if (deletedGuest == null) return NotFound();
            return Ok(deletedGuest);
        }
    }
}
