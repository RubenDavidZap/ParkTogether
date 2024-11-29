using Microsoft.EntityFrameworkCore;
using ParkTogether.DAL;
using ParkTogether.DAL.Entities;
using ParkTogether.Domain.Interfaces;

namespace ParkTogether.Domain.Services
{
    public class ReservationService : IReservationService
    {
        private readonly DateBaseContext _context;

        public ReservationService(DateBaseContext context)
        {
            _context = context;
        }
        public async Task<Reservation> CreateReservationAsync(Reservation reservation)
        {
            try
            {
                reservation.Id = Guid.NewGuid();
                reservation.CreatedDate = DateTime.Now;

                _context.Reservations.Add(reservation);
                await _context.SaveChangesAsync();
                return reservation;

            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Reservation> DeleteReservationAsync(Guid Id)
        {
            try
            {
                var reservation = await GetReservationByIdAsync(Id);
                if (reservation == null)
                {
                    return null;
                }
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
                return reservation;
            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Reservation> EditReservationAsync(Reservation reservation)
        {
            try
            {
                reservation.ModifiedDate = DateTime.Now;
                _context.Reservations.Update(reservation);
                await _context.SaveChangesAsync();
                return reservation;
            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<IEnumerable<Reservation>> GetReservationAsync()
        {
            try
            {
                var reservation = await _context.Reservations.ToListAsync();
                return reservation;

            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Reservation> GetReservationByIdAsync(Guid Id)
        {
            try
            {
                var reservation = await _context.Reservations.FirstOrDefaultAsync(x => x.Id == Id);
                return reservation;
            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}
