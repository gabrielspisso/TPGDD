namespace PagoAgilFrba.RegistroPago
{
    partial class Pagos
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
            this.btnPagar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboMedioDePago = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateVenc = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.comboEmpresas = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFactura = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.dataGridFacturas = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.comboSucursal = new System.Windows.Forms.ComboBox();
            this.lblImporte = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPagar
            // 
            this.btnPagar.Location = new System.Drawing.Point(372, 378);
            this.btnPagar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(100, 41);
            this.btnPagar.TabIndex = 3;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(53, 364);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 17);
            this.label6.TabIndex = 68;
            this.label6.Text = "Importe:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(53, 389);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 17);
            this.label7.TabIndex = 70;
            this.label7.Text = "Medio de Pago:";
            // 
            // comboMedioDePago
            // 
            this.comboMedioDePago.FormattingEnabled = true;
            this.comboMedioDePago.Location = new System.Drawing.Point(169, 389);
            this.comboMedioDePago.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboMedioDePago.Name = "comboMedioDePago";
            this.comboMedioDePago.Size = new System.Drawing.Size(118, 21);
            this.comboMedioDePago.TabIndex = 69;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dateVenc);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboEmpresas);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtFactura);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDni);
            this.groupBox1.Controls.Add(this.dataGridFacturas);
            this.groupBox1.Location = new System.Drawing.Point(21, 21);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(482, 327);
            this.groupBox1.TabIndex = 71;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(32, 115);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 17);
            this.label5.TabIndex = 76;
            this.label5.Text = "Fecha de vencimiento:";
            // 
            // dateVenc
            // 
            this.dateVenc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateVenc.Location = new System.Drawing.Point(185, 115);
            this.dateVenc.Name = "dateVenc";
            this.dateVenc.Size = new System.Drawing.Size(99, 20);
            this.dateVenc.TabIndex = 75;
            this.dateVenc.Value = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            this.dateVenc.ValueChanged += new System.EventHandler(this.dateVenc_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(308, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 74;
            this.label4.Text = "Empresa:";
            // 
            // comboEmpresas
            // 
            this.comboEmpresas.FormattingEnabled = true;
            this.comboEmpresas.Location = new System.Drawing.Point(380, 30);
            this.comboEmpresas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboEmpresas.Name = "comboEmpresas";
            this.comboEmpresas.Size = new System.Drawing.Size(98, 21);
            this.comboEmpresas.TabIndex = 73;
            this.comboEmpresas.SelectedIndexChanged += new System.EventHandler(this.comboEmpresas_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 74);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 17);
            this.label3.TabIndex = 72;
            this.label3.Text = "Numero de factura:";
            // 
            // txtFactura
            // 
            this.txtFactura.Location = new System.Drawing.Point(166, 74);
            this.txtFactura.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFactura.Name = "txtFactura";
            this.txtFactura.Size = new System.Drawing.Size(118, 20);
            this.txtFactura.TabIndex = 71;
            this.txtFactura.TextChanged += new System.EventHandler(this.txtFactura_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 150);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 17);
            this.label2.TabIndex = 70;
            this.label2.Text = "Seleccione la/s factura/s a pagar:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 69;
            this.label1.Text = "DNI Cliente:";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(166, 32);
            this.txtDni.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(118, 20);
            this.txtDni.TabIndex = 68;
            this.txtDni.TextChanged += new System.EventHandler(this.txtDni_TextChanged);
            // 
            // dataGridFacturas
            // 
            this.dataGridFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFacturas.Location = new System.Drawing.Point(33, 176);
            this.dataGridFacturas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridFacturas.Name = "dataGridFacturas";
            this.dataGridFacturas.RowTemplate.Height = 24;
            this.dataGridFacturas.Size = new System.Drawing.Size(418, 122);
            this.dataGridFacturas.TabIndex = 67;
            this.dataGridFacturas.SelectionChanged += new System.EventHandler(this.dataGridFacturas_SelectionChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(53, 417);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 17);
            this.label8.TabIndex = 73;
            this.label8.Text = "Sucursal:";
            // 
            // comboSucursal
            // 
            this.comboSucursal.FormattingEnabled = true;
            this.comboSucursal.Location = new System.Drawing.Point(169, 417);
            this.comboSucursal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboSucursal.Name = "comboSucursal";
            this.comboSucursal.Size = new System.Drawing.Size(118, 21);
            this.comboSucursal.TabIndex = 72;
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporte.Location = new System.Drawing.Point(166, 364);
            this.lblImporte.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(16, 17);
            this.lblImporte.TabIndex = 74;
            this.lblImporte.Text = "0";
            // 
            // Pagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 453);
            this.Controls.Add(this.lblImporte);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboSucursal);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboMedioDePago);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnPagar);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Pagos";
            this.Text = "Pagos";
            this.Load += new System.EventHandler(this.Pagos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFacturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboMedioDePago;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateVenc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboEmpresas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFactura;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.DataGridView dataGridFacturas;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboSucursal;
        private System.Windows.Forms.Label lblImporte;
    }
}