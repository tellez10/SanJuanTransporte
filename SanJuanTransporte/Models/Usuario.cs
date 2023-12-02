using SanJuanTransporte.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SanJuanTransporte.Models
{
    public class Usuario
    {
        [Key] //data notations
        public int Id { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string? Email { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string? Password { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string? NombreCompleto { get; set; }
        public string? Foto { get; set; }
        [Required]
        public  RolEnum Rol { get; set; }
        // dolo de ayuda para cargar la foto
        [NotMapped]
        [Display(Name = "Cargar Foto")]
        public IFormFile? FotoFile { get; set; }// caragar la foto
        // RELACIONES
        public virtual List<Pago>? Pagos { get; set; }


    }
}
