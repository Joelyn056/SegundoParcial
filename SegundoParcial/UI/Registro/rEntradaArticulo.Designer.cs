namespace SegundoParcial.UI.Registro
{
    partial class rEntradaArticulo
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
            this.CantidadNumericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.EntradaIDNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.BuscarButtonT = new System.Windows.Forms.Button();
            this.Eliminarbutton = new System.Windows.Forms.Button();
            this.Nuevobutton = new System.Windows.Forms.Button();
            this.Guardarbutton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.FechaDateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.ArticuloComboBox = new System.Windows.Forms.ComboBox();
            this.GeneralErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.CantidadNumericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntradaIDNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GeneralErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // CantidadNumericUpDown2
            // 
            this.CantidadNumericUpDown2.Location = new System.Drawing.Point(107, 172);
            this.CantidadNumericUpDown2.Name = "CantidadNumericUpDown2";
            this.CantidadNumericUpDown2.Size = new System.Drawing.Size(184, 20);
            this.CantidadNumericUpDown2.TabIndex = 77;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 76;
            this.label3.Text = "Cantidad";
            // 
            // EntradaIDNumericUpDown
            // 
            this.EntradaIDNumericUpDown.Location = new System.Drawing.Point(107, 40);
            this.EntradaIDNumericUpDown.Name = "EntradaIDNumericUpDown";
            this.EntradaIDNumericUpDown.Size = new System.Drawing.Size(183, 20);
            this.EntradaIDNumericUpDown.TabIndex = 74;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 68;
            this.label1.Text = "Entrada ID";
            // 
            // BuscarButtonT
            // 
            this.BuscarButtonT.Image = global::SegundoParcial.Properties.Resources.find;
            this.BuscarButtonT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BuscarButtonT.Location = new System.Drawing.Point(312, 72);
            this.BuscarButtonT.Name = "BuscarButtonT";
            this.BuscarButtonT.Size = new System.Drawing.Size(87, 42);
            this.BuscarButtonT.TabIndex = 75;
            this.BuscarButtonT.Text = "Buscar";
            this.BuscarButtonT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BuscarButtonT.UseVisualStyleBackColor = true;
            this.BuscarButtonT.Click += new System.EventHandler(this.BuscarButtonT_Click);
            // 
            // Eliminarbutton
            // 
            this.Eliminarbutton.Image = global::SegundoParcial.Properties.Resources.Delete;
            this.Eliminarbutton.Location = new System.Drawing.Point(270, 217);
            this.Eliminarbutton.Name = "Eliminarbutton";
            this.Eliminarbutton.Size = new System.Drawing.Size(75, 60);
            this.Eliminarbutton.TabIndex = 72;
            this.Eliminarbutton.Text = "Eliminar";
            this.Eliminarbutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Eliminarbutton.UseVisualStyleBackColor = true;
            this.Eliminarbutton.Click += new System.EventHandler(this.Eliminarbutton_Click);
            // 
            // Nuevobutton
            // 
            this.Nuevobutton.Image = global::SegundoParcial.Properties.Resources.new2;
            this.Nuevobutton.Location = new System.Drawing.Point(53, 217);
            this.Nuevobutton.Name = "Nuevobutton";
            this.Nuevobutton.Size = new System.Drawing.Size(75, 60);
            this.Nuevobutton.TabIndex = 71;
            this.Nuevobutton.Text = "Nuevo";
            this.Nuevobutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Nuevobutton.UseVisualStyleBackColor = true;
            this.Nuevobutton.Click += new System.EventHandler(this.Nuevobutton_Click);
            // 
            // Guardarbutton
            // 
            this.Guardarbutton.Image = global::SegundoParcial.Properties.Resources.Save;
            this.Guardarbutton.Location = new System.Drawing.Point(162, 217);
            this.Guardarbutton.Name = "Guardarbutton";
            this.Guardarbutton.Size = new System.Drawing.Size(75, 60);
            this.Guardarbutton.TabIndex = 70;
            this.Guardarbutton.Text = "Guardar";
            this.Guardarbutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Guardarbutton.UseVisualStyleBackColor = true;
            this.Guardarbutton.Click += new System.EventHandler(this.Guardarbutton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 69;
            this.label2.Text = "Fecha";
            // 
            // FechaDateTimePicker1
            // 
            this.FechaDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FechaDateTimePicker1.Location = new System.Drawing.Point(106, 87);
            this.FechaDateTimePicker1.Name = "FechaDateTimePicker1";
            this.FechaDateTimePicker1.Size = new System.Drawing.Size(184, 20);
            this.FechaDateTimePicker1.TabIndex = 78;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 79;
            this.label4.Text = "Articulo";
            // 
            // ArticuloComboBox
            // 
            this.ArticuloComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ArticuloComboBox.FormattingEnabled = true;
            this.ArticuloComboBox.Location = new System.Drawing.Point(107, 128);
            this.ArticuloComboBox.Name = "ArticuloComboBox";
            this.ArticuloComboBox.Size = new System.Drawing.Size(184, 21);
            this.ArticuloComboBox.TabIndex = 81;
            // 
            // GeneralErrorProvider
            // 
            this.GeneralErrorProvider.ContainerControl = this;
            // 
            // rEntradaArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 300);
            this.Controls.Add(this.ArticuloComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FechaDateTimePicker1);
            this.Controls.Add(this.CantidadNumericUpDown2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BuscarButtonT);
            this.Controls.Add(this.EntradaIDNumericUpDown);
            this.Controls.Add(this.Eliminarbutton);
            this.Controls.Add(this.Nuevobutton);
            this.Controls.Add(this.Guardarbutton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "rEntradaArticulo";
            this.Text = "Registro entrada Articulo";
            this.Load += new System.EventHandler(this.rEntradaArticulo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CantidadNumericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntradaIDNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GeneralErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown CantidadNumericUpDown2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BuscarButtonT;
        private System.Windows.Forms.NumericUpDown EntradaIDNumericUpDown;
        private System.Windows.Forms.Button Eliminarbutton;
        private System.Windows.Forms.Button Nuevobutton;
        private System.Windows.Forms.Button Guardarbutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker FechaDateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ArticuloComboBox;
        private System.Windows.Forms.ErrorProvider GeneralErrorProvider;
    }
}