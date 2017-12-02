namespace PagoAgilFrba.IniciarSesion
{
    partial class elegirFactura
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
            this.filtroCliente = new System.Windows.Forms.MaskedTextBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.listadoClientes = new System.Windows.Forms.DataGridView();
            this.Elegir = new System.Windows.Forms.DataGridViewButtonColumn();
            this.filtroNumero = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.filtroEmpresa = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.listadoClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // filtroCliente
            // 
            this.filtroCliente.Location = new System.Drawing.Point(21, 109);
            this.filtroCliente.Margin = new System.Windows.Forms.Padding(4);
            this.filtroCliente.Name = "filtroCliente";
            this.filtroCliente.Size = new System.Drawing.Size(195, 22);
            this.filtroCliente.TabIndex = 56;
            this.filtroCliente.TextChanged += new System.EventHandler(this.filtrar);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(46, 355);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(141, 28);
            this.btnLimpiar.TabIndex = 55;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // listadoClientes
            // 
            this.listadoClientes.AllowUserToAddRows = false;
            this.listadoClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listadoClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Elegir});
            this.listadoClientes.Location = new System.Drawing.Point(225, 45);
            this.listadoClientes.Margin = new System.Windows.Forms.Padding(4);
            this.listadoClientes.Name = "listadoClientes";
            this.listadoClientes.Size = new System.Drawing.Size(868, 383);
            this.listadoClientes.TabIndex = 53;
            this.listadoClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listadoClientes_CellContentClick_1);
            // 
            // Elegir
            // 
            this.Elegir.HeaderText = "Elegir";
            this.Elegir.Name = "Elegir";
            this.Elegir.ReadOnly = true;
            this.Elegir.Text = "Elegir";
            this.Elegir.UseColumnTextForButtonValue = true;
            // 
            // filtroNumero
            // 
            this.filtroNumero.Location = new System.Drawing.Point(21, 285);
            this.filtroNumero.Margin = new System.Windows.Forms.Padding(4);
            this.filtroNumero.Name = "filtroNumero";
            this.filtroNumero.Size = new System.Drawing.Size(195, 22);
            this.filtroNumero.TabIndex = 52;
            this.filtroNumero.TextChanged += new System.EventHandler(this.filtrar);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 250);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(149, 17);
            this.label12.TabIndex = 50;
            this.label12.Text = "Buscar por N° Factura";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 71);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(129, 17);
            this.label13.TabIndex = 49;
            this.label13.Text = "Buscar por nombre";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(24, 159);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(136, 17);
            this.label14.TabIndex = 48;
            this.label14.Text = "Buscar por empresa";
            // 
            // filtroEmpresa
            // 
            this.filtroEmpresa.FormattingEnabled = true;
            this.filtroEmpresa.Location = new System.Drawing.Point(21, 200);
            this.filtroEmpresa.Margin = new System.Windows.Forms.Padding(4);
            this.filtroEmpresa.Name = "filtroEmpresa";
            this.filtroEmpresa.Size = new System.Drawing.Size(195, 24);
            this.filtroEmpresa.TabIndex = 57;
            this.filtroEmpresa.SelectedIndexChanged += new System.EventHandler(this.filtrar);
            // 
            // elegirFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 463);
            this.Controls.Add(this.filtroEmpresa);
            this.Controls.Add(this.filtroCliente);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.listadoClientes);
            this.Controls.Add(this.filtroNumero);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Name = "elegirFactura";
            this.Text = "Elegir Factura";
            ((System.ComponentModel.ISupportInitialize)(this.listadoClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox filtroCliente;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView listadoClientes;
        private System.Windows.Forms.DataGridViewButtonColumn Elegir;
        private System.Windows.Forms.TextBox filtroNumero;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox filtroEmpresa;
    }
}