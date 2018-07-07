using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SegundoParcial.UI.Registro;

namespace SegundoParcial
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void vehiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new rArticulos().Show();
        }

        private void registroCotizacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new rMantenimiento().Show();
        }

        private void registroMantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new rMantenimiento().Show();
        }

        private void registroVehiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new rVehiculos().Show();
        }

        private void registroEntradaArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new rEntradaArticulo().Show();
        }

        private void registroTalleresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new rTalleres().Show();
        }
    }
}
