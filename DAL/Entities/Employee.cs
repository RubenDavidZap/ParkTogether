using System.ComponentModel.DataAnnotations;

namespace ParkTogether.DAL.Entities
{
    public class Employee : AuditBase
    {
        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El Campo {0} excede el limite de caracteres")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Correo")]
        [Required]
        public string Mail { get; set; }

        [Display(Name = "Area")]
        [MaxLength(50, ErrorMessage = "El Campo {0} excede el limite de caracteres")]
        public string Area { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
