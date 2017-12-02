namespace PagoAgilFrba.AbmRol
{
    partial class ABMRol
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
            this.funcionalidadesDGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRolAgregar = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRol = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboModificar = new System.Windows.Forms.ComboBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.dataGridFuncModificar = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.comboEliminar = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.funcionalidadesDGV)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFuncModificar)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(1, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 315);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tabPage1.Controls.Add(this.funcionalidadesDGV);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtRolAgregar);
            this.tabPage1.Controls.Add(this.btnAceptar);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(768, 286);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Agregar";
            // 
            // funcionalidadesDGV
            // 
            this.funcionalidadesDGV.AllowUserToAddRows = false;
            this.funcionalidadesDGV.AllowUserToDeleteRows = false;
            this.funcionalidadesDGV.Location = new System.Drawing.Point(27, 89);
            this.funcionalidadesDGV.Margin = new System.Windows.Forms.Padding(4);
            this.funcionalidadesDGV.Name = "funcionalidadesDGV";
            this.funcionalidadesDGV.ReadOnly = true;
            this.funcionalidadesDGV.Size = new System.Drawing.Size(461, 185);
            this.funcionalidadesDGV.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 17);
            this.label1.TabIndex = 36;
            this.label1.Text = "Ingrese el nombre del rol";
            // 
            // txtRolAgregar
            // 
            this.txtRolAgregar.Location = new System.Drawing.Point(211, 37);
            this.txtRolAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.txtRolAgregar.Name = "txtRolAgregar";
            this.txtRolAgregar.Size = new System.Drawing.Size(204, 22);
            this.txtRolAgregar.TabIndex = 35;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(597, 245);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 28);
            this.btnAceptar.TabIndex = 34;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txtRol);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.comboModificar);
            this.tabPage2.Controls.Add(this.checkBox2);
            this.tabPage2.Controls.Add(this.dataGridFuncModificar);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(768, 286);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Modificar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(519, 128);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 17);
            this.label4.TabIndex = 42;
            this.label4.Text = "Ingrese nuevo nombre del rol";
            // 
            // txtRol
            // 
            this.txtRol.Location = new System.Drawing.Point(557, 167);
            this.txtRol.Margin = new System.Windows.Forms.Padding(4);
            this.txtRol.Name = "txtRol";
            this.txtRol.Size = new System.Drawing.Size(132, 22);
            this.txtRol.TabIndex = 41;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(572, 223);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 40;
            this.button1.Text = "Modificar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // comboModificar
            // 
            this.comboModificar.FormattingEnabled = true;
            this.comboModificar.Location = new System.Drawing.Point(195, 34);
            this.comboModificar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboModificar.Name = "comboModificar";
            this.comboModificar.Size = new System.Drawing.Size(152, 24);
            this.comboModificar.TabIndex = 39;
            this.comboModificar.SelectedIndexChanged += new System.EventHandler(this.comboModificar_SelectedIndexChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AllowDrop = true;
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(491, 33);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(93, 21);
            this.checkBox2.TabIndex = 38;
            this.checkBox2.Text = "Habilitado";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // dataGridFuncModificar
            // 
            this.dataGridFuncModificar.AllowUserToAddRows = false;
            this.dataGridFuncModificar.AllowUserToDeleteRows = false;
            this.dataGridFuncModificar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFuncModificar.Location = new System.Drawing.Point(27, 89);
            this.dataGridFuncModificar.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridFuncModificar.Name = "dataGridFuncModificar";
            this.dataGridFuncModificar.ReadOnly = true;
            this.dataGridFuncModificar.Size = new System.Drawing.Size(461, 185);
            this.dataGridFuncModificar.TabIndex = 37;
            this.dataGridFuncModificar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridFuncModificar_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 17);
            this.label2.TabIndex = 36;
            this.label2.Text = "seleccione rol a modificar";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tabPage3.Controls.Add(this.comboEliminar);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(768, 286);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Eliminar";
            // 
            // comboEliminar
            // 
            this.comboEliminar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboEliminar.FormattingEnabled = true;
            this.comboEliminar.Location = new System.Drawing.Point(401, 73);
            this.comboEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.comboEliminar.Name = "comboEliminar";
            this.comboEliminar.Size = new System.Drawing.Size(211, 33);
            this.comboEliminar.TabIndex = 45;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(157, 76);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 25);
            this.label3.TabIndex = 44;
            this.label3.Text = "Elija el nombre del rol";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(278, 174);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(187, 40);
            this.button3.TabIndex = 43;
            this.button3.Text = "Eliminar";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // ABMRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 315);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ABMRol";
            this.Text = "ABMRol";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.funcionalidadesDGV)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFuncModificar)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView funcionalidadesDGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRolAgregar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox comboModificar;
        private System.Windows.Forms.DataGridView dataGridFuncModificar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRol;
        private System.Windows.Forms.ComboBox comboEliminar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
    }
}