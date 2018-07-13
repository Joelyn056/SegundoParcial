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

        public rMantenimiento()
        {
            InitializeComponent();
            LlenaComboBox();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            GeneralErrorProvider.Clear();

            if (Validar())
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
            FechaDateTimePicker.ResetText();
            CantidadNumericUpDown.Value = 0;
            ImporteNumericUpDown.Value = 0;
            SubTotalNumericUpDown.Value = 0;
            ITBISNumericUpDown.Value = 0;
            TotalnumericUpDown.Value = 0;
            DetalledataGridView.DataSource = null;
            GeneralErrorProvider.Clear();

        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            if(Validar())
            //{
            //    MessageBox.Show("llenar los campos");

            //}

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

            if(Validar())
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

            foreach (DataGridViewRow item in DetalledataGridView.Rows)
            {
                mantenimiento.AgregarDetalle(
                    ToInt(item.Cells["Id"].Value),
                    ToInt(item.Cells["MantenimientoId"]),
                    (item.Cells["Vehiculo"].Value.ToString()),
                    (DateTime)(item.Cells["ProximoMantenimiento"].Value),
                    ToInt(item.Cells["Taller"].Value),
                    ToInt(item.Cells["Cantidad"].Value),
                    ToInt(item.Cells["Precio"].Value),
                    ToInt(item.Cells["Importe"].Value)
                    );

            }

            return mantenimiento;
        }

        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);
            return retorno;
        }

        private bool Validar()
        {

            bool Validar = false;
            if (DetalledataGridView.RowCount == 0)
            {
                GeneralErrorProvider.SetError(DetalledataGridView, "No hay datos para mostrar");
                Validar = true;

            }
           
            return Validar;
        }


        private void CalcularImporte()
        {
            if (CantidadNumericUpDown.Value != 0)
            {
                ImporteNumericUpDown.Value = BLL.ArticulosBLL.CalcularImporte(CantidadNumericUpDown.Value, PrecioNumericUpDown.Value);
            }
            else
                ImporteNumericUpDown.Value = 0;
         }
        
        private void AgregarButton_Click(object sender, EventArgs e)
        {
            List<MantenimientoD> mantenimientos = new List<MantenimientoD>();

            if(DetalledataGridView.DataSource != null)
            {
                mantenimientos = (List<MantenimientoD>)DetalledataGridView.DataSource;
            }

            mantenimientos.Add(new MantenimientoD(

                id: 0,
                mantenimientoId: (int)MantenimientoIdNumericUpDown.Value,
                vehiculoId: (int)VehiculoComboBox.SelectedValue,
                precio: (int)PrecioNumericUpDown.Value,
                importe: (int)ImporteNumericUpDown.Value,
                articuloId: (int)ArticuloComboBox.SelectedValue,
                cantidad: (int)CantidadNumericUpDown.Value,
                subTotal: (int)SubTotalNumericUpDown.Value,
                tallerId: (int)TallerComboBox.SelectedValue,
                itbis: (int)ITBISNumericUpDown.Value,
                total: (int) TotalnumericUpDown.Value

            ));


            DetalledataGridView.DataSource = null;
            DetalledataGridView.DataSource = mantenimientos;
            CalcularSubtotal();
            CalcularItbis();
            CalcularTotal();


        }

        private void LlenaComboBox()
        {
            Repositorio<Articulos> articulos = new Repositorio<Articulos>(new Contexto());
            Repositorio<Talleres> talleres = new Repositorio<Talleres>(new Contexto());
            Repositorio<Vehiculos> vehiculos = new Repositorio<Vehiculos>(new Contexto());

            ArticuloComboBox.DataSource = articulos.GetList(a => true);
            ArticuloComboBox.ValueMember = "ArticuloId";
            ArticuloComboBox.DisplayMember = "Descripcion";

            TallerComboBox.DataSource = talleres.GetList(t => true);
            TallerComboBox.ValueMember = "TallerId";
            TallerComboBox.DisplayMember = "Nombre";

            VehiculoComboBox.DataSource = vehiculos.GetList(v => true);
            VehiculoComboBox.ValueMember = "VehiculoId";
            VehiculoComboBox.DisplayMember = "Descripcion";
             

        }



        private void LlenaCampo(MantenimientoD mantenimiento)
        {
            MantenimientoIdNumericUpDown.Value = mantenimiento.MantenimientoId;
            FechaDateTimePicker.Value = mantenimiento.Fecha;
            ProximodaMantenimientoTimePicker.Value = mantenimiento.ProxiMantenimiento;
            VehiculoComboBox.Text = mantenimiento.Vehiculo;
            ArticuloComboBox.Text = mantenimiento.ToString();
            CantidadNumericUpDown.Value = mantenimiento.Cantidad;
            PrecioNumericUpDown.Value = mantenimiento.Precio;
            ImporteNumericUpDown.Value = mantenimiento.Importe;
            SubTotalNumericUpDown.Value = mantenimiento.SubTotal;
            ITBISNumericUpDown.Value = mantenimiento.Itbis;
            TotalnumericUpDown.Value = mantenimiento.Total;

            DetalledataGridView.DataSource = mantenimiento;

            DetalledataGridView.Columns["id"].Visible = false;
            DetalledataGridView.Columns["MantenimientoI"].Visible = false;

        }

        private void ArticuloComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Repositorio<Articulos> precio = new Repositorio<Articulos>(new Contexto());
            Articulos articulos = (Articulos)ArticuloComboBox.SelectedItem;
            PrecioNumericUpDown.Value = Convert.ToDecimal(articulos.Precio);
        }

        private void CantidadNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            CalcularImporte();
        }



        private void CalcularSubtotal()
        {
            if(ImporteNumericUpDown.Value != 0)
            {
                SubTotalNumericUpDown.Value = BLL.ArticulosBLL.CalcularSubtotal(ImporteNumericUpDown.Value);
            }
        }


        private void CalcularItbis()
        {
            if (SubTotalNumericUpDown.Value != 0)
            {
                ITBISNumericUpDown.Value = BLL.ArticulosBLL.CalcularItbis(SubTotalNumericUpDown.Value);
            }
        }

        private void CalcularTotal()
        {
            if (SubTotalNumericUpDown.Value != 0 && ITBISNumericUpDown.Value!=0)
            {
                TotalnumericUpDown.Value = BLL.ArticulosBLL.CalcularTotal(SubTotalNumericUpDown.Value , ITBISNumericUpDown.Value);
            }
        }

        private void FechaDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            ProximodaMantenimientoTimePicker.Value = FechaDateTimePicker.Value.AddMonths(3);
        }
    }
}
