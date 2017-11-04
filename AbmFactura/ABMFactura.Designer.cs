namespace PagoAgilFrba.AbmFactura
{
    partial class ABMFactura
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtEmpresa = new System.Windows.Forms.ComboBox();
            this.dateVenc = new System.Windows.Forms.DateTimePicker();
            this.dateAlta = new System.Windows.Forms.DateTimePicker();
            this.button3 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.listaSeleccionados = new System.Windows.Forms.ListView();
            this.monto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cantidad = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtFactura = new System.Windows.Forms.TextBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBoxModEmpresa = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dataGridViewModificarC = new System.Windows.Forms.DataGridView();
            this.textModNumeroFactura = new System.Windows.Forms.TextBox();
            this.textModCliente = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.comboboxEliminarEmpresa = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.datagridViewEliminar = new System.Windows.Forms.DataGridView();
            this.textEliminarNumeroFactura = new System.Windows.Forms.TextBox();
            this.textEliminarNumeroCliente = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewModificarC)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridViewEliminar)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(620, 384);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tabPage1.Controls.Add(this.txtEmpresa);
            this.tabPage1.Controls.Add(this.dateVenc);
            this.tabPage1.Controls.Add(this.dateAlta);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txtCantidad);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtMonto);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.listaSeleccionados);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnAceptar);
            this.tabPage1.Controls.Add(this.txtFactura);
            this.tabPage1.Controls.Add(this.txtDni);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(612, 358);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Agregar";
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.FormattingEnabled = true;
            this.txtEmpresa.Location = new System.Drawing.Point(390, 24);
            this.txtEmpresa.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(140, 21);
            this.txtEmpresa.TabIndex = 65;
            // 
            // dateVenc
            // 
            this.dateVenc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateVenc.Location = new System.Drawing.Point(388, 93);
            this.dateVenc.Name = "dateVenc";
            this.dateVenc.Size = new System.Drawing.Size(143, 20);
            this.dateVenc.TabIndex = 64;
            // 
            // dateAlta
            // 
            this.dateAlta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateAlta.Location = new System.Drawing.Point(121, 93);
            this.dateAlta.Name = "dateAlta";
            this.dateAlta.Size = new System.Drawing.Size(143, 20);
            this.dateAlta.TabIndex = 63;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(100, 257);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 62;
            this.button3.Text = "Agregar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 198);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 61;
            this.label8.Text = "Cantidad";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(83, 194);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(143, 20);
            this.txtCantidad.TabIndex = 60;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 59;
            this.label7.Text = "Monto";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(83, 158);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(143, 20);
            this.txtMonto.TabIndex = 58;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(245, 317);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 57;
            this.button2.Text = "Quitar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listaSeleccionados
            // 
            this.listaSeleccionados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.monto,
            this.cantidad});
            this.listaSeleccionados.Location = new System.Drawing.Point(245, 158);
            this.listaSeleccionados.Margin = new System.Windows.Forms.Padding(2);
            this.listaSeleccionados.Name = "listaSeleccionados";
            this.listaSeleccionados.Size = new System.Drawing.Size(314, 154);
            this.listaSeleccionados.TabIndex = 55;
            this.listaSeleccionados.UseCompatibleStateImageBehavior = false;
            this.listaSeleccionados.View = System.Windows.Forms.View.Details;
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
            this.label13.Location = new System.Drawing.Point(284, 98);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 13);
            this.label13.TabIndex = 44;
            this.label13.Text = "Fecha Vencimiento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Fecha Alta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(315, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Empresa";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(471, 317);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(87, 23);
            this.btnAceptar.TabIndex = 34;
            this.btnAceptar.Text = "Ingresar factura";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtFactura
            // 
            this.txtFactura.Location = new System.Drawing.Point(121, 52);
            this.txtFactura.Name = "txtFactura";
            this.txtFactura.Size = new System.Drawing.Size(144, 20);
            this.txtFactura.TabIndex = 30;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(122, 12);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(143, 20);
            this.txtDni.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "N° Factura :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "DNI Cliente:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tabPage2.Controls.Add(this.comboBoxModEmpresa);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.dataGridViewModificarC);
            this.tabPage2.Controls.Add(this.textModNumeroFactura);
            this.tabPage2.Controls.Add(this.textModCliente);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(612, 358);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Modificar";
            // 
            // comboBoxModEmpresa
            // 
            this.comboBoxModEmpresa.FormattingEnabled = true;
            this.comboBoxModEmpresa.Location = new System.Drawing.Point(129, 85);
            this.comboBoxModEmpresa.Name = "comboBoxModEmpresa";
            this.comboBoxModEmpresa.Size = new System.Drawing.Size(147, 21);
            this.comboBoxModEmpresa.TabIndex = 45;
            this.comboBoxModEmpresa.TextChanged += new System.EventHandler(this.textModNumeroFactura_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "N° Factura";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "Empresa :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(34, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(157, 13);
            this.label15.TabIndex = 24;
            this.label15.Text = "Ingrese datos para filtrar la tabla";
            // 
            // dataGridViewModificarC
            // 
            this.dataGridViewModificarC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewModificarC.Location = new System.Drawing.Point(295, 13);
            this.dataGridViewModificarC.Name = "dataGridViewModificarC";
            this.dataGridViewModificarC.Size = new System.Drawing.Size(313, 208);
            this.dataGridViewModificarC.TabIndex = 23;
            this.dataGridViewModificarC.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewModificarC_CellContentClick);
            // 
            // textModNumeroFactura
            // 
            this.textModNumeroFactura.Location = new System.Drawing.Point(129, 126);
            this.textModNumeroFactura.Name = "textModNumeroFactura";
            this.textModNumeroFactura.Size = new System.Drawing.Size(147, 20);
            this.textModNumeroFactura.TabIndex = 21;
            this.textModNumeroFactura.TextChanged += new System.EventHandler(this.textModNumeroFactura_TextChanged);
            // 
            // textModCliente
            // 
            this.textModCliente.Location = new System.Drawing.Point(129, 42);
            this.textModCliente.Name = "textModCliente";
            this.textModCliente.Size = new System.Drawing.Size(147, 20);
            this.textModCliente.TabIndex = 20;
            this.textModCliente.TextChanged += new System.EventHandler(this.textModNumeroFactura_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(34, 49);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 13);
            this.label14.TabIndex = 17;
            this.label14.Text = "Cliente :";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tabPage4.Controls.Add(this.comboboxEliminarEmpresa);
            this.tabPage4.Controls.Add(this.label18);
            this.tabPage4.Controls.Add(this.label19);
            this.tabPage4.Controls.Add(this.label20);
            this.tabPage4.Controls.Add(this.datagridViewEliminar);
            this.tabPage4.Controls.Add(this.textEliminarNumeroFactura);
            this.tabPage4.Controls.Add(this.textEliminarNumeroCliente);
            this.tabPage4.Controls.Add(this.label21);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(612, 358);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Eliminar";
            // 
            // comboboxEliminarEmpresa
            // 
            this.comboboxEliminarEmpresa.FormattingEnabled = true;
            this.comboboxEliminarEmpresa.Location = new System.Drawing.Point(129, 85);
            this.comboboxEliminarEmpresa.Name = "comboboxEliminarEmpresa";
            this.comboboxEliminarEmpresa.Size = new System.Drawing.Size(147, 21);
            this.comboboxEliminarEmpresa.TabIndex = 45;
            this.comboboxEliminarEmpresa.TextChanged += new System.EventHandler(this.textEliminarNombre_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(34, 133);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(58, 13);
            this.label18.TabIndex = 44;
            this.label18.Text = "N° Factura";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(34, 88);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(54, 13);
            this.label19.TabIndex = 42;
            this.label19.Text = "Empresa :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(34, 13);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(157, 13);
            this.label20.TabIndex = 24;
            this.label20.Text = "Ingrese datos para filtrar la tabla";
            // 
            // datagridViewEliminar
            // 
            this.datagridViewEliminar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridViewEliminar.Location = new System.Drawing.Point(295, 13);
            this.datagridViewEliminar.Name = "datagridViewEliminar";
            this.datagridViewEliminar.Size = new System.Drawing.Size(313, 208);
            this.datagridViewEliminar.TabIndex = 23;
            this.datagridViewEliminar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridViewEliminar_CellContentClick);
            // 
            // textEliminarNumeroFactura
            // 
            this.textEliminarNumeroFactura.Location = new System.Drawing.Point(129, 126);
            this.textEliminarNumeroFactura.Name = "textEliminarNumeroFactura";
            this.textEliminarNumeroFactura.Size = new System.Drawing.Size(147, 20);
            this.textEliminarNumeroFactura.TabIndex = 21;
            this.textEliminarNumeroFactura.TextChanged += new System.EventHandler(this.textEliminarNombre_TextChanged);
            // 
            // textEliminarNumeroCliente
            // 
            this.textEliminarNumeroCliente.Location = new System.Drawing.Point(129, 42);
            this.textEliminarNumeroCliente.Name = "textEliminarNumeroCliente";
            this.textEliminarNumeroCliente.Size = new System.Drawing.Size(147, 20);
            this.textEliminarNumeroCliente.TabIndex = 20;
            this.textEliminarNumeroCliente.TextChanged += new System.EventHandler(this.textEliminarNombre_TextChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(34, 49);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(45, 13);
            this.label21.TabIndex = 17;
            this.label21.Text = "Cliente :";
            // 
            // ABMFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 386);
            this.Controls.Add(this.tabControl1);
            this.Name = "ABMFactura";
            this.Text = "ABMFactura";
            this.Load += new System.EventHandler(this.ABMFactura_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewModificarC)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridViewEliminar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox comboBoxModEmpresa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dataGridViewModificarC;
        private System.Windows.Forms.TextBox textModNumeroFactura;
        private System.Windows.Forms.TextBox textModCliente;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ComboBox comboboxEliminarEmpresa;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DataGridView datagridViewEliminar;
        private System.Windows.Forms.TextBox textEliminarNumeroFactura;
        private System.Windows.Forms.TextBox textEliminarNumeroCliente;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView listaSeleccionados;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.ColumnHeader monto;
        private System.Windows.Forms.ColumnHeader cantidad;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtFactura;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DateTimePicker dateVenc;
        private System.Windows.Forms.DateTimePicker dateAlta;
        private System.Windows.Forms.ComboBox txtEmpresa;
    }
}