using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SegundoParcial.Entidades
{
    public class Articulos
    {
        [Key]

        public int ArticuloId { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }
        public decimal Ganancia { get; set; }
        public decimal Inventario { get; set; }
       

        public Articulos()
        {
            ArticuloId = 0;
            Descripcion = string.Empty;
            Costo= 0;
            Precio = 0;
            Ganancia = 0;
            Inventario = 0;
        }

        public override string ToString()
        {
            return this.Descripcion;
        }
    }
}
