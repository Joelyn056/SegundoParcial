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
        public Mantenimiento mantenimiento { get; set; } 
        public rMantenimiento()
        {
            InitializeComponent();
            LlenaComboBox();
            Fecha();
            mantenimiento = new Mantenimiento();
        }

        private void Fecha()
        {
            ProximodaMantenimientoTimePicker.Value = FechaDateTimePicker.Value.AddMonths(3);
        }

        private void LlenaCampo(Mantenimiento mantenimiento)
        {
            MantenimientoIdNumericUpDown.Value = mantenimiento.MantenimientoId;
            FechaDateTimePicker.Value = mantenimiento.Fecha;
            ProximodaMantenimientoTimePicker.Value = mantenimiento.ProxiMantenimiento;
            //VehiculoComboBox.Text = mantenimiento.Vehiculo;
            //ArticuloComboBox.Text = mantenimiento.ToString();
            //CantidadNumericUpDown.Value = mantenimiento.Cantidad;
            //PrecioNumericUpDown.Value = mantenimiento.Precio;
            //ImporteNumericUpDown.Value = mantenimiento.Importe;
            SubTotalNumericUpDown.Value = Convert.ToInt32(mantenimiento.Subtotal);
            ITBISNumericUpDown.Value = Convert.ToInt32(mantenimiento.Itbis);
            TotalnumericUpDown.Value = Convert.ToInt32(mantenimiento.Total);

            DetalledataGridView.DataSource = mantenimiento.Detalle.ToList();

            DetalledataGridView.Columns["Id"].Visible = false;
            DetalledataGridView.Columns["MantenimientoId"].Visible = false;

        }


        private void BuscarButton_Click(object sender, EventArgs e)
        {
            GeneralErrorProvider.Clear();

            //if (Validar())
            //{
            //    MessageBox.Show("Ingrese un ID");
            //    return;
            //

            int id = Convert.ToInt32(MantenimientoIdNumericUpDown.Value);
            Mantenimiento mantenimiento = BLL.MantenimientoBLL.Buscar(id);

            if (mantenimiento != null)
            {
                LlenaCampo(mantenimiento);

                //MantenimientoIdNumericUpDown.Value = mantenimiento.MantenimientoId;
                //TallerComboBox.Text = mantenimiento.Taller.ToString();
            }
            else
                MessageBox.Show("No se encontro", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }   

        private Mantenimiento LlenarClase()
        {
            Mantenimiento mantenimiento = new Mantenimiento();

            mantenimiento.MantenimientoId = Convert.ToInt32(MantenimientoIdNumericUpDown.Value);
            mantenimiento.Fecha = FechaDateTimePicker.Value;
            mantenimiento.ProxiMantenimiento = ProximodaMantenimientoTimePicker.Value;
            mantenimiento.Total = Convert.ToDecimal(TotalnumericUpDown.Value);
            mantenimiento.Subtotal = Convert.ToDecimal(SubTotalNumericUpDown.Value);
            mantenimiento.Itbis = Convert.ToDecimal(ITBISNumericUpDown.Value);

            //mantenimiento.VehiculoId = Convert.ToInt32(VehiculoComboBox.SelectedValue);
            //mantenimiento.Taller = Convert.ToInt32(TallerComboBox.SelectedValue);



            //foreach (DataGridViewRow item in DetalledataGridView.Rows)
            //{
            //    mantenimiento.AgregarDetalle(
            //        ToInt(item.Cells["Id"].Value),
            //        ToInt(item.Cells["MantenimientoId"]),
            //       ToInt(item.Cells["VehiculoId"].Value),
            //        ToInt(item.Cells["Taller"].Value),
            //        ToInt(item.Cells["Subtotal"].Value),
            //        ToInt(item.Cells["Itbis"].Value),
            //        ToInt(item.Cells["Total"].Value)
            //        );

            //}

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
            //List<MantenimientoD> Detalle = new List<MantenimientoD>();
            //Mantenimiento mantenimiento = new Mantenimiento();

            //if(DetalledataGridView.DataSource != null)
            //{
            //    mantenimiento.Detalle = (List<MantenimientoD>)DetalledataGridView.DataSource;
            //}


            //mantenimientoD.Detalle.Add(new MantenimientoD(
            MantenimientoD detalle = new MantenimientoD(

                id: 0,
                mantenimientoId: (int)MantenimientoIdNumericUpDown.Value,
                articuloId: (int)ArticuloComboBox.SelectedValue,
                tallerId: (int)TallerComboBox.SelectedValue,
                vehiculoId:(int)VehiculoComboBox.SelectedValue,
                articulo: ArticuloComboBox.Text,
                //vehiculo: (int)VehiculoComboBox.SelectedValue,
                //taller: (int)TallerComboBox.SelectedValue,
                cantidad: (int)CantidadNumericUpDown.Value,
                precio: (int)PrecioNumericUpDown.Value,
                importe: (int)ImporteNumericUpDown.Value
               
            );
            AgregarDetalle(
                detalle
                );


            DetalledataGridView.DataSource = null;
            DetalledataGridView.DataSource = mantenimiento.Detalle;

            DetalledataGridView.Columns["id"].Visible = false;
            DetalledataGridView.Columns["mantenimientoId"].Visible = false;
            DetalledataGridView.Columns["tallerId"].Visible = false;


            Total();

        }

        private void Total()
        {
            List<MantenimientoD> detalle = (List<MantenimientoD>)DetalledataGridView.DataSource;

            decimal Total= 0;
            decimal ItB;
            ItB = 0.18M;

            foreach(var item in detalle)
            {
                Total += item.Importe;
            }

            //TotalnumericUpDown.Value;
        }

        private void AgregarDetalle(MantenimientoD mantenimientoD)
        {
            foreach (var item in mantenimiento.Detalle)
            {
                if (item.ArticuloId== mantenimientoD.ArticuloId)
                {
                    item.Cantidad += mantenimientoD.Cantidad;
                    item.Importe = item.Precio * item.Cantidad;
                    return;
                }

            }

            mantenimiento.Detalle.Add(mantenimientoD);

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

        private void ArticuloComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Articulos articulos = (Articulos)ArticuloComboBox.SelectedItem;
            PrecioNumericUpDown.Value = Convert.ToDecimal(articulos.Precio);
        }

        private void CantidadNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            CalcularImporte();
            CalcularSubtotal();
            CalcularItbis();
            CalcularTotal();
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

        private void RemoverButton_Click(object sender, EventArgs e)
        {
            if(DetalledataGridView.Rows.Count > 0 && DetalledataGridView.CurrentRow != null)
            {
                List<MantenimientoD> Detalle = (List<MantenimientoD>)DetalledataGridView.DataSource;

                Detalle.RemoveAt(DetalledataGridView.CurrentRow.Index);

                DetalledataGridView.DataSource = null;
                DetalledataGridView.DataSource = Detalle;
            }
        }


        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            MantenimientoIdNumericUpDown.Value = 0;
            FechaDateTimePicker.Value = DateTime.Now;
            CantidadNumericUpDown.Value = 0;
            PrecioNumericUpDown.Value = 0;
            ImporteNumericUpDown.Value = 0;
            TotalnumericUpDown.Value = 0;
            DetalledataGridView.DataSource = null;
            SubTotalNumericUpDown.Value = 0;
            ITBISNumericUpDown.Value = 0;
            GeneralErrorProvider.Clear();
            mantenimiento.Detalle.Clear();

        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Mantenimiento mantenimiento;
            bool paso = false;
            if (Validar())
            {
                MessageBox.Show("Favor revisar todos los campos", "Validar", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;

            }

            mantenimiento = LlenarClase();

            if (MantenimientoIdNumericUpDown.Value == 0)
            {
                mantenimiento = LlenarClase();
                paso = BLL.MantenimientoBLL.Guardar(mantenimiento);
             
            }
            else
            {
                mantenimiento = LlenarClase();
                paso = BLL.MantenimientoBLL.Modificar(mantenimiento);
               
            }
            if (paso)
            {
                Nuevobutton.PerformClick();
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("No se pudo guardar!!", "Fallo",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);

            GeneralErrorProvider.Clear();           
        }

        //private void FechaDateTimePicker_ValueChanged(object sender, EventArgs e)
        //{
        //    ProximodaMantenimientoTimePicker.Value = FechaDateTimePicker.Value.AddMonths(3);
        //}

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(MantenimientoIdNumericUpDown.Value);

            if(BLL.MantenimientoBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se pudo eliminar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            GeneralErrorProvider.Clear();

            //if (Validar())
            //{
            //    MessageBox.Show("agregar ariticulos al Grid", "Validar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

        }
    }
}
