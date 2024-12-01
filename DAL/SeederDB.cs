using Microsoft.AspNetCore.Authorization.Infrastructure;
using ParkTogether.DAL.Entities;

namespace ParkTogether.DAL
{
    public class SeederDB
    {
        private readonly DateBaseContext _context;

        public SeederDB(DateBaseContext context)
        {
            _context = context;
        }
        public async Task SeederAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await PopulateEmployeesAsync();
            await PopulateAdministratorAsync();

            await _context.SaveChangesAsync();
        }
        #region Private Methos
        private async Task PopulateEmployeesAsync()
        {
            if(!_context.Employees.Any())
            {
                _context.Employees.Add(new Employee
                {
                    CreatedDate = DateTime.Now,
                    Name = "Juan Carlos",
                    Mail = "juan1234@gmail.com"
                });
                _context.Employees.Add(new Employee
                {
                    CreatedDate = DateTime.Now,
                    Name = "Valentina",
                    Mail = "Val1234@gmail.com"
                });
            }
        }
        private async Task PopulateAdministratorAsync()
        {
            if (!_context.Administrators.Any())
            {
                _context.Administrators.Add(new Administrator
                {
                    CreatedDate = DateTime.Now,
                    Name = "Admin",
                    Mail = "Admin1234@gmail.com",
                    Password = "Pas159"
                });
                _context.Administrators.Add(new Administrator
                {
                    CreatedDate = DateTime.Now,
                    Name = "Admin2",
                    Mail = "Administrator1234@gmail.com",
                    Password = "Pas1"
                });
            }
        }
        #endregion
    }

}
