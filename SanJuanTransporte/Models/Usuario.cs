using SanJuanTransporte.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SanJuanTransporte.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? NombreCompleto { get; set; }
       
        [Required]
        public  RolEnum Rol { get; set; }

        public virtual List<Pago>? Pagos { get; set; }


    }
}
