namespace PagoAgilFrba.AbmEmpresa
{
    partial class ABMEmpresa
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
            this.comboNuevoRubro = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.textNuevoDirec = new System.Windows.Forms.TextBox();
            this.textNuevoCuit = new System.Windows.Forms.TextBox();
            this.textNuevoNombre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboModRubro = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dataGridViewModificarC = new System.Windows.Forms.DataGridView();
            this.textModCuit = new System.Windows.Forms.TextBox();
            this.textModNombre = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.comboElimRubro = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textElimCuit = new System.Windows.Forms.TextBox();
            this.textElimNombre = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dataGridEliminar = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewModificarC)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEliminar)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(623, 256);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tabPage1.Controls.Add(this.comboNuevoRubro);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnAceptar);
            this.tabPage1.Controls.Add(this.btnVolver);
            this.tabPage1.Controls.Add(this.textNuevoDirec);
            this.tabPage1.Controls.Add(this.textNuevoCuit);
            this.tabPage1.Controls.Add(this.textNuevoNombre);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(615, 230);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Agregar";
            // 
            // comboNuevoRubro
            // 
            this.comboNuevoRubro.FormattingEnabled = true;
            this.comboNuevoRubro.Location = new System.Drawing.Point(85, 94);
            this.comboNuevoRubro.Name = "comboNuevoRubro";
            this.comboNuevoRubro.Size = new System.Drawing.Size(143, 21);
            this.comboNuevoRubro.TabIndex = 43;
            this.comboNuevoRubro.SelectedIndexChanged += new System.EventHandler(this.comboNuevoRubro_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Rubro:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "C.U.I.T:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(510, 196);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 34;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(416, 196);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 33;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // textNuevoDirec
            // 
            this.textNuevoDirec.Location = new System.Drawing.Point(84, 55);
            this.textNuevoDirec.Name = "textNuevoDirec";
            this.textNuevoDirec.Size = new System.Drawing.Size(144, 20);
            this.textNuevoDirec.TabIndex = 30;
            // 
            // textNuevoCuit
            // 
            this.textNuevoCuit.Location = new System.Drawing.Point(85, 145);
            this.textNuevoCuit.Name = "textNuevoCuit";
            this.textNuevoCuit.Size = new System.Drawing.Size(143, 20);
            this.textNuevoCuit.TabIndex = 27;
            // 
            // textNuevoNombre
            // 
            this.textNuevoNombre.Location = new System.Drawing.Point(84, 12);
            this.textNuevoNombre.Name = "textNuevoNombre";
            this.textNuevoNombre.Size = new System.Drawing.Size(143, 20);
            this.textNuevoNombre.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Dirección:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Nombre:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tabPage2.Controls.Add(this.comboModRubro);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.dataGridViewModificarC);
            this.tabPage2.Controls.Add(this.textModCuit);
            this.tabPage2.Controls.Add(this.textModNombre);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(615, 230);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Modificar";
            // 
            // comboModRubro
            // 
            this.comboModRubro.FormattingEnabled = true;
            this.comboModRubro.Location = new System.Drawing.Point(129, 125);
            this.comboModRubro.Name = "comboModRubro";
            this.comboModRubro.Size = new System.Drawing.Size(147, 21);
            this.comboModRubro.TabIndex = 45;
            this.comboModRubro.SelectedValueChanged += new System.EventHandler(this.textModNombre_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "Rubro:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "C.U.I.T:";
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
            // textModCuit
            // 
            this.textModCuit.Location = new System.Drawing.Point(129, 81);
            this.textModCuit.Name = "textModCuit";
            this.textModCuit.Size = new System.Drawing.Size(147, 20);
            this.textModCuit.TabIndex = 21;
            this.textModCuit.TextChanged += new System.EventHandler(this.textModNombre_TextChanged);
            // 
            // textModNombre
            // 
            this.textModNombre.Location = new System.Drawing.Point(129, 42);
            this.textModNombre.Name = "textModNombre";
            this.textModNombre.Size = new System.Drawing.Size(147, 20);
            this.textModNombre.TabIndex = 20;
            this.textModNombre.TextChanged += new System.EventHandler(this.textModNombre_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(34, 49);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 13);
            this.label14.TabIndex = 17;
            this.label14.Text = "Nombre : ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 32);
            this.button1.TabIndex = 15;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tabPage3.Controls.Add(this.comboElimRubro);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.textElimCuit);
            this.tabPage3.Controls.Add(this.textElimNombre);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Controls.Add(this.dataGridEliminar);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage3.Size = new System.Drawing.Size(615, 230);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Eliminar";
            // 
            // comboElimRubro
            // 
            this.comboElimRubro.FormattingEnabled = true;
            this.comboElimRubro.Location = new System.Drawing.Point(129, 125);
            this.comboElimRubro.Name = "comboElimRubro";
            this.comboElimRubro.Size = new System.Drawing.Size(147, 21);
            this.comboElimRubro.TabIndex = 51;
            this.comboElimRubro.SelectedIndexChanged += new System.EventHandler(this.textElimNombre_TextChanged);
            this.comboElimRubro.TextChanged += new System.EventHandler(this.textElimNombre_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 50;
            this.label8.Text = "Rubro:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(34, 88);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 49;
            this.label11.Text = "C.U.I.T:";
            // 
            // textElimCuit
            // 
            this.textElimCuit.Location = new System.Drawing.Point(129, 81);
            this.textElimCuit.Name = "textElimCuit";
            this.textElimCuit.Size = new System.Drawing.Size(147, 20);
            this.textElimCuit.TabIndex = 48;
            this.textElimCuit.TextChanged += new System.EventHandler(this.textElimNombre_TextChanged);
            // 
            // textElimNombre
            // 
            this.textElimNombre.Location = new System.Drawing.Point(129, 42);
            this.textElimNombre.Name = "textElimNombre";
            this.textElimNombre.Size = new System.Drawing.Size(147, 20);
            this.textElimNombre.TabIndex = 47;
            this.textElimNombre.TextChanged += new System.EventHandler(this.textElimNombre_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(34, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 46;
            this.label12.Text = "Nombre : ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(34, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(157, 13);
            this.label16.TabIndex = 34;
            this.label16.Text = "Ingrese datos para filtrar la tabla";
            // 
            // dataGridEliminar
            // 
            this.dataGridEliminar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEliminar.Location = new System.Drawing.Point(292, 18);
            this.dataGridEliminar.Name = "dataGridEliminar";
            this.dataGridEliminar.Size = new System.Drawing.Size(313, 208);
            this.dataGridEliminar.TabIndex = 33;
            this.dataGridEliminar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridEliminar_CellContentClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(37, 174);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 32);
            this.button3.TabIndex = 25;
            this.button3.Text = "Volver";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ABMEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 256);
            this.Controls.Add(this.tabControl1);
            this.Name = "ABMEmpresa";
            this.Text = "ABMEmpresa";
            this.Load += new System.EventHandler(this.ABMEmpresa_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewModificarC)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEliminar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.TextBox textNuevoDirec;
        private System.Windows.Forms.TextBox textNuevoCuit;
        private System.Windows.Forms.TextBox textNuevoNombre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dataGridViewModificarC;
        private System.Windows.Forms.TextBox textModCuit;
        private System.Windows.Forms.TextBox textModNombre;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView dataGridEliminar;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboNuevoRubro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboModRubro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboElimRubro;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textElimCuit;
        private System.Windows.Forms.TextBox textElimNombre;
        private System.Windows.Forms.Label label12;

    }
}