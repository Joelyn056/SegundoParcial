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
        public string Vehiculo { get; set; }
        public int Taller { get; set; }
        

        public virtual ICollection<MantenimientoD> Detalle { get; set; }

        public Mantenimiento()
        {
            this.Detalle = new List<MantenimientoD>();
        }

        public void AgregarDetalle(int id, int mantenimientoId, string vehiculo, DateTime proxiMantenimiento, int taller, int cantidad, decimal precio, decimal importe )
        {
            this.Detalle.Add(new MantenimientoD(id, mantenimientoId,vehiculo, proxiMantenimiento, taller, cantidad, precio, importe));
        }
    }
}
