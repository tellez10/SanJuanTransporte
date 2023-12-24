using SanJuanTransporte.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SanJuanTransporte.Models
{
    public class Conductor
    {
        [Key]
        public int ConductorId { get; set; }
        [Required]
        public int CI { get; set; }
        [Required]
        public string? Direccion { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? NombreCompleto { get; set; }
        [Required]
        public int NumeroLicencia { get; set; }
        [Required]
        public string? NumeroPlaca { get; set; }
        public string? Foto { get; set; }// almacena la foto
        // dolo de ayuda para cargar la foto
        [NotMapped]
        [Display(Name="Cargar Foto")]
        public IFormFile? FotoFile { get; set; }// caragar la foto

        public virtual List<Pago>? Pagos { get; set; }
   
    }
}
