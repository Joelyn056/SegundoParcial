using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SegundoParcial.Entidades;
using SegundoParcial.BLL;
using SegundoParcial.DAL;
using System.Threading.Tasks;

namespace SegundoParcial.UI.Registro
{
    public partial class rMantenimiento : Form
    {
        decimal ITBIS = 0;
        decimal Importe = 0;
        decimal Total = 0;
        decimal SubTotal = 0;

        public rMantenimiento()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            GeneralErrorProvider.Clear();

            if (Validar(1))
            {
                MessageBox.Show("Ingrese un ID");
                return;
            }

            int id = Convert.ToInt32(MantenimientoIdNumericUpDown.Value);
            Mantenimiento mantenimiento = BLL.MantenimientoBLL.Buscar(id);

            if (mantenimiento != null)
            {
                MantenimientoIdNumericUpDown.Value = mantenimiento.MantenimientoId;
                VehiculoComboBox.Text = mantenimiento.Vehiculo;
                TallerComboBox.Text = mantenimiento.Taller.ToString();
            }
            else
                MessageBox.Show("No se encontro", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            MantenimientoIdNumericUpDown.Value = 0;
            //VehiculoComboBox.Text;
            //TallerComboBox.Text;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            if(Validar(2))
            {
                MessageBox.Show("llenar los campos");

            }

            GeneralErrorProvider.Clear();

            if (MantenimientoIdNumericUpDown.Value == 0)
                paso = BLL.MantenimientoBLL.Guardar(LlenarClase());
            else
                paso = BLL.MantenimientoBLL.Modificar(LlenarClase());

            if (paso)
                MessageBox.Show("Guardado", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("no se pudo guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            GeneralErrorProvider.Clear();

            if(Validar(2))
            {
                MessageBox.Show("ingrese el mantenimiento Id");
                return;
            }

            int id = Convert.ToInt32(MantenimientoIdNumericUpDown.Value);

            if (BLL.MantenimientoBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("no se pudo guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private Mantenimiento LlenarClase()
        {
            Mantenimiento mantenimiento = new Mantenimiento();

            mantenimiento.MantenimientoId = Convert.ToInt32(MantenimientoIdNumericUpDown.Value);
            mantenimiento.Vehiculo = VehiculoComboBox.Text;
            mantenimiento.Taller = int.Parse(TallerComboBox.Text);

            return mantenimiento;
        }

        private bool Validar(int validar)
        {

            bool paso = false;
            if (validar == 1 && MantenimientoIdNumericUpDown.Value == 0)
            {
                GeneralErrorProvider.SetError(MantenimientoIdNumericUpDown, "el  ID");
                paso = true;

            }
            if (validar == 2 && VehiculoComboBox.Text == string.Empty)
            {
                GeneralErrorProvider.SetError(VehiculoComboBox, " vehiculo");
                paso = true;
            }
            if (validar == 2 && TallerComboBox.Text ==  string.Empty)
            {

                GeneralErrorProvider.SetError(TallerComboBox, " elija la opcion taller");
                paso = true;
            }

            return paso;
        }

        
        private void AgregarButton_Click(object sender, EventArgs e)
        {
            List<MantenimientoD> mantenimientos = new List<MantenimientoD>();

            if(DetalledataGridView.DataSource != null)
            {
                mantenimientos = (List<MantenimientoD>)DetalledataGridView.DataSource;
            }

        }
    }
}
