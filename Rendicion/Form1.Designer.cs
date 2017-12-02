namespace PagoAgilFrba.Rendicion
{
    partial class Rendicion
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
            this.dateRendicion1 = new System.Windows.Forms.DateTimePicker();
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRendiciones)).BeginInit();
            this.SuspendLayout();
            // 
            // dateRendicion1
            // 
            this.dateRendicion1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateRendicion1.Location = new System.Drawing.Point(171, 28);
            this.dateRendicion1.Margin = new System.Windows.Forms.Padding(4);
            this.dateRendicion1.Name = "dateRendicion1";
            this.dateRendicion1.Size = new System.Drawing.Size(189, 22);
            this.dateRendicion1.TabIndex = 94;
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
            this.comboPorcentaje.Location = new System.Drawing.Point(574, 68);
            this.comboPorcentaje.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboPorcentaje.Name = "comboPorcentaje";
            this.comboPorcentaje.Size = new System.Drawing.Size(132, 24);
            this.comboPorcentaje.TabIndex = 93;
            this.comboPorcentaje.SelectedIndexChanged += new System.EventHandler(this.comboEmpresa_SelectedIndexChanged);
            // 
            // lblGanancia
            // 
            this.lblGanancia.AutoSize = true;
            this.lblGanancia.Location = new System.Drawing.Point(577, 181);
            this.lblGanancia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGanancia.Name = "lblGanancia";
            this.lblGanancia.Size = new System.Drawing.Size(16, 17);
            this.lblGanancia.TabIndex = 92;
            this.lblGanancia.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(374, 181);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 17);
            this.label4.TabIndex = 91;
            this.label4.Text = "Ganancia empresa";
            // 
            // dataGridRendiciones
            // 
            this.dataGridRendiciones.AllowUserToAddRows = false;
            this.dataGridRendiciones.AllowUserToDeleteRows = false;
            this.dataGridRendiciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRendiciones.Location = new System.Drawing.Point(13, 66);
            this.dataGridRendiciones.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridRendiciones.Name = "dataGridRendiciones";
            this.dataGridRendiciones.ReadOnly = true;
            this.dataGridRendiciones.RowTemplate.Height = 24;
            this.dataGridRendiciones.Size = new System.Drawing.Size(355, 209);
            this.dataGridRendiciones.TabIndex = 90;
            // 
            // lblCantFacturas
            // 
            this.lblCantFacturas.AutoSize = true;
            this.lblCantFacturas.Location = new System.Drawing.Point(577, 116);
            this.lblCantFacturas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCantFacturas.Name = "lblCantFacturas";
            this.lblCantFacturas.Size = new System.Drawing.Size(16, 17);
            this.lblCantFacturas.TabIndex = 89;
            this.lblCantFacturas.Text = "0";
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Location = new System.Drawing.Point(577, 149);
            this.lblImporte.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(16, 17);
            this.lblImporte.TabIndex = 88;
            this.lblImporte.Text = "0";
            // 
            // comboEmpresa
            // 
            this.comboEmpresa.FormattingEnabled = true;
            this.comboEmpresa.Location = new System.Drawing.Point(574, 30);
            this.comboEmpresa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboEmpresa.Name = "comboEmpresa";
            this.comboEmpresa.Size = new System.Drawing.Size(132, 24);
            this.comboEmpresa.TabIndex = 87;
            this.comboEmpresa.SelectedIndexChanged += new System.EventHandler(this.comboEmpresa_SelectedIndexChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(370, 116);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(198, 17);
            this.label26.TabIndex = 86;
            this.label26.Text = "Cantidad de facturas rendidas";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(374, 149);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(55, 17);
            this.label24.TabIndex = 85;
            this.label24.Text = "Importe";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(368, 32);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(64, 17);
            this.label23.TabIndex = 84;
            this.label23.Text = "Empresa";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(370, 76);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(155, 17);
            this.label22.TabIndex = 83;
            this.label22.Text = "Porcentaje de comisión";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 28);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(129, 17);
            this.label18.TabIndex = 82;
            this.label18.Text = "Fecha de rendicion";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(377, 202);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(329, 71);
            this.button6.TabIndex = 81;
            this.button6.Text = "Registrar";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Rendicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 297);
            this.Controls.Add(this.dateRendicion1);
            this.Controls.Add(this.comboPorcentaje);
            this.Controls.Add(this.lblGanancia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridRendiciones);
            this.Controls.Add(this.lblCantFacturas);
            this.Controls.Add(this.lblImporte);
            this.Controls.Add(this.comboEmpresa);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.button6);
            this.Name = "Rendicion";
            this.Text = "Rendiciones";
            this.Load += new System.EventHandler(this.Rendicion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRendiciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateRendicion1;
        private System.Windows.Forms.ComboBox comboPorcentaje;
        private System.Windows.Forms.Label lblGanancia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridRendiciones;
        private System.Windows.Forms.Label lblCantFacturas;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.ComboBox comboEmpresa;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button button6;
    }
}