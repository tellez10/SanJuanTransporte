using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SanJuanTransporte.Models
{
    public class Conductor
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength (6), MaxLength(10)]
        public int CI { get; set; }
        [Required, MinLength(6), MaxLength(30)]
        public string? Direccion { get; set; }
        [Required, MinLength(6), MaxLength(10)]
        public string? Email { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string? NombreCompleto { get; set; }
        [Required]
        public int NumeroLicencia { get; set; }
        [Required]
        public string? NumeroPlaca { get; set; }
        public string? Foto { get; set; }// almacena la foto
        // dolo de ayuda para cargar la foto
        [NotMapped]
        [Display(Name="Cargar Foto")]
        public IFormFile? FotoFile { get; set; }// cargar la foto
        // RELACIONES
        public virtual List<Pago>? Pagos { get; set; }
    }
}
