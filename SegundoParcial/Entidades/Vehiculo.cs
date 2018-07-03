using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SegundoParcial.Entidades
{
    public class Vehiculo
    {
        [Key]

        public int VehiculoId { get; set; }
        public string Descripcion { get; set; }
        public string Taller { get; set; }
        public string Vehiculop { get; set; }
        public string ProxiManteniento { get; set; }

        public Vehiculo()
        {
            VehiculoId = 0;
            Descripcion = string.Empty;
            Taller = string.Empty;

        }

        public override string ToString()
        {
            return this.Descripcion;
        }

    }
}
