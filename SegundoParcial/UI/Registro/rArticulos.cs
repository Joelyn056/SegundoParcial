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

        private void Buscarbutton_Click(object sender, EventArgs e)
        {

            GeneralErrorProvider.Clear();

            if (Validar(1))
            {
                MessageBox.Show("Ingrese un ID");
                return;
            }

            int id = Convert.ToInt32(IdnumericUpDown.Value);
            Vehiculos vehiculos = BLL.VehiculosBLL.Buscar(id);

            if (vehiculos != null)
            {

                DescripciontextBox.Text = vehiculos.Descripcion;
                PrecionumericUpDown.Value = vehiculos.Precio;
                VencimientodateTimePicker.Text = vehiculos.FechaVencimiento.ToString();
                CantCottextBox.Text = vehiculos.CantidadCotizada.ToString();

            }
            else
                MessageBox.Show("No se encontro", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            IdnumericUpDown.Value = 0;
            DescripciontextBox.Clear();
            PrecionumericUpDown.Value = 0;
            CantCottextBox.Clear();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            if (Validar(2))
            {

                MessageBox.Show("Llenar todos los campos marcados");
                return;
            }

            GeneralErrorProvider.Clear();

            
            if (IdnumericUpDown.Value == 0)
                paso = BLL.VehiculosBLL.Guardar(LlenarClase());
            else
                paso = BLL.VehiculosBLL.Modificar(LlenarClase());

            
            if (paso)

                MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {

            GeneralErrorProvider.Clear();

            if (Validar(1))
            {
                MessageBox.Show("Ingrese un ID");
                return;
            }

            int id = Convert.ToInt32(IdnumericUpDown.Value);

            if (BLL.VehiculosBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private vehiculos LlenarClase()
        {

            vehiculos = new vehiculos();

            
        }

        private bool Validar(int validar)
        {

            bool paso = false;
            if (validar == 1 && IdnumericUpDown.Value == 0)
            {
                GeneralErrorProvider.SetError(IdnumericUpDown, "el mantenimiento ID");
                paso = true;

            }
            if (validar == 2 && DescripciontextBox.Text == string.Empty)
            {
                GeneralErrorProvider.SetError(DescripciontextBox, "Ingrese una descripcion");
                paso = true;
            }
            if (validar == 2 && PrecionumericUpDown.Value == 0)
            {

                GeneralErrorProvider.SetError(PrecionumericUpDown, "Ingrese el proximo mantenimiento");
                paso = true;
            }
            if (validar == 2 && CantCottextBox.Text == string.Empty)
            {

                GeneralErrorProvider.SetError(CantCottextBox, "Ingrese el tipo de vehiculo");

            }
            return paso;

        }

    }
}
