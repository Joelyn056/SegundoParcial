namespace SegundoParcial.UI.Registro
{
    partial class rVehiculos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.VehiculoIDNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.DescripcionTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BuscarButtonT = new System.Windows.Forms.Button();
            this.Eliminarbutton = new System.Windows.Forms.Button();
            this.Nuevobutton = new System.Windows.Forms.Button();
            this.Guardarbutton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TotalManTeNumericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.GeneralErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.VehiculoIDNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalManTeNumericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GeneralErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // VehiculoIDNumericUpDown
            // 
            this.VehiculoIDNumericUpDown.Location = new System.Drawing.Point(99, 41);
            this.VehiculoIDNumericUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.VehiculoIDNumericUpDown.Name = "VehiculoIDNumericUpDown";
            this.VehiculoIDNumericUpDown.Size = new System.Drawing.Size(183, 20);
            this.VehiculoIDNumericUpDown.TabIndex = 64;
            // 
            // DescripcionTextBox
            // 
            this.DescripcionTextBox.Location = new System.Drawing.Point(94, 85);
            this.DescripcionTextBox.Multiline = true;
            this.DescripcionTextBox.Name = "DescripcionTextBox";
            this.DescripcionTextBox.Size = new System.Drawing.Size(183, 50);
            this.DescripcionTextBox.TabIndex = 63;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "Descripcion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "Vehiculo ID";
            // 
            // BuscarButtonT
            // 
            this.BuscarButtonT.Image = global::SegundoParcial.Properties.Resources.find;
            this.BuscarButtonT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BuscarButtonT.Location = new System.Drawing.Point(302, 30);
            this.BuscarButtonT.Name = "BuscarButtonT";
            this.BuscarButtonT.Size = new System.Drawing.Size(87, 42);
            this.BuscarButtonT.TabIndex = 65;
            this.BuscarButtonT.Text = "Buscar";
            this.BuscarButtonT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BuscarButtonT.UseVisualStyleBackColor = true;
            this.BuscarButtonT.Click += new System.EventHandler(this.BuscarButtonT_Click);
            // 
            // Eliminarbutton
            // 
            this.Eliminarbutton.Image = global::SegundoParcial.Properties.Resources.Delete;
            this.Eliminarbutton.Location = new System.Drawing.Point(262, 218);
            this.Eliminarbutton.Name = "Eliminarbutton";
            this.Eliminarbutton.Size = new System.Drawing.Size(75, 60);
            this.Eliminarbutton.TabIndex = 62;
            this.Eliminarbutton.Text = "Eliminar";
            this.Eliminarbutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Eliminarbutton.UseVisualStyleBackColor = true;
            this.Eliminarbutton.Click += new System.EventHandler(this.Eliminarbutton_Click);
            // 
            // Nuevobutton
            // 
            this.Nuevobutton.Image = global::SegundoParcial.Properties.Resources.new2;
            this.Nuevobutton.Location = new System.Drawing.Point(45, 218);
            this.Nuevobutton.Name = "Nuevobutton";
            this.Nuevobutton.Size = new System.Drawing.Size(75, 60);
            this.Nuevobutton.TabIndex = 61;
            this.Nuevobutton.Text = "Nuevo";
            this.Nuevobutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Nuevobutton.UseVisualStyleBackColor = true;
            this.Nuevobutton.Click += new System.EventHandler(this.Nuevobutton_Click);
            // 
            // Guardarbutton
            // 
            this.Guardarbutton.Image = global::SegundoParcial.Properties.Resources.Save;
            this.Guardarbutton.Location = new System.Drawing.Point(154, 218);
            this.Guardarbutton.Name = "Guardarbutton";
            this.Guardarbutton.Size = new System.Drawing.Size(75, 60);
            this.Guardarbutton.TabIndex = 60;
            this.Guardarbutton.Text = "Guardar";
            this.Guardarbutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Guardarbutton.UseVisualStyleBackColor = true;
            this.Guardarbutton.Click += new System.EventHandler(this.Guardarbutton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 66;
            this.label3.Text = "Total Mantenimiento";
            // 
            // TotalManTeNumericUpDown2
            // 
            this.TotalManTeNumericUpDown2.Location = new System.Drawing.Point(139, 167);
            this.TotalManTeNumericUpDown2.Name = "TotalManTeNumericUpDown2";
            this.TotalManTeNumericUpDown2.Size = new System.Drawing.Size(120, 20);
            this.TotalManTeNumericUpDown2.TabIndex = 67;
            // 
            // GeneralErrorProvider
            // 
            this.GeneralErrorProvider.ContainerControl = this;
            // 
            // rVehiculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 309);
            this.Controls.Add(this.TotalManTeNumericUpDown2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BuscarButtonT);
            this.Controls.Add(this.VehiculoIDNumericUpDown);
            this.Controls.Add(this.DescripcionTextBox);
            this.Controls.Add(this.Eliminarbutton);
            this.Controls.Add(this.Nuevobutton);
            this.Controls.Add(this.Guardarbutton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "rVehiculos";
            this.Text = "Registro de vehiculos";
            ((System.ComponentModel.ISupportInitialize)(this.VehiculoIDNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalManTeNumericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GeneralErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BuscarButtonT;
        private System.Windows.Forms.NumericUpDown VehiculoIDNumericUpDown;
        private System.Windows.Forms.TextBox DescripcionTextBox;
        private System.Windows.Forms.Button Eliminarbutton;
        private System.Windows.Forms.Button Nuevobutton;
        private System.Windows.Forms.Button Guardarbutton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown TotalManTeNumericUpDown2;
        private System.Windows.Forms.ErrorProvider GeneralErrorProvider;
    }
}