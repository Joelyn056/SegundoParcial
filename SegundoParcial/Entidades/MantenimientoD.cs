using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SegundoParcial.Entidades
{
    public class MantenimientoD
    {
        [Key]

        public int Id { get; set; }
        public int MantenimientoId { get; set; }
        public int VehiculoId { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public int Importe { get; set; }

        [ForeignKey("MantenimientoId")]
        public virtual Mantenimiento Mantenimiento { get; set; }

        [ForeignKey("VehiculoId")]
        public virtual Vehiculos Vehiculos { get; set; }


        public Mantenimiento_Detalle()
        {
            Id = 0;

        }

        public Mantenimiento_Detalle(int id, int mantenimientoId, int vehiculoId, int cantidad, int precio, int importe)
        {
            Id = id;
            MantenimientoId = mantenimientoId;
            VehiculoId = vehiculoId;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
        }
    }
}
