using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SegundoParcial.Entidades
{
    public class Vehiculos
    {
        [Key]

        public int VehiculoId { get; set; }
        public decimal TotalMantenimiento { get; set; }
        public string Descripcion { get; set; }
    

        public Vehiculos()
        {
           this.VehiculoId = 0;
           this.TotalMantenimiento = 0;
           this.Descripcion = string.Empty;           
            
        }
    }
}
