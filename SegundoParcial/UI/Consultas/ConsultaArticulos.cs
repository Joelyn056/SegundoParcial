using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SegundoParcial.Entidades;
using System.Linq.Expressions;
using SegundoParcial.BLL;
using System.Threading.Tasks;

namespace SegundoParcial.UI.Consultas
{
    public partial class ConsultaArticulos : Form
    {
        public ConsultaArticulos()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Articulos, bool>> filtro = x => true;

            int id;
            switch (FiltroComboBox.SelectedIndex)
            {
                case 0:  //ArticuloId
                    id = Convert.ToInt32(CriterioTextBox.Text);
                    filtro = x => x.ArticuloId == id;
                    break;

                case 1: //Ganacia
                    id = Convert.ToInt32(CriterioTextBox.Text);
                    filtro = x => x.Ganancia == id;
                    break;

                case 2: //Descripcion
                    filtro = x => x.Descripcion.Contains(CriterioTextBox.Text); 
                    break;

                case 3://Precio
                    id = Convert.ToInt32(CriterioTextBox.Text);
                    filtro = x => x.Precio == id; 
                    break;

                case 4: //Inventario
                    id = Convert.ToInt32(CriterioTextBox.Text);
                    filtro = x => x.Inventario == id;

                    break;
            }

            ConsultaDataGridView.DataSource = ArticulosBLL.GetList(filtro);
        }

        private void ConsultaArticulos_Load(object sender, EventArgs e)
        {

        }

        private void FiltrarComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(FiltroComboBox.SelectedIndex == 1)
            //{
            //    CriterioTextBox.Visible = false;
            //    CriterioLabel.Visible = false;
            //}
            //else
            //{
            //    CriterioTextBox.Visible = false;
            //    CriterioLabel.Visible = false;
            //}
        }
    }
}
