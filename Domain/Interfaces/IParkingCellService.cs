using ParkTogether.DAL.Entities;

namespace ParkTogether.Domain.Interfaces
{
    public interface IParkingCellService
    {
        Task<IEnumerable<ParkingCell>> GetParkingCellAsync();

        Task<ParkingCell> CreateParkingCellAsync(ParkingCell parkingCell, string adminName, string password);

        Task<ParkingCell> GetParkingCellByIdAsync(Guid Id);

        Task<ParkingCell> EditParkingCellAsync(ParkingCell parkingCell, string adminName, string password);

        Task<ParkingCell> DeleteParkingCellAsync(Guid Id, string adminName, string password);
    }

}

