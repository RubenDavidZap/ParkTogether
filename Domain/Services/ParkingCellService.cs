using Microsoft.EntityFrameworkCore;
using ParkTogether.DAL;
using ParkTogether.DAL.Entities;
using ParkTogether.Domain.Interfaces;

namespace ParkTogether.Domain.Services
{
    public class ParkingCellService : IParkingCellService
    {
        private readonly DateBaseContext _context;

        public ParkingCellService(DateBaseContext context)
        {
            _context = context;
        }
        private async Task<bool> ValidateAdminAsync(string adminName, string adminPassword)
        {
            return await _context.Administrators.AnyAsync(a => a.Name == adminName && a.Password == adminPassword);
        }

        public async Task<IEnumerable<ParkingCell>> GetParkingCellAsync()
        {

            try
            {
                var ParkingCell = await _context.ParkingCells.ToListAsync();
                return ParkingCell;

            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<ParkingCell> GetParkingCellByIdAsync(Guid Id)
        {

            try
            {
                var ParkingCell = await _context.ParkingCells.FirstOrDefaultAsync(x => x.Id == Id);
                return ParkingCell;
            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<ParkingCell> CreateParkingCellAsync(ParkingCell parkingCell, string adminName, string adminPassword)
        {
    
            if (!await ValidateAdminAsync(adminName, adminPassword))
                throw new UnauthorizedAccessException("Credenciales de administrador no válidas.");

            try
            {
                parkingCell.Id = Guid.NewGuid();
                parkingCell.CreatedDate = DateTime.Now;
                parkingCell.Status = true;

                _context.ParkingCells.Add(parkingCell);
                await _context.SaveChangesAsync();
                return parkingCell;

            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<ParkingCell> EditParkingCellAsync(ParkingCell parkingCell, string adminName, string adminPassword)
        {
           
            if (!await ValidateAdminAsync(adminName, adminPassword))
                throw new UnauthorizedAccessException("Credenciales de administrador no válidas.");

            try
            {
                parkingCell.ModifiedDate = DateTime.Now;
                _context.ParkingCells.Update(parkingCell);
                await _context.SaveChangesAsync();
                return parkingCell;
            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<ParkingCell> DeleteParkingCellAsync(Guid Id, string adminName, string adminPassword)
        {
           
            if (!await ValidateAdminAsync(adminName, adminPassword))
                throw new UnauthorizedAccessException("Credenciales de administrador no válidas.");

            try
            {
                var parkingCell = await GetParkingCellByIdAsync(Id);
                if (parkingCell == null)
                    return null;  

                _context.ParkingCells.Remove(parkingCell);
                await _context.SaveChangesAsync();
                return parkingCell;
            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

    }
}