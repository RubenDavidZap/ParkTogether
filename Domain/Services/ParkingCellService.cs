﻿using Microsoft.EntityFrameworkCore;
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
        public async Task<ParkingCell> CreateParkingCellAsync(ParkingCell parkingcell)
        {

            try
            {
                parkingcell.Id = Guid.NewGuid();
                parkingcell.CreatedDate = DateTime.Now;

                _context.ParkingCells.Add(parkingcell);
                await _context.SaveChangesAsync();
                return parkingcell;

            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<ParkingCell> EditParkingCellAsync(ParkingCell parkingcell)
        {
            try
            {
                parkingcell.ModifiedDate = DateTime.Now;
                _context.ParkingCells.Update(parkingcell);
                await _context.SaveChangesAsync();
                return parkingcell;
            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<ParkingCell> DeleteParkingCellAsync(Guid Id)
        {
            try
            {
                var ParkingCell = await GetParkingCellByIdAsync(Id);
                if (ParkingCell == null)
                {
                    return null;
                }
                _context.ParkingCells.Remove(ParkingCell);
                await _context.SaveChangesAsync();
                return ParkingCell;
            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

    }
}