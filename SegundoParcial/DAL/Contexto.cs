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
        public DbSet<Mantenimiento> Mantenimiento { get; set; }
        public DbSet<Talleres> Talleres { get; set; }
        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<rEntradaArt> rEntradaArts { get; set; }

        public Contexto() : base("ConStr")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
