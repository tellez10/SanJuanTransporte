using SanJuanTransporte.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SanJuanTransporte.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? NombreCompleto { get; set; }
        public string? Foto { get; set; }
        [Required]
        public  RolEnum Rol { get; set; }
        // dolo de ayuda para cargar la foto
        [NotMapped]
        [Display(Name = "Cargar Foto")]
        public IFormFile? FotoFile { get; set; }// caragar la foto


    }
}
