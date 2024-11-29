using ParkTogether.DAL.Entities;

namespace ParkTogether.Domain.Interfaces
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> GetVehicleAsync();

        Task<Vehicle> CreateVehicleAsync(Vehicle vehicle);

        Task<Vehicle> GetVehicleByIdAsync(Guid Id);

        Task<Vehicle> EditVehicleAsync(Vehicle vehicle);

        Task<Vehicle> DeleteVehicleAsync(Guid Id);
    }
}
