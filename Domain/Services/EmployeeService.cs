using Microsoft.EntityFrameworkCore;
using ParkTogether.DAL;
using ParkTogether.DAL.Entities;
using ParkTogether.Domain.Interfaces;

namespace ParkTogether.Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DateBaseContext _context;

        public EmployeeService(DateBaseContext context)
        {
             _context = context;
        }
        public async Task<IEnumerable<Employee>> GetEmployeeAsync()
        {
            
            try
            {
                var employees = await _context.Employees.ToListAsync();
                return employees;

            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<Employee> GetEmployeeByIdAsync(Guid Id)
        {
            
            try
            {
                var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == Id);
                return employee;
            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
           
            try
            {
                employee.Id = Guid.NewGuid();
                employee.CreatedDate = DateTime.Now;

                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return employee;

            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message );
            }
        }

        public async Task<Employee> EditEmployeeAsync(Employee employee)
        {
            try
            {
                employee.ModifiedDate = DateTime.Now;
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
                return employee;
            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<Employee> DeleteEmployeeAsync(Guid Id)
        {
            try
            {
                var employee = await GetEmployeeByIdAsync(Id);
                if (employee == null) 
                {
                    return null;
                }
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return employee;
            }
            catch (DbUpdateConcurrencyException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}
