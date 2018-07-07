using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SegundoParcial.Entidades;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SegundoParcial.DAL;
using System.Data.Entity;

namespace SegundoParcial.BLL
{
    public class MantenimientoBLL
    {
        public static bool Guardar(Mantenimiento mantenimiento)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if(contexto.Mantenimiento.Add(mantenimiento) !=null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();
            }
            catch(Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Modificar(Mantenimiento mantenimiento)
        {
            bool paso = true;
            Contexto contexto = new Contexto();
            try
            {
                foreach(var item in mantenimiento.Detalle)
                {
                    var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                    contexto.Entry(item).State = estado;

                    contexto.Entry(mantenimiento).State = EntityState.Modified;

                    if(contexto.SaveChanges()> 0)
                    {
                        paso = true;
                    }
                    contexto.Dispose();
                }    
            }
            catch(Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                Mantenimiento mantenimiento = contexto.Mantenimiento.Find(id);

                if (contexto.SaveChanges() >0)
                {
                    paso = true;
                }

                contexto.Dispose();
            }

            catch(Exception)
            {
                throw;
            }
            return paso;
        }

        public static Mantenimiento Buscar(int id)
        {

            Mantenimiento mantenimiento = new Mantenimiento();
            Contexto contexto = new Contexto();

            try
            {
                mantenimiento = contexto.Mantenimiento.Find(id);
                mantenimiento.Detalle.Count();

                foreach (var item in mantenimiento.Detalle)
                {
                    string s = item.Vehiculos.Descripcion;
                }
                contexto.Dispose();
            }

            catch (Exception)
            {
                throw;
            }

            return mantenimiento;
        }

        public static List<Mantenimiento> GetList(Expression<Func<Mantenimiento, bool>> expression)
        {

            List<Mantenimiento> Mantenimiento = new List<Mantenimiento>();
            Contexto contexto = new Contexto();
            try
            {
                Mantenimiento = contexto.Mantenimiento.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return Mantenimiento;
        }

        public static decimal CalcularImporte(decimal Cantidad, decimal precio)
        {
            return Cantidad * precio;
        }

        public static decimal SubTotal(decimal importe)
        {
            return importe;
        }

        public static decimal Total(decimal Subtotal)
        {
            return Subtotal * (Decimal)0.18;
        }
    }
}
