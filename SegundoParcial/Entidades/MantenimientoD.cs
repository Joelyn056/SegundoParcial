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
        public int ArticuloId { get; set; }        
        public int TallerId { get; set; }
        public string Articulo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }

        [ForeignKey("VehiculoId")]
        public virtual Vehiculos Vehiculos { get; set; }

        [ForeignKey("ArticuloId")]
        public virtual Articulos Articulos { get; set; }

        [ForeignKey("TallerId")]
        public virtual Talleres Talleres { get; set; }

        public MantenimientoD()
        {
            this.Id = 0;
            this.MantenimientoId = 0;
            this.ArticuloId = 0;
            this.TallerId = 0;
            this.VehiculoId = 0;
            this.Articulo = string.Empty;
            this.Cantidad = 0;
            this.Precio = 0;
            this.Importe = 0;
        }

        public MantenimientoD(int id, int mantenimientoId, int vehiculoId, int articuloId, int tallerId,string articulo, int cantidad, decimal precio, decimal importe)
        {
            Id = id;
            MantenimientoId = mantenimientoId;
            VehiculoId = vehiculoId;
            ArticuloId = articuloId;
            Articulo = articulo;
            TallerId = tallerId;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
        }

    }
}
