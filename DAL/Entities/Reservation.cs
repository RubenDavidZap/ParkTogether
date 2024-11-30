using System.ComponentModel.DataAnnotations;

namespace ParkTogether.DAL.Entities
{
    public class Reservation : AuditBase
    {
        [Display(Name = "Fecha y Hora")]
        [Required]
        public DateTime Time { get; set; }

        [Display(Name = "Estado Reserva")]
        [Required]
        public bool Status { get; set; }

        public ParkingCell ParkingCell { get; set; }

        [Display(Name = "Id Celda")]
        public Guid ParkingCellId { get; set; }

        public Employee? Employee { get; set; }

        [Display(Name = "Id Empleado")]
        public Guid EmployeeId { get; set; }

        public Guest? Guest { get; set; }

        [Display(Name = "Id Invitado")]
        public Guid? GuestId { get; set; }

        public Vehicle? Vehicle { get; set; }

        [Display(Name = "Placa")]
        public Guid? VehicleId { get; set; }
    }
}
