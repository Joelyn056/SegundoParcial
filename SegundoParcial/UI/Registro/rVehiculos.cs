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
    public partial class rVehiculos : Form
    {
        public rVehiculos()
        {
            InitializeComponent();
        }

        private void BuscarButtonT_Click(object sender, EventArgs e)
        {
            GeneralErrorProvider.Clear();

            if(Validar(1))
            {
                MessageBox.Show("Ingrese el ID");
                return;
            }

            int id = Convert.ToInt32(VehiculoIDNumericUpDown.Value);
            Vehiculos vehiculos = BLL.VehiculosBLL.Buscar(id);

            if (vehiculos != null)
            {
                VehiculoIDNumericUpDown.Value = vehiculos.VehiculoId;
                DescripcionTextBox.Text = vehiculos.Descripcion;
                TotalManTeNumericUpDown2.Value = vehiculos.Mantenimiento;
            }
            else
                MessageBox.Show("No se encontro", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            VehiculoIDNumericUpDown.Value = 0;
            DescripcionTextBox.Clear();
            TotalManTeNumericUpDown2.Value = 0;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            if(Validar(2))
            {
                MessageBox.Show("Llenar todos los campos marcados");
                return;
            }
            GeneralErrorProvider.Clear();

            if (VehiculoIDNumericUpDown.Value == 0)
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

            int id = Convert.ToInt32(VehiculoIDNumericUpDown.Value);

            if (BLL.VehiculosBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private Vehiculos LlenarClase()
        {
            Vehiculos vehi = new Vehiculos();

            vehi.VehiculoId = Convert.ToInt32(VehiculoIDNumericUpDown.Value);
            vehi.Descripcion = DescripcionTextBox.Text;
            vehi.Mantenimiento = Convert.ToInt32(TotalManTeNumericUpDown2.Value);

            return vehi;
        }

        private bool Validar(int validar)
        {

            bool paso = false;
            if (validar == 1 && VehiculoIDNumericUpDown.Value == 0)
            {
                GeneralErrorProvider.SetError(VehiculoIDNumericUpDown, "el Vehiculo ID");
                paso = true;

            }
            if (validar == 2 && DescripcionTextBox.Text == string.Empty)
            {
                GeneralErrorProvider.SetError(DescripcionTextBox, "Ingrese una descripcion");
                paso = true;
            }
            if (validar == 2 && TotalManTeNumericUpDown2.Value == 0)
            {

                GeneralErrorProvider.SetError(TotalManTeNumericUpDown2, "Ingrese el proximo mantenimiento");
                paso = true;
            }
            
            return paso;
        }
    }
}
