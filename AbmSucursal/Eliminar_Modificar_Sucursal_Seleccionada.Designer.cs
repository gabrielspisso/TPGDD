namespace PagoAgilFrba.Sucursal
{
    partial class Eliminar_Modificar_Sucursal_Seleccionada
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
            this.textDireccion = new System.Windows.Forms.TextBox();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.CheckHabilitado = new System.Windows.Forms.CheckBox();
            this.TextModificarCodigoPostal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textDireccion
            // 
            this.textDireccion.Location = new System.Drawing.Point(111, 58);
            this.textDireccion.Name = "textDireccion";
            this.textDireccion.Size = new System.Drawing.Size(144, 20);
            this.textDireccion.TabIndex = 34;
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(112, 19);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(143, 20);
            this.textNombre.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Dirección:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "Codigo Postal:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 185);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 53;
            this.label8.Text = "Habilitado";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(182, 233);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 25);
            this.button3.TabIndex = 55;
            this.button3.Text = "Modificar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // CheckHabilitado
            // 
            this.CheckHabilitado.AllowDrop = true;
            this.CheckHabilitado.AutoSize = true;
            this.CheckHabilitado.Location = new System.Drawing.Point(134, 185);
            this.CheckHabilitado.Name = "CheckHabilitado";
            this.CheckHabilitado.Size = new System.Drawing.Size(73, 17);
            this.CheckHabilitado.TabIndex = 56;
            this.CheckHabilitado.Text = "Habilitado";
            this.CheckHabilitado.UseVisualStyleBackColor = true;
            // 
            // TextModificarCodigoPostal
            // 
            this.TextModificarCodigoPostal.AutoSize = true;
            this.TextModificarCodigoPostal.Location = new System.Drawing.Point(139, 137);
            this.TextModificarCodigoPostal.Name = "TextModificarCodigoPostal";
            this.TextModificarCodigoPostal.Size = new System.Drawing.Size(10, 13);
            this.TextModificarCodigoPostal.TabIndex = 57;
            this.TextModificarCodigoPostal.Text = " ";
            // 
            // Eliminar_Modificar_Sucursal_Seleccionada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 271);
            this.Controls.Add(this.TextModificarCodigoPostal);
            this.Controls.Add(this.CheckHabilitado);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textDireccion);
            this.Controls.Add(this.textNombre);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Name = "Eliminar_Modificar_Sucursal_Seleccionada";
            this.Text = "Eliminar_Modificar_Sucursal_Seleccionada";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textDireccion;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox CheckHabilitado;
        private System.Windows.Forms.Label TextModificarCodigoPostal;
    }
}