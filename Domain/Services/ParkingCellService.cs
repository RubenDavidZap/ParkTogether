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
        public async Task<bool> ValidateAdministratorCredentialsAsync(string name, string password)
        {
            var admin = await _context.Administrators.FirstOrDefaultAsync(a => a.Name == name && a.Password == password);
            return admin != null;
        }
        public async Task<IEnumerable<ParkingCell>> GetParkingCellsAsync()
        {
            try
            {
                return await _context.ParkingCells.Include(x => x.Administrator).ToListAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<ParkingCell> GetParkingCellByIdAsync(Guid id)
        {
            try
            {
                return await _context.ParkingCells.Include(x => x.Administrator)
                                                  .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<ParkingCell> CreateParkingCellAsync(ParkingCell parkingCell, string adminName, string adminPassword)
        {
            if (!await ValidateAdministratorCredentialsAsync(adminName, adminPassword))
                throw new UnauthorizedAccessException("Nombre o contraseña del administrador incorrectos.");
            try
            {
                parkingCell.Id = Guid.NewGuid();
                parkingCell.CreatedDate = DateTime.Now;
                _context.ParkingCells.Add(parkingCell);
                await _context.SaveChangesAsync();
                return parkingCell;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<ParkingCell> EditParkingCellAsync(ParkingCell parkingCell, string adminName, string adminPassword)
        {
            if (!await ValidateAdministratorCredentialsAsync(adminName, adminPassword))
                throw new UnauthorizedAccessException("Nombre o contraseña del administrador incorrectos.");
            try
            {
                parkingCell.ModifiedDate = DateTime.Now;
                _context.ParkingCells.Update(parkingCell);
                await _context.SaveChangesAsync();
                return parkingCell;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<ParkingCell> DeleteParkingCellAsync(Guid id, string adminName, string adminPassword)
        {
            if (!await ValidateAdministratorCredentialsAsync(adminName, adminPassword))
                throw new UnauthorizedAccessException("Nombre o contraseña del administrador incorrectos.");
            try
            {
                var parkingCell = await GetParkingCellByIdAsync(id);
                if (parkingCell == null) return null;

                _context.ParkingCells.Remove(parkingCell);
                await _context.SaveChangesAsync();
                return parkingCell;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
