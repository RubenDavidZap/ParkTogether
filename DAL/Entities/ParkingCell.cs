using System.ComponentModel.DataAnnotations;
namespace ParkTogether.DAL.Entities
{
    public class ParkingCell : AuditBase
    {
        [Display(Name = "Ubicacion")]
        [MaxLength(50, ErrorMessage = "El Campo {0} excede el limite de caracteres")]
        [Required]
        public string Location { get; set; }

        [Display(Name = "Estado")]
        [Required]
        public bool Status { get; set; }

        [Display(Name = "Administrador")]
        [MaxLength(50, ErrorMessage = "El Campo {0} excede el limite de caracteres")]
        public Administrator? Administrator { get; set; }

        [Display(Name = "Id Administrador")]
        public Guid AdministratorId { get; set; }

        public ICollection<Reservation>? Reservations { get; set; }
    }
}
