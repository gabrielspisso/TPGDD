namespace PagoAgilFrba.Sucursal
{
    partial class ABMSucursal
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridViewModificarC = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textAgregarCodigoPostal = new System.Windows.Forms.TextBox();
            this.textAgregarDireccion = new System.Windows.Forms.TextBox();
            this.textAgregarNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.DatagridViewEliminar = new System.Windows.Forms.DataGridView();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewModificarC)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DatagridViewEliminar)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tabPage2.Controls.Add(this.dataGridViewModificarC);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(823, 286);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Modificar";
            // 
            // dataGridViewModificarC
            // 
            this.dataGridViewModificarC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewModificarC.Location = new System.Drawing.Point(8, 8);
            this.dataGridViewModificarC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewModificarC.Name = "dataGridViewModificarC";
            this.dataGridViewModificarC.Size = new System.Drawing.Size(807, 269);
            this.dataGridViewModificarC.TabIndex = 23;
            this.dataGridViewModificarC.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewModificarC_CellContentClick);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tabPage1.Controls.Add(this.textAgregarCodigoPostal);
            this.tabPage1.Controls.Add(this.textAgregarDireccion);
            this.tabPage1.Controls.Add(this.textAgregarNombre);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.btnAceptar);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(823, 286);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Agregar";
            // 
            // textAgregarCodigoPostal
            // 
            this.textAgregarCodigoPostal.Location = new System.Drawing.Point(153, 114);
            this.textAgregarCodigoPostal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textAgregarCodigoPostal.Name = "textAgregarCodigoPostal";
            this.textAgregarCodigoPostal.Size = new System.Drawing.Size(191, 22);
            this.textAgregarCodigoPostal.TabIndex = 43;
            // 
            // textAgregarDireccion
            // 
            this.textAgregarDireccion.Location = new System.Drawing.Point(153, 68);
            this.textAgregarDireccion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textAgregarDireccion.Name = "textAgregarDireccion";
            this.textAgregarDireccion.Size = new System.Drawing.Size(191, 22);
            this.textAgregarDireccion.TabIndex = 30;
            // 
            // textAgregarNombre
            // 
            this.textAgregarNombre.Location = new System.Drawing.Point(153, 15);
            this.textAgregarNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textAgregarNombre.Name = "textAgregarNombre";
            this.textAgregarNombre.Size = new System.Drawing.Size(189, 22);
            this.textAgregarNombre.TabIndex = 26;
            this.textAgregarNombre.TextChanged += new System.EventHandler(this.textNombre_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 118);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 17);
            this.label3.TabIndex = 42;
            this.label3.Text = "Codigo Postal:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(221, 174);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 28);
            this.btnAceptar.TabIndex = 34;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 68);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 17);
            this.label6.TabIndex = 24;
            this.label6.Text = "Dirección:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "Nombre:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(1, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(831, 315);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tabPage3.Controls.Add(this.DatagridViewEliminar);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Size = new System.Drawing.Size(823, 286);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Eliminar";
            // 
            // DatagridViewEliminar
            // 
            this.DatagridViewEliminar.AllowUserToAddRows = false;
            this.DatagridViewEliminar.AllowUserToDeleteRows = false;
            this.DatagridViewEliminar.AllowUserToResizeRows = false;
            this.DatagridViewEliminar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DatagridViewEliminar.Location = new System.Drawing.Point(8, 8);
            this.DatagridViewEliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DatagridViewEliminar.Name = "DatagridViewEliminar";
            this.DatagridViewEliminar.Size = new System.Drawing.Size(807, 269);
            this.DatagridViewEliminar.TabIndex = 23;
            this.DatagridViewEliminar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DatagridViewEliminar_CellContentClick);
            // 
            // ABMSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 315);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ABMSucursal";
            this.Text = "ABMSucursal";
            this.Load += new System.EventHandler(this.ABMSucursal_Load);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewModificarC)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DatagridViewEliminar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridViewModificarC;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textAgregarCodigoPostal;
        private System.Windows.Forms.TextBox textAgregarDireccion;
        private System.Windows.Forms.TextBox textAgregarNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView DatagridViewEliminar;

    }
}