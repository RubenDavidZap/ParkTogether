using ParkTogether.DAL.Entities;
using System.Collections;

namespace ParkTogether.Domain.Interfaces
{
    public interface IParkingCellService
    {
        Task<IEnumerable<ParkingCell>> GetParkingCellsAsync();
        Task<ParkingCell> GetParkingCellByIdAsync(Guid id);
        Task<ParkingCell> CreateParkingCellAsync(ParkingCell parkingCell, string adminName, string adminPassword);
        Task<ParkingCell> EditParkingCellAsync(ParkingCell parkingCell, string adminName, string adminPassword);
        Task<ParkingCell> DeleteParkingCellAsync(Guid id, string adminName, string adminPassword);
    }
}
