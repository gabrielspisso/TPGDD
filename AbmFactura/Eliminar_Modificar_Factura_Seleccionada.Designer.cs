namespace PagoAgilFrba.AbmFactura
{
    partial class Eliminar_Modificar_Factura_Seleccionada
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtEmpresa = new System.Windows.Forms.ComboBox();
            this.dateVenc = new System.Windows.Forms.DateTimePicker();
            this.dateAlta = new System.Windows.Forms.DateTimePicker();
            this.button3 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.listaSeleccionados = new System.Windows.Forms.ListView();
            this.monto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cantidad = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFactura = new System.Windows.Forms.TextBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.CheckHabilitado = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(454, 368);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 64;
            this.btnAceptar.Text = "Modificar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.FormattingEnabled = true;
            this.txtEmpresa.Location = new System.Drawing.Point(388, 63);
            this.txtEmpresa.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(140, 21);
            this.txtEmpresa.TabIndex = 81;
            this.txtEmpresa.TextChanged += new System.EventHandler(this.actualizarlabel);
            // 
            // dateVenc
            // 
            this.dateVenc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateVenc.Location = new System.Drawing.Point(386, 132);
            this.dateVenc.Name = "dateVenc";
            this.dateVenc.Size = new System.Drawing.Size(143, 20);
            this.dateVenc.TabIndex = 80;
            // 
            // dateAlta
            // 
            this.dateAlta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateAlta.Location = new System.Drawing.Point(119, 132);
            this.dateAlta.Name = "dateAlta";
            this.dateAlta.Size = new System.Drawing.Size(143, 20);
            this.dateAlta.TabIndex = 79;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(103, 276);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 78;
            this.button3.Text = "Agregar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 237);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 77;
            this.label8.Text = "Cantidad";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(81, 233);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(143, 20);
            this.txtCantidad.TabIndex = 76;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 75;
            this.label7.Text = "Monto";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(81, 197);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(143, 20);
            this.txtMonto.TabIndex = 74;
            // 
            // listaSeleccionados
            // 
            this.listaSeleccionados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.monto,
            this.cantidad});
            this.listaSeleccionados.Location = new System.Drawing.Point(243, 197);
            this.listaSeleccionados.Margin = new System.Windows.Forms.Padding(2);
            this.listaSeleccionados.Name = "listaSeleccionados";
            this.listaSeleccionados.Size = new System.Drawing.Size(314, 154);
            this.listaSeleccionados.TabIndex = 73;
            this.listaSeleccionados.UseCompatibleStateImageBehavior = false;
            this.listaSeleccionados.View = System.Windows.Forms.View.Details;
            this.listaSeleccionados.SelectedIndexChanged += new System.EventHandler(this.listaSeleccionados_SelectedIndexChanged);
            // 
            // monto
            // 
            this.monto.Text = "Monto";
            this.monto.Width = 166;
            // 
            // cantidad
            // 
            this.cantidad.Text = "Cantidad";
            this.cantidad.Width = 122;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(282, 137);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 13);
            this.label13.TabIndex = 72;
            this.label13.Text = "Fecha Vencimiento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 71;
            this.label3.Text = "Fecha Alta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(313, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 70;
            this.label2.Text = "Empresa";
            // 
            // txtFactura
            // 
            this.txtFactura.Location = new System.Drawing.Point(119, 91);
            this.txtFactura.Name = "txtFactura";
            this.txtFactura.Size = new System.Drawing.Size(144, 20);
            this.txtFactura.TabIndex = 69;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(120, 51);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(143, 20);
            this.txtDni.TabIndex = 68;
            this.txtDni.TextChanged += new System.EventHandler(this.actualizarlabel);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 67;
            this.label6.Text = "N° Factura :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 66;
            this.label1.Text = "DNI Cliente:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(243, 368);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 82;
            this.button2.Text = "Quitar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(483, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 83;
            this.label4.Text = "label4";
            this.label4.TextChanged += new System.EventHandler(this.actualizarlabel);
            this.label4.Click += new System.EventHandler(this.actualizarlabel);
            // 
            // CheckHabilitado
            // 
            this.CheckHabilitado.AllowDrop = true;
            this.CheckHabilitado.AutoSize = true;
            this.CheckHabilitado.Location = new System.Drawing.Point(429, 94);
            this.CheckHabilitado.Name = "CheckHabilitado";
            this.CheckHabilitado.Size = new System.Drawing.Size(73, 17);
            this.CheckHabilitado.TabIndex = 85;
            this.CheckHabilitado.Text = "Habilitado";
            this.CheckHabilitado.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(315, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 84;
            this.label5.Text = "Habilitado";
            // 
            // Eliminar_Modificar_Factura_Seleccionada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 403);
            this.Controls.Add(this.CheckHabilitado);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtEmpresa);
            this.Controls.Add(this.dateVenc);
            this.Controls.Add(this.dateAlta);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.listaSeleccionados);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFactura);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAceptar);
            this.Name = "Eliminar_Modificar_Factura_Seleccionada";
            this.Text = "Eliminar_Modificar_Factura_Seleccionada";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox txtEmpresa;
        private System.Windows.Forms.DateTimePicker dateVenc;
        private System.Windows.Forms.DateTimePicker dateAlta;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.ListView listaSeleccionados;
        private System.Windows.Forms.ColumnHeader monto;
        private System.Windows.Forms.ColumnHeader cantidad;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFactura;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox CheckHabilitado;
        private System.Windows.Forms.Label label5;

    }
}