using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProStellar.Shared.Models
{
    public class Cantidad
    {
        [Key]
        public int CantidadId { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public double Valor { get; set; }
    }
}
