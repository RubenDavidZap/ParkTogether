using Microsoft.EntityFrameworkCore;
using ParkTogether.DAL;
using ParkTogether.DAL.Entities;
using ParkTogether.Domain.Interfaces;

namespace ParkTogether.Domain.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly DateBaseContext _context;

        public VehicleService(DateBaseContext context)
        {
            _context = context;
        }
        public async Task<Vehicle> CreateVehicleAsync(Vehicle vehicle)
        {
            try
            {
                vehicle.Id = Guid.NewGuid();
                vehicle.CreatedDate = DateTime.Now;

                _context.Vehicles.Add(vehicle);
                await _context.SaveChangesAsync();
                return vehicle;

            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Vehicle> DeleteVehicleAsync(Guid Id)
        {
            try
            {
                var vehicle = await GetVehicleByIdAsync(Id);
                if (vehicle == null)
                {
                    return null;
                }
                _context.Vehicles.Remove(vehicle);
                await _context.SaveChangesAsync();
                return vehicle;
            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Vehicle> EditVehicleAsync(Vehicle vehicle)
        {
            try
            {
                vehicle.ModifiedDate = DateTime.Now;
                _context.Vehicles.Update(vehicle);
                await _context.SaveChangesAsync();
                return vehicle;
            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<IEnumerable<Vehicle>> GetVehicleAsync()
        {
            try
            {
                var vehicle = await _context.Vehicles.ToListAsync();
                return vehicle;

            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Vehicle> GetVehicleByIdAsync(Guid Id)
        {
            try
            {
                var vehicle = await _context.Vehicles.FirstOrDefaultAsync(x => x.Id == Id);
                return vehicle;
            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}
