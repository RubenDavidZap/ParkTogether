using System.ComponentModel.DataAnnotations;

namespace ParkTogether.DAL.Entities
{
    public class Administrator : AuditBase
    {
        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El Campo {0} excede el limite de caracteres")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Correo")]
        [Required]
        public string Mail { get; set; }


    }
}
