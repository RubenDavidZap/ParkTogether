using Microsoft.EntityFrameworkCore;
using ParkTogether.DAL.Entities;

namespace ParkTogether.DAL
{
    public class DateBaseContext : DbContext
    {
        public DateBaseContext(DbContextOptions<DateBaseContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Administrator>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Administrator>().HasIndex(c => c.Mail).IsUnique();
            modelBuilder.Entity<Employee>().HasIndex(c => c.Mail).IsUnique();
            modelBuilder.Entity<Employee>().HasIndex(c => c.Name).IsUnique();
        }
        #region Dbsets
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ParkingCell> ParkingCells { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        #endregion
    }
}
