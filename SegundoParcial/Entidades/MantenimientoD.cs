using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;


namespace SegundoParcial.Entidades
{
    public class MantenimientoD
    {
        [Key]

        public int Id { get; set; }
        public int MantenimientoId { get; set; }
        public int VehiculoId { get; set; }
        public DateTime Fecha { get; set; }
        public int ProxiMantenimiento { get; set; }
        public string Vehiculo { get; set; }
        public int Taller { get; set; }

        [ForeignKey("VehiculoId")]
        public virtual Vehiculos Vehiculos { get; set; }


        public MantenimientoD()
        {
            Id = 0;
            MantenimientoId = 0;
        }

        public MantenimientoD(int id, int mantenimientoId, string vehiculo, int proxiMantenimiento, int taller)
        {
            Id = id;
            MantenimientoId = mantenimientoId;
            Vehiculo = vehiculo;
            ProxiMantenimiento = proxiMantenimiento;
            Taller = taller;
        
        }
    }
}
