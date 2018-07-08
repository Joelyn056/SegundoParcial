using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SegundoParcial.Entidades
{
    public class rEntradaArt
    {
        [Key]
        public int EntradaId { get; set; }
        public DateTime Fecha { get; set; }
        public int Articulo { get; set; }
        public int Cantidad { get; set; }

        public rEntradaArt()
        {
            EntradaId = 0;
            Fecha = Fecha;
            Articulo = 0;
            Cantidad = 0;
        }

    }
}
