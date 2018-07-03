using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SegundoParcial.Entidades
{
    public class Mantenimiento
    {
        [Key]
        public int VehiculoId { get; set; }
        public string Descripcion { get; set; }
    }
}
