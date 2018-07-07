﻿using System;
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
    public partial class rTalleres : Form
    {
        public rTalleres()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            GeneralErrorProvider.Clear();

            if(Validar(1))
            {
                MessageBox.Show("Ingrese un ID");
                return;
            }

            int id = Convert.ToInt32(TallerIDNumericUpDown.Value);
            Talleres taller = BLL.TalleresBLL.Buscar(id); 

            if (taller != null)
            {
                TallerIDNumericUpDown.Value = taller.TallerId;
                NombreTextBox.Text = taller.Nombre;
            }
            else
                MessageBox.Show("No se encontro", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            TallerIDNumericUpDown.Value = 0;
            NombreTextBox.Clear();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            if(Validar(2))
            {
                MessageBox.Show("llenar los campo Marcados");
            }
            GeneralErrorProvider.Clear();

            if (TallerIDNumericUpDown.Value == 0)
                paso = BLL.TalleresBLL.Guardar(LlenarClase());
            else
                paso = BLL.TalleresBLL.Modificar(LlenarClase());

            if (paso)
                MessageBox.Show("Guardado", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            GeneralErrorProvider.Clear();

            if(Validar(1))
            {
                MessageBox.Show("Ingrese un ID");
                return;
            }

            int id = Convert.ToInt32(TallerIDNumericUpDown.Value);

            if (BLL.TalleresBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("no se pudo guardar","Fallo",MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private Talleres LlenarClase()
        {
            Talleres Taller = new Talleres();

            Taller.TallerId = Convert.ToInt32(TallerIDNumericUpDown.Value);
            Taller.Nombre = NombreTextBox.Text;

            return Taller;
        }

        private bool Validar(int validar)
        {

            bool paso = false;
            if (validar == 1 && TallerIDNumericUpDown.Value == 0)
            {
                GeneralErrorProvider.SetError(TallerIDNumericUpDown, "el Vehiculo ID");
                paso = true;

            }
            if (validar == 2 && NombreTextBox.Text == string.Empty)
            {
                GeneralErrorProvider.SetError(NombreTextBox, "Ingrese una nombre");
                paso = true;
            }

            return paso;
        }
    }
}
