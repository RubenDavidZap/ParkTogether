using System.ComponentModel.DataAnnotations;

namespace ParkTogether.DAL.Entities
{
    public class Vehicle : AuditBase
    {
        [Display(Name = "Marca")]
        [MaxLength(10, ErrorMessage = "El Campo {0} excede el limite de caracteres")]
        [Required]
        public string Mark { get; set; }

        [Display(Name = "Modelo")]
        [Required]
        public int Model { get; set; }
                
        public string Color { get; set; }

        public Employee? Employee { get; set; }

        [Display(Name = "Id Empleado")]
        public Guid? EmployeeId { get; set; }

        public Guest? Guest { get; set; }

        [Display(Name = "Id Invitado")]
        public Guid? GuestId { get; set; }

        public ICollection<Reservation>? Reservations { get; set; }

    }
}
