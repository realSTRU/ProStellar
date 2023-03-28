using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProStellar.Shared.Models
{
    public class Proyecto
    {
        [Key]
        public int ProyectoId { get; set; }
        public string Descripcion { get; set; }
    }
}
