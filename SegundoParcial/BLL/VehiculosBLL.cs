using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SegundoParcial.DAL;
using SegundoParcial.Entidades;
using SegundoParcial.DAL;
using System.Data.Entity;

namespace SegundoParcial.BLL
{
    public class VehiculosBLL
    {
        public static bool Guardar(Vehiculos vehiculos)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Vehiculos.Add(vehiculos) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }

                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Modificar(Vehiculos vehiculos)
        {

            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(vehiculos).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }

                contexto.Dispose();

            }

            catch (Exception)
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

                Vehiculos vehiculos = contexto.Vehiculos.Find(id);
                contexto.Vehiculos.Remove(vehiculos);
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }

                contexto.Dispose();
            }

            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public static Vehiculos Buscar(int id)
        {

            Vehiculos articulo = new vehiculos();
            Contexto contexto = new Contexto();

            try
            {
                articulo = contexto.Vehiculos.Find(id);
                contexto.Dispose();

            }

            catch (Exception)
            {
                throw;
            }

            return articulo;
        }

        public static List<Vehiculos> GetList(Expression<Func<Vehiculos, bool>> expression)
        {

            List<Vehiculos> Vehiculos = new List<Vehiculos>();
            Contexto contexto = new Contexto();

            try
            {
                Vehiculos = contexto.Vehiculos.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return Vehiculos;
        }
    }
}

