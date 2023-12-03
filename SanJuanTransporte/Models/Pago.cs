using SanJuanTransporte.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SanJuanTransporte.Models
{
    public class Pago
    {
        [Key]
        public string? Id { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }
        public uint? Numero { get; set; }
        [Required]
        public string? Detalle { get; set; }
        [Required]
        public decimal Monto { get; set; }

        // RELACIONES, foreign key
        //?= puede tener o no pagos
        public int ConductorId{ get; set; }
        public virtual Conductor? Conductor { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario? Usuario { get; set; }

    }
}
