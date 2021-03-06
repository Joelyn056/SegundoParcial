﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SegundoParcial.DAL;
using SegundoParcial.Entidades;
using System.Linq.Expressions;
using System.Data.Entity;

namespace SegundoParcial.BLL
{
    public class rEntradaArtBLL
    {
        public static bool Guardar(rEntradaArt rEntradaArt)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if(contexto.rEntradaArts.Add(rEntradaArt) != null)
                {
                    Articulos articulos = BLL.ArticulosBLL.Buscar(rEntradaArt.ArticuloId);
                    articulos.Inventario += rEntradaArt.Cantidad;
                    BLL.ArticulosBLL.Modificar(articulos);

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

        public static bool Modificar(rEntradaArt rEntradaArt)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                rEntradaArt art = BLL.rEntradaArtBLL.Buscar(rEntradaArt.EntradaId);
                int resta;
                resta = rEntradaArt.Cantidad - art.Cantidad;

                Articulos articulos = BLL.ArticulosBLL.Buscar(rEntradaArt.ArticuloId);
                articulos.Inventario += resta;
                BLL.ArticulosBLL.Modificar(articulos);

                contexto.Entry(rEntradaArt).State = EntityState.Modified;

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
            bool paso = true;
            Contexto contexto = new Contexto();
            try
            {
                rEntradaArt rEntradaArt = contexto.rEntradaArts.Find(id);

                if(rEntradaArt !=null)
                {
                    Articulos articulos = BLL.ArticulosBLL.Buscar(rEntradaArt.EntradaId);
                    articulos.Inventario -= rEntradaArt.Cantidad;
                    BLL.ArticulosBLL.Modificar(articulos);

                    contexto.Entry(rEntradaArt).State = EntityState.Deleted;
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

        public static rEntradaArt Buscar(int id)
        {
            rEntradaArt rEntradaArt = new rEntradaArt();
            Contexto contexto = new Contexto();
            try
            {
                rEntradaArt = contexto.rEntradaArts.Find(id);
                contexto.Dispose();
            }
            catch(Exception)
            {
                throw;
            }
            return rEntradaArt;
        }

        public static List<rEntradaArt> GetList(Expression<Func<rEntradaArt, bool>> expression)
        {
            List<rEntradaArt> rEntradaArt = new List<rEntradaArt>();
            Contexto contexto = new Contexto();

            try
            {
                rEntradaArt = contexto.rEntradaArts.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return rEntradaArt;
        }
    }
}
