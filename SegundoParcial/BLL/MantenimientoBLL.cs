﻿using System;
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

            Vehiculos vehiculos = new Vehiculos();
            try                
            {
                if (contexto.Mantenimiento.Add(mantenimiento) != null)
                {
                    foreach (var item in mantenimiento.Detalle)
                    {
                        contexto.Vehiculo.Find(item.ArticuloId).Inventario += item.Cantidad;
                    }

                    contexto.Articulos.Find(mantenimiento.VehiculoId).Totalmantenimiento += mantenimiento.Total;
                        
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
                var Mantenimiento = BLL.MantenimientoBLL.Buscar(mantenimiento.MantenimientoId);

                if(Mantenimiento != null)
                {
                    foreach (var item in mantenimiento.Detalle)
                    {
                        contexto.Articulos.Find(item.ArticuloId).Inventario += item.Cantidad;

                        if(!mantenimiento.Detalle.ToList().Exists(x => x.Id== item.Id))
                        {
                            item.Articulo = null;
                            contexto.Entry(item).State = EntityState.Deleted;
                                
                        }
                    }

                    foreach(var item in mantenimiento.Detalle)
                    {
                        contexto.Articulos.Find(item.ArticuloId).Inventario -= item.Cantidad;

                        var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                        contexto.Entry(item).State = estado;
                    }

                    Mantenimiento anterior = BLL.MantenimientoBLL.Buscar(mantenimiento.MantenimientoId);

                    //Identifica la direncia sumada o restada
                    decimal diferencia;

                    diferencia = mantenimiento.Total - anterior.Total;

                    //aplica diferencia al inventario
                    Vehiculos vehiculos = BLL.VehiculosBLL.Buscar(mantenimiento.VehiculoId);
                    vehiculos.TotalMantenimiento += diferencia;
                    BLL.VehiculosBLL.Modificar(vehiculos);

                    contexto.Entry(mantenimiento).State = EntityState.Modified;

                }
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
            return Convert.ToDecimal(precio) * Convert.ToInt32(Cantidad);
        }

        public static decimal SubTotal(decimal importe)
        {
            return importe;
        }

        public static decimal Total(decimal Subtotal, decimal ITBIS)
        {
            return Convert.ToDecimal(Subtotal) + Convert.ToDecimal(ITBIS);
        }
    }
}
