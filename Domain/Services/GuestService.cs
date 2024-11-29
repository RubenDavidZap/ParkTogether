using Microsoft.EntityFrameworkCore;
using ParkTogether.DAL.Entities;
using ParkTogether.DAL;
using ParkTogether.Domain.Interfaces;

namespace ParkTogether.Domain.Services
{
    public class GuestService : IGuestService
    {
        private readonly DateBaseContext _context;

        public GuestService(DateBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Guest>> GetGuestAsync()
        {

            try
            {
                var Guest = await _context.Guests.ToListAsync();
                return Guest;

            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<Guest> GetGuestByIdAsync(Guid Id)
        {

            try
            {
                var Guest = await _context.Guests.FirstOrDefaultAsync(x => x.Id == Id);
                return Guest;
            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<Guest> CreateGuestAsync(Guest Guest)
        {

            try
            {
                Guest.Id = Guid.NewGuid();
                Guest.CreatedDate = DateTime.Now;

                _context.Guests.Add(Guest);
                await _context.SaveChangesAsync();
                return Guest;

            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Guest> EditGuestAsync(Guest Guest)
        {
            try
            {
                Guest.ModifiedDate = DateTime.Now;
                _context.Guests.Update(Guest);
                await _context.SaveChangesAsync();
                return Guest;
            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<Guest> DeleteGuestAsync(Guid Id)
        {
            try
            {
                var Guest = await GetGuestByIdAsync(Id);
                if (Guest == null)
                {
                    return null;
                }
                _context.Guests.Remove(Guest);
                await _context.SaveChangesAsync();
                return Guest;
            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}
