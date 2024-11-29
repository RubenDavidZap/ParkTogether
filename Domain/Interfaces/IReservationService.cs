using ParkTogether.DAL.Entities;

namespace ParkTogether.Domain.Interfaces
{
    public interface IReservationService
    {
        Task<IEnumerable<Reservation>> GetReservationAsync();

        Task<Reservation> CreateReservationAsync(Reservation reservation);

        Task<Reservation> GetReservationByIdAsync(Guid Id);

        Task<Reservation> EditReservationAsync(Reservation reservation);

        Task<Reservation> DeleteReservationAsync(Guid Id);
    }
}
