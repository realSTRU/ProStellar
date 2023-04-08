using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProStellar.Shared.Models
{
    public class Pago
    {
        [Key]
        public int PagoId { get; set; }
        public DateTime Fecha { get; set; }
        public int NominaId { get; set; }
        public double Monto { get; set; }
        public double Total { get; set; }

        [ForeignKey("PagoId")]
        public List<PagoDetalle> Detalles { get; set; } = new List<PagoDetalle>();
    }

    public class PagoDetalle
    {
        [Key]
        public int PagoDetalleId { get; set; }
        public int PagoId { get; }
        public int NominaDetalleId { get; set; }
        public int TipoPagoId { get; set; }
        public double ValorPagado { get; set; }
    }
}
