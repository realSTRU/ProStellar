using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProStellar.Shared.Models
{
    public class Nomina
    {
        [Key]
        public int NominaId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Concepto { get; set; }
        public int ProyectoId { get; set; }
        public int EstadoId { get; set; }
        public double Balance { get; set; }

        [ForeignKey("NominaId")]
        public List<NominaDetalle> Detalles { get; set; } = new List<NominaDetalle>();
    }

    public class NominaDetalle
    {
        [Key]
        public int NominaDetalleId { get; set; }
        public int NominaId { get; set; }
        public int PersonaId { get; set; }
        public int TrabajoId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int CantidadId { get; set; }
        public double Precio { get; set; }
        public double Balance { get; set; }


    }
}
