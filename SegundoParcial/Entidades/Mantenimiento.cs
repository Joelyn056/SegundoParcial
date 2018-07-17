using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SegundoParcial.Entidades
{
    public class Mantenimiento
    {
        [Key]
        public int MantenimientoId { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime ProxiMantenimiento { get; set; }
        public int VehiculoId { get; set; }
        public int Taller { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Itbis { get; set; }
        public decimal Total { get; set; }
        

        public virtual ICollection<MantenimientoD> Detalle { get; set; }

        public Mantenimiento()
        {
            this.Detalle = new List<MantenimientoD>();

            MantenimientoId = 0;
            Fecha = DateTime.Now;
            ProxiMantenimiento = DateTime.Now;
            VehiculoId = 0;
            Subtotal = 0;
            Itbis = 0;
            Total = 0;
            Taller = 0;
        }

        public void AgregarDetalle(int id, int mantenimientoId, string vehiculo, DateTime proxiMantenimiento, int taller, int cantidad, decimal precio, decimal importe )
        {
            this.Detalle.Add(new MantenimientoD(id, mantenimientoId,vehiculo, proxiMantenimiento, taller, cantidad, precio, importe));
        }

    }
}
