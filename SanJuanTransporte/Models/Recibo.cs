using System;
using System.ComponentModel.DataAnnotations;

namespace SanJuanTransporte.Models
{
    public class Recibo
    {
        [Key]
        public int ReciboId { get; set; }

        [Required(ErrorMessage = "El campo Número de Recibo es obligatorio.")]
        public string? NumeroRecibo { get; set; }

        [Required(ErrorMessage = "El campo Detalles de Pago es obligatorio.")]
        public string? DetallesPago { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Emisión es obligatorio.")]
        [DataType(DataType.Date)]
        public DateTime FechaEmision { get; set; }

        public int PagoId { get; set; }
        public virtual Pago? Pago { get; set; }
    }
}
