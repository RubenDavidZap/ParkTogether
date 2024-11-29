using ParkTogether.DAL.Entities;

namespace ParkTogether.Domain.Interfaces
{
    public interface IParkingCellService
    {
        Task<IEnumerable<ParkingCell>> GetParkingCellAsync();

        Task<ParkingCell> CreateParkingCellAsync(ParkingCell parkingCell);

        Task<ParkingCell> GetParkingCellByIdAsync(Guid Id);

        Task<ParkingCell> EditParkingCellAsync(ParkingCell parkingCell);

        Task<ParkingCell> DeleteParkingCellAsync(Guid Id);

    }
}
