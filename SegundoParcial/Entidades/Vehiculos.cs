﻿using System;
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
        public int Mantenimiento { get; set; }
        public string Descripcion { get; set; }
      
            
        public Vehiculos()
        {
            VehiculoId = 0;
            Mantenimiento = 0;
            Descripcion = string.Empty;           
            
        }
    }
}