using ParkTogether.DAL.Entities;

namespace ParkTogether.Domain.Interfaces
{
    public interface IGuestService
    {
        Task<IEnumerable<Guest>> GetGuestAsync();

        Task<Guest> CreateGuestAsync(Guest guest);

        Task<Guest> GetGuestByIdAsync(Guid Id);

        Task<Guest> EditGuestAsync(Guest Guest);

        Task<Guest> DeleteGuestAsync(Guid Id);
    }
}
