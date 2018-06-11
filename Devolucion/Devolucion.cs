using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.Devolucion
{
    public partial class Devolucion : Form, seleccionarFactura
    {
        public Devolucion()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string factura_numero = textFacturaDev.Text;
            string motivo = richTextDev.Text;

            if (factura_numero != "" && motivo != "")
            {
                string x = BD.estadoFactura(factura_numero);
                if (x == "")
                {
                    MessageBox.Show("Esta factura no existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int factura_estado = Int32.Parse(x);
                if (factura_estado != 2)
                {
                    string razon = (factura_estado == 1) ? "no se ha pagado" : (factura_estado == 3) ? "ya se ha rendido" : "se ha eliminado";
                    MessageBox.Show("Esta factura no puede devolverse debido a que " + razon, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (BD.devolverFactura(factura_numero, motivo))
                    {
                        MessageBox.Show("Factura devuelta", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textFacturaDev.Text = "";
                        richTextDev.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("No se pudo devolver la factura", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else
            {
                MessageBox.Show("Debe Completar ambos campos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void setFactura(string factura)
        {
            textFacturaDev.Text = factura;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new IniciarSesion.elegirFactura(this, true).ShowDialog();
            this.Show();
        }

        private void Devolucion_Load(object sender, EventArgs e)
        {

        }
    }
}
