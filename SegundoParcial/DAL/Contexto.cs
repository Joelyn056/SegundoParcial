using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SegundoParcial.Entidades;

namespace SegundoParcial.DAL
{
    public class Contexto : DbContext
    {

        public DbSet<Vehiculos> Vehiculo { get; set; }

        public Contexto() : base("ConStr")
        {

        }

    }
}
