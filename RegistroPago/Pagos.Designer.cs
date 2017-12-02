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
            this.label8 = new System.Windows.Forms.Label();
            this.comboSucursal = new System.Windows.Forms.ComboBox();
            this.lblImporte = new System.Windows.Forms.Label();
            this.textPagador2 = new System.Windows.Forms.Label();
            this.textPagador = new System.Windows.Forms.TextBox();
            this.labelSucursal = new System.Windows.Forms.Label();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.dataGridFacturas = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPagar
            // 
            this.btnPagar.Location = new System.Drawing.Point(616, 365);
            this.btnPagar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(133, 50);
            this.btnPagar.TabIndex = 3;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(54, 334);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 20);
            this.label6.TabIndex = 68;
            this.label6.Text = "Importe:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(54, 365);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 20);
            this.label7.TabIndex = 70;
            this.label7.Text = "Medio de Pago:";
            // 
            // comboMedioDePago
            // 
            this.comboMedioDePago.FormattingEnabled = true;
            this.comboMedioDePago.Location = new System.Drawing.Point(209, 365);
            this.comboMedioDePago.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboMedioDePago.Name = "comboMedioDePago";
            this.comboMedioDePago.Size = new System.Drawing.Size(156, 24);
            this.comboMedioDePago.TabIndex = 69;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(54, 399);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 20);
            this.label8.TabIndex = 73;
            this.label8.Text = "Sucursal:";
            // 
            // comboSucursal
            // 
            this.comboSucursal.FormattingEnabled = true;
            this.comboSucursal.Location = new System.Drawing.Point(209, 399);
            this.comboSucursal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboSucursal.Name = "comboSucursal";
            this.comboSucursal.Size = new System.Drawing.Size(156, 24);
            this.comboSucursal.TabIndex = 72;
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporte.Location = new System.Drawing.Point(205, 334);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(18, 20);
            this.lblImporte.TabIndex = 74;
            this.lblImporte.Text = "0";
            // 
            // textPagador2
            // 
            this.textPagador2.AutoSize = true;
            this.textPagador2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPagador2.Location = new System.Drawing.Point(53, 302);
            this.textPagador2.Name = "textPagador2";
            this.textPagador2.Size = new System.Drawing.Size(110, 20);
            this.textPagador2.TabIndex = 78;
            this.textPagador2.Text = "DNI Pagador:";
            // 
            // textPagador
            // 
            this.textPagador.Location = new System.Drawing.Point(209, 302);
            this.textPagador.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textPagador.Name = "textPagador";
            this.textPagador.Size = new System.Drawing.Size(156, 22);
            this.textPagador.TabIndex = 77;
            // 
            // labelSucursal
            // 
            this.labelSucursal.AutoSize = true;
            this.labelSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSucursal.Location = new System.Drawing.Point(205, 399);
            this.labelSucursal.Name = "labelSucursal";
            this.labelSucursal.Size = new System.Drawing.Size(0, 20);
            this.labelSucursal.TabIndex = 79;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(381, 300);
            this.btnSeleccionar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(133, 28);
            this.btnSeleccionar.TabIndex = 80;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // dataGridFacturas
            // 
            this.dataGridFacturas.AllowUserToAddRows = false;
            this.dataGridFacturas.AllowUserToDeleteRows = false;
            this.dataGridFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFacturas.Location = new System.Drawing.Point(57, 63);
            this.dataGridFacturas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridFacturas.Name = "dataGridFacturas";
            this.dataGridFacturas.RowTemplate.Height = 24;
            this.dataGridFacturas.Size = new System.Drawing.Size(723, 162);
            this.dataGridFacturas.TabIndex = 83;
            this.dataGridFacturas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridFacturas_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(58, 241);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 28);
            this.button1.TabIndex = 84;
            this.button1.Text = "Agregar Factura";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Pagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 461);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridFacturas);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.labelSucursal);
            this.Controls.Add(this.textPagador2);
            this.Controls.Add(this.textPagador);
            this.Controls.Add(this.lblImporte);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboSucursal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboMedioDePago);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnPagar);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Pagos";
            this.Text = "Pagos";
            this.Load += new System.EventHandler(this.Pagos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFacturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboMedioDePago;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboSucursal;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.Label textPagador2;
        private System.Windows.Forms.TextBox textPagador;
        private System.Windows.Forms.Label labelSucursal;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.DataGridView dataGridFacturas;
        private System.Windows.Forms.Button button1;
    }
}