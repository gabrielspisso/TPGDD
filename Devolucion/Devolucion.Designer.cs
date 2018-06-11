namespace PagoAgilFrba.Devolucion
{
    partial class Devolucion
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
            this.button2 = new System.Windows.Forms.Button();
            this.textFacturaDev = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.richTextDev = new System.Windows.Forms.RichTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(412, 44);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 25);
            this.button2.TabIndex = 37;
            this.button2.Text = "Seleccionar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textFacturaDev
            // 
            this.textFacturaDev.Location = new System.Drawing.Point(192, 44);
            this.textFacturaDev.Margin = new System.Windows.Forms.Padding(4);
            this.textFacturaDev.Name = "textFacturaDev";
            this.textFacturaDev.Size = new System.Drawing.Size(197, 22);
            this.textFacturaDev.TabIndex = 36;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(401, 244);
            this.button8.Margin = new System.Windows.Forms.Padding(4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(157, 28);
            this.button8.TabIndex = 35;
            this.button8.Text = "Generar Devolución";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // richTextDev
            // 
            this.richTextDev.Location = new System.Drawing.Point(192, 106);
            this.richTextDev.Margin = new System.Windows.Forms.Padding(4);
            this.richTextDev.Name = "richTextDev";
            this.richTextDev.Size = new System.Drawing.Size(366, 117);
            this.richTextDev.TabIndex = 34;
            this.richTextDev.Text = "";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(63, 109);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(49, 17);
            this.label19.TabIndex = 33;
            this.label19.Text = "Motivo";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(63, 47);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(56, 17);
            this.label20.TabIndex = 32;
            this.label20.Text = "Factura";
            // 
            // Devolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 317);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textFacturaDev);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.richTextDev);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Name = "Devolucion";
            this.Text = "Devolucion";
            this.Load += new System.EventHandler(this.Devolucion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textFacturaDev;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.RichTextBox richTextDev;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;

    }
}