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
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public string NombreArticulo { get; set; }

        public rEntradaArt()
        {
            EntradaId = 0;
            Fecha = DateTime.Now;
            ArticuloId = 0;
            Cantidad = 0;
            NombreArticulo = string.Empty;
        }

    }
}
