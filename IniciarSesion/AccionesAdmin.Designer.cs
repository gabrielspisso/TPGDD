namespace PagoAgilFrba.IniciarSesion
{
    partial class AccionesAdmin
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
            this.Acciones = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.comboAccion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.comboPorcentaje = new System.Windows.Forms.ComboBox();
            this.lblGanancia = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridRendiciones = new System.Windows.Forms.DataGridView();
            this.lblCantFacturas = new System.Windows.Forms.Label();
            this.lblImporte = new System.Windows.Forms.Label();
            this.comboEmpresa = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.dateRendicion = new System.Windows.Forms.DateTimePicker();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.añoNUD = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.dataGridEstadisticas = new System.Windows.Forms.DataGridView();
            this.cmbTrimestre = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.textFacturaDev = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.richTextDev = new System.Windows.Forms.RichTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.Acciones.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRendiciones)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.añoNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEstadisticas)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // Acciones
            // 
            this.Acciones.Controls.Add(this.tabPage1);
            this.Acciones.Controls.Add(this.tabPage3);
            this.Acciones.Controls.Add(this.tabPage4);
            this.Acciones.Controls.Add(this.tabPage5);
            this.Acciones.Location = new System.Drawing.Point(0, 1);
            this.Acciones.Name = "Acciones";
            this.Acciones.SelectedIndex = 0;
            this.Acciones.Size = new System.Drawing.Size(542, 256);
            this.Acciones.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tabPage1.Controls.Add(this.comboAccion);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(534, 230);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Acciones";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // comboAccion
            // 
            this.comboAccion.FormattingEnabled = true;
            this.comboAccion.Location = new System.Drawing.Point(138, 40);
            this.comboAccion.Name = "comboAccion";
            this.comboAccion.Size = new System.Drawing.Size(207, 21);
            this.comboAccion.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione Funcionalidad";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(386, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ingresar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tabPage3.Controls.Add(this.comboPorcentaje);
            this.tabPage3.Controls.Add(this.lblGanancia);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.dataGridRendiciones);
            this.tabPage3.Controls.Add(this.lblCantFacturas);
            this.tabPage3.Controls.Add(this.lblImporte);
            this.tabPage3.Controls.Add(this.comboEmpresa);
            this.tabPage3.Controls.Add(this.label26);
            this.tabPage3.Controls.Add(this.label24);
            this.tabPage3.Controls.Add(this.label23);
            this.tabPage3.Controls.Add(this.label22);
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Controls.Add(this.button6);
            this.tabPage3.Controls.Add(this.dateRendicion);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage3.Size = new System.Drawing.Size(534, 230);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Rendición de Facturas cobradas ";
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // comboPorcentaje
            // 
            this.comboPorcentaje.FormattingEnabled = true;
            this.comboPorcentaje.Items.AddRange(new object[] {
            "0",
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50"});
            this.comboPorcentaje.Location = new System.Drawing.Point(430, 57);
            this.comboPorcentaje.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboPorcentaje.Name = "comboPorcentaje";
            this.comboPorcentaje.Size = new System.Drawing.Size(100, 21);
            this.comboPorcentaje.TabIndex = 31;
            this.comboPorcentaje.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lblGanancia
            // 
            this.lblGanancia.AutoSize = true;
            this.lblGanancia.Location = new System.Drawing.Point(432, 149);
            this.lblGanancia.Name = "lblGanancia";
            this.lblGanancia.Size = new System.Drawing.Size(13, 13);
            this.lblGanancia.TabIndex = 30;
            this.lblGanancia.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(280, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Ganancia empresa";
            // 
            // dataGridRendiciones
            // 
            this.dataGridRendiciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRendiciones.Location = new System.Drawing.Point(9, 55);
            this.dataGridRendiciones.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridRendiciones.Name = "dataGridRendiciones";
            this.dataGridRendiciones.RowTemplate.Height = 24;
            this.dataGridRendiciones.Size = new System.Drawing.Size(266, 170);
            this.dataGridRendiciones.TabIndex = 28;
            // 
            // lblCantFacturas
            // 
            this.lblCantFacturas.AutoSize = true;
            this.lblCantFacturas.Location = new System.Drawing.Point(432, 96);
            this.lblCantFacturas.Name = "lblCantFacturas";
            this.lblCantFacturas.Size = new System.Drawing.Size(13, 13);
            this.lblCantFacturas.TabIndex = 27;
            this.lblCantFacturas.Text = "0";
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Location = new System.Drawing.Point(432, 123);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(13, 13);
            this.lblImporte.TabIndex = 25;
            this.lblImporte.Text = "0";
            // 
            // comboEmpresa
            // 
            this.comboEmpresa.FormattingEnabled = true;
            this.comboEmpresa.Location = new System.Drawing.Point(430, 26);
            this.comboEmpresa.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboEmpresa.Name = "comboEmpresa";
            this.comboEmpresa.Size = new System.Drawing.Size(100, 21);
            this.comboEmpresa.TabIndex = 24;
            this.comboEmpresa.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(277, 96);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(148, 13);
            this.label26.TabIndex = 23;
            this.label26.Text = "Cantidad de facturas rendidas";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(280, 123);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(42, 13);
            this.label24.TabIndex = 21;
            this.label24.Text = "Importe";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(275, 28);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(48, 13);
            this.label23.TabIndex = 20;
            this.label23.Text = "Empresa";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(277, 63);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(117, 13);
            this.label22.TabIndex = 19;
            this.label22.Text = "Porcentaje de comisión";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(98, 13);
            this.label18.TabIndex = 15;
            this.label18.Text = "Fecha de rendicion";
            this.label18.Click += new System.EventHandler(this.label18_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(282, 166);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(247, 58);
            this.button6.TabIndex = 14;
            this.button6.Text = "Registrar";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // dateRendicion
            // 
            this.dateRendicion.Location = new System.Drawing.Point(163, 24);
            this.dateRendicion.Name = "dateRendicion";
            this.dateRendicion.Size = new System.Drawing.Size(100, 20);
            this.dateRendicion.TabIndex = 0;
            this.dateRendicion.ValueChanged += new System.EventHandler(this.dateRendicion_ValueChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage4.Size = new System.Drawing.Size(534, 230);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Estadisticas";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.añoNUD);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.btnConsultar);
            this.groupBox1.Controls.Add(this.dataGridEstadisticas);
            this.groupBox1.Controls.Add(this.cmbTrimestre);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.cmbTipo);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(511, 230);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TOP 5";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(151, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(275, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "A continuación, seleccione el top 5 que desea visualizar:";
            // 
            // añoNUD
            // 
            this.añoNUD.Location = new System.Drawing.Point(82, 82);
            this.añoNUD.Maximum = new decimal(new int[] {
            2017,
            0,
            0,
            0});
            this.añoNUD.Minimum = new decimal(new int[] {
            2010,
            0,
            0,
            0});
            this.añoNUD.Name = "añoNUD";
            this.añoNUD.Size = new System.Drawing.Size(67, 20);
            this.añoNUD.TabIndex = 17;
            this.añoNUD.Value = new decimal(new int[] {
            2017,
            0,
            0,
            0});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 89);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 13);
            this.label15.TabIndex = 16;
            this.label15.Text = "Año:";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(351, 79);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 13;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // dataGridEstadisticas
            // 
            this.dataGridEstadisticas.AllowUserToAddRows = false;
            this.dataGridEstadisticas.AllowUserToDeleteRows = false;
            this.dataGridEstadisticas.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridEstadisticas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEstadisticas.GridColor = System.Drawing.SystemColors.Window;
            this.dataGridEstadisticas.Location = new System.Drawing.Point(23, 112);
            this.dataGridEstadisticas.Name = "dataGridEstadisticas";
            this.dataGridEstadisticas.ReadOnly = true;
            this.dataGridEstadisticas.Size = new System.Drawing.Size(463, 115);
            this.dataGridEstadisticas.TabIndex = 11;
            // 
            // cmbTrimestre
            // 
            this.cmbTrimestre.FormattingEnabled = true;
            this.cmbTrimestre.Items.AddRange(new object[] {
            "Enero-Marzo",
            "Abril-Junio",
            "Julio-Septiembre",
            "Octubre-Diciembre"});
            this.cmbTrimestre.Location = new System.Drawing.Point(82, 53);
            this.cmbTrimestre.Name = "cmbTrimestre";
            this.cmbTrimestre.Size = new System.Drawing.Size(181, 21);
            this.cmbTrimestre.TabIndex = 10;
            this.cmbTrimestre.Text = "Seleccione";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 32);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(31, 13);
            this.label16.TabIndex = 9;
            this.label16.Text = "Tipo:";
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "Porcentaje de facturas cobradas por empresa",
            "Empresas con mayor monto rendido",
            "Clientes con mas pagos",
            "Clientes cumplidores"});
            this.cmbTipo.Location = new System.Drawing.Point(82, 24);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(181, 21);
            this.cmbTipo.TabIndex = 7;
            this.cmbTipo.Text = "Seleccione...";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 61);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 13);
            this.label17.TabIndex = 6;
            this.label17.Text = "Trimestre:";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tabPage5.Controls.Add(this.textFacturaDev);
            this.tabPage5.Controls.Add(this.button8);
            this.tabPage5.Controls.Add(this.richTextDev);
            this.tabPage5.Controls.Add(this.label19);
            this.tabPage5.Controls.Add(this.label20);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage5.Size = new System.Drawing.Size(534, 230);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Devoluciones";
            // 
            // textFacturaDev
            // 
            this.textFacturaDev.Location = new System.Drawing.Point(146, 42);
            this.textFacturaDev.Name = "textFacturaDev";
            this.textFacturaDev.Size = new System.Drawing.Size(149, 20);
            this.textFacturaDev.TabIndex = 18;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(383, 198);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(118, 23);
            this.button8.TabIndex = 15;
            this.button8.Text = "Generar Devolución";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // richTextDev
            // 
            this.richTextDev.Location = new System.Drawing.Point(146, 93);
            this.richTextDev.Name = "richTextDev";
            this.richTextDev.Size = new System.Drawing.Size(227, 96);
            this.richTextDev.TabIndex = 7;
            this.richTextDev.Text = "";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(31, 93);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(39, 13);
            this.label19.TabIndex = 6;
            this.label19.Text = "Motivo";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(31, 42);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(43, 13);
            this.label20.TabIndex = 4;
            this.label20.Text = "Factura";
            // 
            // AccionesAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(544, 256);
            this.Controls.Add(this.Acciones);
            this.Name = "AccionesAdmin";
            this.Text = "Acciones";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AccionesAdmin_FormClosing);
            this.Load += new System.EventHandler(this.AccionesAdmin_Load);
            this.Acciones.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRendiciones)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.añoNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEstadisticas)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Acciones;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown añoNUD;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DataGridView dataGridEstadisticas;
        private System.Windows.Forms.ComboBox cmbTrimestre;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DateTimePicker dateRendicion;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.RichTextBox richTextDev;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textFacturaDev;
        private System.Windows.Forms.ComboBox comboAccion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblCantFacturas;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.ComboBox comboEmpresa;
        private System.Windows.Forms.ComboBox comboPorcentaje;
        private System.Windows.Forms.Label lblGanancia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridRendiciones;

    }
}