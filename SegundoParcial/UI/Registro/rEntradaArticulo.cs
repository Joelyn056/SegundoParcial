using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SegundoParcial.DAL;
using SegundoParcial.Entidades;

namespace SegundoParcial.UI.Registro
{
    public partial class rEntradaArticulo : Form
    {
        public rEntradaArticulo()
        {
            InitializeComponent();
            LlenaComboBox();
        }

        private void LlenaComboBox()
        {
            Repositorio<Articulos> repositorio = new Repositorio<Articulos>(new Contexto());
            ArticuloComboBox.DataSource = repositorio.GetList(a => true);
            ArticuloComboBox.ValueMember = "ArticuloId";
            ArticuloComboBox.DisplayMember = "Descripcion";

        }

        private void BuscarButtonT_Click(object sender, EventArgs e)
        {
            GeneralErrorProvider.Clear();

            //if (Validar(1))
            //{
            //    MessageBox.Show("Ingrese el ID");
            //    return;
            //}

            int id = Convert.ToInt32(EntradaIDNumericUpDown.Value);
            rEntradaArt rEntradaArt = BLL.rEntradaArtBLL.Buscar(id);

            if (rEntradaArt != null)
            {
                EntradaIDNumericUpDown.Value = rEntradaArt.EntradaId;
                ArticuloComboBox.Text = rEntradaArt.ArticuloId.ToString();
                CantidadNumericUpDown2.Value = rEntradaArt.Cantidad;
                
            }
            else
                MessageBox.Show("No se encontro", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            EntradaIDNumericUpDown.Value = 0;
            FechaDateTimePicker1.ResetText();
            GeneralErrorProvider.Clear();
            CantidadNumericUpDown2.Value = 0;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            //if(Validar(2))
            //{
            //    MessageBox.Show("llenar todos los compos marcados");
            //    return;
            //}

            GeneralErrorProvider.Clear();

            if (EntradaIDNumericUpDown.Value == 0)
                paso = BLL.rEntradaArtBLL.Guardar(LlenarClase());
            else
            {
                int id = Convert.ToInt32(EntradaIDNumericUpDown.Value);
                rEntradaArt rEntradaArt = BLL.rEntradaArtBLL.Buscar(id);
                if (rEntradaArt != null)
                {
                    paso = BLL.rEntradaArtBLL.Modificar(LlenarClase());
                }
                else
                    MessageBox.Show("No se pudo encontrar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            if (paso)
                MessageBox.Show("Guardo", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se guardo", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            GeneralErrorProvider.Clear();

            //if(Validar(2))
            //{
            //    MessageBox.Show("Ingrese el Id");
            //    return;
            //}

            int id = Convert.ToInt32(EntradaIDNumericUpDown.Value);

            if (BLL.rEntradaArtBLL.Eliminar(id))
                MessageBox.Show("Elimino", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo Guadar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private rEntradaArt LlenarClase()
        {
            rEntradaArt rEntradaArt = new rEntradaArt();

            rEntradaArt.EntradaId = Convert.ToInt32(EntradaIDNumericUpDown.Value);
            rEntradaArt.ArticuloId =(int)ArticuloComboBox.SelectedValue;
            rEntradaArt.Fecha = FechaDateTimePicker1.Value.Date;           
            rEntradaArt.Cantidad = Convert.ToInt32(CantidadNumericUpDown2.Value);

            return rEntradaArt;
        }

        private bool Validar()
        {
            bool Validar = false;
            if (CantidadNumericUpDown2.Value == 0)
            {
                GeneralErrorProvider.SetError(CantidadNumericUpDown2, "Digite la Cantidad de entradas");
                Validar = true;
            }
            
            return Validar;

        }

        private void rEntradaArticulo_Load(object sender, EventArgs e)
        {

        }
    }
}
