using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SegundoParcial.Entidades;
using SegundoParcial.DAL;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SegundoParcial.BLL
{
    public class ArticulosBLL
    {
        public static bool Guardar(Articulos articulos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if(contexto.Articulos.Add(articulos) != null)
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

        public static bool Modificar(Articulos articulos)
        {
            bool paso = true;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(articulos).State = EntityState.Modified;
                if(contexto.SaveChanges() > 0)
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

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                Articulos articulos = contexto.Articulos.Find(id);

                if(articulos != null)
                {
                    contexto.Entry(articulos).State = EntityState.Deleted;
                }

                if(contexto.SaveChanges() > 0)
                {
                    paso = true;
                    contexto.Dispose();
                }
                
            }

            catch(Exception)
            {
                throw;
            }

            return paso;
        }

        public static Articulos Buscar(int id)
        {
            Articulos articulos = new Articulos();
            Contexto contexto = new Contexto();
            try
            {
                articulos = contexto.Articulos.Find(id);
                contexto.Dispose();
            }

            catch(Exception)
            {
                throw;
            }

            return articulos;
        }

        public static List<Articulos> GetList(Expression<Func<Articulos, bool>> expression)
        {

            List<Articulos> articulos = new List<Articulos>();
            Contexto contexto = new Contexto();

            try
            {
                articulos = contexto.Articulos.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return articulos;
        }

        
        public static decimal CalcularCosto(decimal Ganancia, decimal Precio)
        {
            Ganancia /= 100;

            return Convert.ToDecimal(Precio) * Convert.ToDecimal(Ganancia);
        }

        public static decimal CalcularGanancia(decimal Costo, decimal Precio)
        {
            Precio -= Costo;
            return (Convert.ToDecimal(Precio) / Convert.ToDecimal(Costo)) * 100;
        }

        public static decimal CalcularPrecio(decimal Costo, decimal Ganancia)
        {
            Ganancia /= 100;
            Ganancia *= Costo;
            return Convert.ToDecimal(Costo) + Convert.ToDecimal(Ganancia);

        }

        public static Decimal CalcularImporte(decimal cantidad, decimal precio)
        {
            return cantidad * precio;
        }

        public static Decimal CalcularSubtotal(decimal importe)
        {
            return importe;
        }

        public static Decimal CalcularItbis(decimal subtotal)
        {
            return subtotal * (decimal) 0.18;
        }

        public static Decimal CalcularTotal(decimal subtotal, decimal itbis)
        {
            return subtotal + itbis;
        }

        public static string RetornarDescripcion(string nombre)
        {
            string descripcion = string.Empty;
            var lista = GetList(x => x.Descripcion.Equals(nombre));
            foreach (var item in lista)
            {
                descripcion = item.Descripcion;
            }
            return descripcion;
        }
    }
}
