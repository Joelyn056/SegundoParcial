using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq.Expressions;
using SegundoParcial.BLL;
using SegundoParcial.Entidades;
using System.Threading.Tasks;

namespace SegundoParcial.UI.Consultas
{
    public partial class ConsultaVehiculos : Form
    {
        public ConsultaVehiculos()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Vehiculos, bool>> filtro = x => true;

            int id;
            switch(FiltrarComboBox.SelectedIndex)
            {
                case 0: //VehiculoId
                    id = Convert.ToInt32(CriterioTextBox.Text);
                    filtro = x => (x.VehiculoId == id);
                    break;

                case 1://Descripcio
                    filtro = x => (x.Descripcion.Contains(CriterioTextBox.Text));
                    break;

                //case 2://Inventario
                //    decimal Inventario = Convert.ToDecimal(CriterioTextBox.Text);
                //    filtro = x => x.Inventario == Inventario;
                //    break;

                case 2: //Todo
                    filtro = x => true;
                    break;
            }

            ConsultaDataGridView.DataSource = VehiculosBLL.GetList(filtro);
        }

    }
}
