namespace PagoAgilFrba.AbmCliente
{
    partial class ABMCliente
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
            this.textCodigoPostal = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.dateTimePickerFechaNac = new System.Windows.Forms.DateTimePicker();
            this.textDireccion = new System.Windows.Forms.TextBox();
            this.textMail = new System.Windows.Forms.TextBox();
            this.textDni = new System.Windows.Forms.TextBox();
            this.textApellido = new System.Windows.Forms.TextBox();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataViewModificar = new System.Windows.Forms.DataGridView();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label16 = new System.Windows.Forms.Label();
            this.datagridEliminar = new System.Windows.Forms.DataGridView();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewModificar)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridEliminar)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(623, 256);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tabPage1.Controls.Add(this.textCodigoPostal);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.btnAceptar);
            this.tabPage1.Controls.Add(this.btnVolver);
            this.tabPage1.Controls.Add(this.dateTimePickerFechaNac);
            this.tabPage1.Controls.Add(this.textDireccion);
            this.tabPage1.Controls.Add(this.textMail);
            this.tabPage1.Controls.Add(this.textDni);
            this.tabPage1.Controls.Add(this.textApellido);
            this.tabPage1.Controls.Add(this.textNombre);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(615, 230);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Agregar";
            // 
            // textCodigoPostal
            // 
            this.textCodigoPostal.Location = new System.Drawing.Point(372, 81);
            this.textCodigoPostal.Name = "textCodigoPostal";
            this.textCodigoPostal.Size = new System.Drawing.Size(143, 20);
            this.textCodigoPostal.TabIndex = 42;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(295, 84);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 13);
            this.label11.TabIndex = 41;
            this.label11.Text = "Codigo Postal:";
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
            // dateTimePickerFechaNac
            // 
            this.dateTimePickerFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFechaNac.Location = new System.Drawing.Point(135, 166);
            this.dateTimePickerFechaNac.Name = "dateTimePickerFechaNac";
            this.dateTimePickerFechaNac.Size = new System.Drawing.Size(143, 20);
            this.dateTimePickerFechaNac.TabIndex = 32;
            // 
            // textDireccion
            // 
            this.textDireccion.Location = new System.Drawing.Point(84, 81);
            this.textDireccion.Name = "textDireccion";
            this.textDireccion.Size = new System.Drawing.Size(144, 20);
            this.textDireccion.TabIndex = 30;
            // 
            // textMail
            // 
            this.textMail.Location = new System.Drawing.Point(372, 52);
            this.textMail.Name = "textMail";
            this.textMail.Size = new System.Drawing.Size(143, 20);
            this.textMail.TabIndex = 29;
            // 
            // textDni
            // 
            this.textDni.Location = new System.Drawing.Point(84, 48);
            this.textDni.Name = "textDni";
            this.textDni.Size = new System.Drawing.Size(144, 20);
            this.textDni.TabIndex = 28;
            // 
            // textApellido
            // 
            this.textApellido.Location = new System.Drawing.Point(372, 16);
            this.textApellido.Name = "textApellido";
            this.textApellido.Size = new System.Drawing.Size(143, 20);
            this.textApellido.TabIndex = 27;
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(84, 12);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(143, 20);
            this.textNombre.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 166);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Fecha de Nacimiento:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Dirección:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(295, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Mail:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "D.N.I.:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(295, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Apellido:";
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
            this.tabPage2.Controls.Add(this.dataViewModificar);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.textBox5);
            this.tabPage2.Controls.Add(this.textBox6);
            this.tabPage2.Controls.Add(this.textBox7);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(615, 230);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Modificar";
            // 
            // dataViewModificar
            // 
            this.dataViewModificar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataViewModificar.Location = new System.Drawing.Point(298, 6);
            this.dataViewModificar.Name = "dataViewModificar";
            this.dataViewModificar.Size = new System.Drawing.Size(313, 208);
            this.dataViewModificar.TabIndex = 34;
            this.dataViewModificar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataViewModificar_CellContentClick);
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
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(129, 122);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(147, 20);
            this.textBox5.TabIndex = 22;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(129, 81);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(147, 20);
            this.textBox6.TabIndex = 21;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(129, 42);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(147, 20);
            this.textBox7.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(34, 125);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "DNI :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(34, 88);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 13);
            this.label13.TabIndex = 18;
            this.label13.Text = "Apellido : ";
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
            this.button1.Location = new System.Drawing.Point(129, 173);
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
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Controls.Add(this.datagridEliminar);
            this.tabPage3.Controls.Add(this.textBox8);
            this.tabPage3.Controls.Add(this.textBox9);
            this.tabPage3.Controls.Add(this.textBox10);
            this.tabPage3.Controls.Add(this.label17);
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Controls.Add(this.label19);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(615, 230);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Eliminar";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(34, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(157, 13);
            this.label16.TabIndex = 34;
            this.label16.Text = "Ingrese datos para filtrar la tabla";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // datagridEliminar
            // 
            this.datagridEliminar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridEliminar.Location = new System.Drawing.Point(295, 13);
            this.datagridEliminar.Name = "datagridEliminar";
            this.datagridEliminar.Size = new System.Drawing.Size(313, 208);
            this.datagridEliminar.TabIndex = 33;
            this.datagridEliminar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(129, 122);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(147, 20);
            this.textBox8.TabIndex = 32;
            this.textBox8.TextChanged += new System.EventHandler(this.textBox8_TextChanged);
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(129, 81);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(147, 20);
            this.textBox9.TabIndex = 31;
            this.textBox9.TextChanged += new System.EventHandler(this.textBox9_TextChanged);
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(129, 42);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(147, 20);
            this.textBox10.TabIndex = 30;
            this.textBox10.TextChanged += new System.EventHandler(this.textBox10_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(34, 125);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 13);
            this.label17.TabIndex = 29;
            this.label17.Text = "DNI :";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(34, 88);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 13);
            this.label18.TabIndex = 28;
            this.label18.Text = "Apellido : ";
            this.label18.Click += new System.EventHandler(this.label18_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(34, 49);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 13);
            this.label19.TabIndex = 27;
            this.label19.Text = "Nombre : ";
            this.label19.Click += new System.EventHandler(this.label19_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(105, 177);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 32);
            this.button3.TabIndex = 25;
            this.button3.Text = "Volver";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ABMCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(625, 256);
            this.Controls.Add(this.tabControl1);
            this.Name = "ABMCliente";
            this.Text = "ABMCliente";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewModificar)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridEliminar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaNac;
        private System.Windows.Forms.TextBox textDireccion;
        private System.Windows.Forms.TextBox textMail;
        private System.Windows.Forms.TextBox textDni;
        private System.Windows.Forms.TextBox textApellido;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textCodigoPostal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView datagridEliminar;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataViewModificar;
    }
}