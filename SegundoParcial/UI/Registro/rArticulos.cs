using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SegundoParcial.Entidades;

namespace SegundoParcial.UI.Registro
{
    public partial class rArticulos : Form
    {
        public rArticulos()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            //GeneralErrorProvider.Clear();

            //if (Validar(1))
            //{
            //    MessageBox.Show("Ingrese el ID");
            //    return;
            //}

            int id = Convert.ToInt32(ArticuloIDNumericUpDown.Value);
            Articulos articulos = BLL.ArticulosBLL.Buscar(id);

            if (articulos != null)
            {
                ArticuloIDNumericUpDown.Value = articulos.ArticuloId;
                DescripcionTextBox.Text = articulos.Descripcion;
                CostoNumericUpDown.Value = articulos.Costo;
                PrecioNumericUpDown.Value = articulos.Precio;
                GananciaNumericUpDown.Value = articulos.Ganancia;
                InventarioNumericUpDown.Value = articulos.Inventario;
            }
            else
                MessageBox.Show("no se encontro", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            ArticuloIDNumericUpDown.Value = 0;
            DescripcionTextBox.Clear();
            CostoNumericUpDown.Value = 0;
            PrecioNumericUpDown.Value = 0;
            GananciaNumericUpDown.Value = 0;
            InventarioNumericUpDown.Value = 0;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Articulos articulos = new Articulos();
            if (Validar())
            {
                MessageBox.Show("Llenar todos los campos marcados");
                return;
            }
            GeneralErrorProvider.Clear();
            articulos = LlenarClase();

            if (ArticuloIDNumericUpDown.Value == 0)
                paso = BLL.ArticulosBLL.Guardar(articulos);
            else
                paso = BLL.ArticulosBLL.Modificar(articulos);

            if (paso)
                MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            //GeneralErrorProvider.Clear();

            //if (Validar())
            //{
            //    MessageBox.Show("Ingrese un ID");
            //    return;
            //}

            int id = Convert.ToInt32(ArticuloIDNumericUpDown.Value);

            if (BLL.ArticulosBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("no se pudo guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private Articulos LlenarClase()
        {
            Articulos articulos = new Articulos();

            articulos.ArticuloId = Convert.ToInt32(ArticuloIDNumericUpDown.Value);
            articulos.Descripcion = DescripcionTextBox.Text;
            articulos.Costo = Convert.ToInt32(CostoNumericUpDown.Value);
            articulos.Precio = Convert.ToInt32(PrecioNumericUpDown.Value);
            articulos.Ganancia = Convert.ToInt32(GananciaNumericUpDown.Value);
            articulos.Inventario = Convert.ToInt32(InventarioNumericUpDown.Value);

            return articulos;
        }

        private bool Validar()
        {
            bool Validar = false;
            
            if (string.IsNullOrWhiteSpace(DescripcionTextBox.Text))
            {
                GeneralErrorProvider.SetError(DescripcionTextBox, "Ingrese una descripcion");
                Validar = true;
            }

            if (CostoNumericUpDown.Value == 0)
            {

                GeneralErrorProvider.SetError(CostoNumericUpDown, "Ingrese el Costo");
                Validar = true;
            }
            if(PrecioNumericUpDown.Value == 0)
            {
                GeneralErrorProvider.SetError(PrecioNumericUpDown, "Ingrese el precio");
                Validar = true;
            }
            if (GananciaNumericUpDown.Value == 0)
            {
                GeneralErrorProvider.SetError(GananciaNumericUpDown, "Ganancia ");
                Validar = true;
            }
           

            return Validar;

        }
    }
}
