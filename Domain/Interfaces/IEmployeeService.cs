using ParkTogether.DAL.Entities;
using System.Collections;

namespace ParkTogether.Domain.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployeeAsync();
        Task<Employee> CreateEmployeeAsync(Employee employee, string adminName, string adminPassword);
        Task<Employee> GetEmployeeByIdAsync(Guid Id);
        Task<Employee> EditEmployeeAsync(Employee employee, string adminName, string adminPassword);
        Task<Employee> DeleteEmployeeAsync(Guid Id, string adminName, string adminPassword);
    }
}
