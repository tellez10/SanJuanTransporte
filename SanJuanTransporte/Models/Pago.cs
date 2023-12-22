using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SanJuanTransporte.Dtos;

namespace SanJuanTransporte.Models
{
    public class Pago
    {
        [Key]
        public int PagoId { get; set; }

        [Required]
        public decimal Monto { get; set; }

        [Required]
        public string? Detalle { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime FechaPago { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        public MesEnum Mes { get; set; }

        [Required]
        public int Anio { get; set; }

        public int ConductorId { get; set; }
        public virtual Conductor? Conductor { get; set; }

        public int UsuarioId { get; set; }
        public virtual Usuario? Usuario { get; set; }

    }
}
