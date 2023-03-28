using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProStellar.Shared.Models
{
    public class TipoPago
    {
        [Key]
        public int TipoPagoId { get; set; }
        public string Descripcion { get; set; }
    }
}
