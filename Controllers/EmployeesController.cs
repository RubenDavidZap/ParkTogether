using Microsoft.AspNetCore.Mvc;
using ParkTogether.DAL.Entities;
using ParkTogether.Domain.Interfaces;
using ParkTogether.Domain.Services;

namespace ParkTogether.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;


        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;

        }
        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeAsync()
        {
            var employees = await _employeeService.GetEmployeeAsync();

            if (employees == null || !employees.Any()) return NotFound();

            return Ok(employees);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{Id}")]
        public async Task<ActionResult<Employee>> GetEmployeeByIdAsync(Guid Id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(Id);

            if (employee == null) return NotFound();

            return Ok(employee);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Employee>> CreateEmployeeAsync([FromBody] Employee employee, [FromQuery] string adminName, [FromQuery] string adminPassword)
        {
            try
            {
                var newEmployee = await _employeeService.CreateEmployeeAsync(employee, adminName, adminPassword);
                if (newEmployee == null) return NotFound();
                return Ok(newEmployee);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("Credenciales de administrador no válidas.");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict($"{employee.Name} ya existe el empleado.");
                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Employee>> EditEmployeeAsync([FromBody] Employee employee, [FromQuery] string adminName, [FromQuery] string adminPassword)
        {
            try
            {
                var editedEmployee = await _employeeService.EditEmployeeAsync(employee, adminName, adminPassword);
                if (editedEmployee == null) return NotFound();
                return Ok(editedEmployee);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("Credenciales de administrador no válidas.");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict($"{employee.Name} ya existe el empleado.");
                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Employee>> DeleteEmployeeAsync([FromQuery] Guid Id, [FromQuery] string adminName, [FromQuery] string adminPassword)
        {
            try
            {
                var deletedEmployee = await _employeeService.DeleteEmployeeAsync(Id, adminName, adminPassword);
                if (deletedEmployee == null) return NotFound();
                return Ok(deletedEmployee);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("Credenciales de administrador no válidas.");
            }
        }
    }
}
