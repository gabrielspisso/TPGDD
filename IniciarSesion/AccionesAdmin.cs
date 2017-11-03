using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.IniciarSesion
{
    public partial class AccionesAdmin : Form
    {
        public AccionesAdmin()
        {
            InitializeComponent();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string fact_num = textFacturaDev.Text;
            string motivo = richTextDev.Text;

            if (fact_num != "" && motivo != "")
            {
                DataTable dt = BD.busqueda("SELECT fact_estado FROM EL_JAPONES_SANGRANDO.Facturas WHERE fact_num = " + fact_num);
                int fact_estado = Int32.Parse(BD.devolverColumna(dt, "fact_estado"));
                if (fact_estado != 2)
                {
                    string razon = (fact_estado == 1) ? "no se ha pagado" : (fact_estado == 3) ? "ya se ha rendido" : "se ha eliminado";
                    MessageBox.Show("Esta factura no puede devolverse debido a que " + razon, "Al pique quique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    List<string> queries = new List<string>();
                    string insert = "INSERT INTO EL_JAPONES_SANGRANDO.Devoluciones (dev_desc,dev_fact)values('" + motivo + "'," + fact_num + ")";
                    string update = "UPDATE EL_JAPONES_SANGRANDO.Facturas SET fact_estado = 1 WHERE fact_num = " + fact_num;
                    queries.Add(insert);
                    queries.Add(update);
                    if (BD.correrStoreProcedure(queries) > 0)
                    {
                        MessageBox.Show("Factura devuelta", "Al pique quique", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo devolver la factura", "Al pique quique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe Completar ambos campos", "Al pique quique", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbmCliente.ABMCliente abmCliente = new AbmCliente.ABMCliente();
            this.Hide();
            abmCliente.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbmEmpresa.ABMEmpresa abmEmpresa = new AbmEmpresa.ABMEmpresa();
            this.Hide();
            abmEmpresa.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AbmRol.ABMRol abmRol = new AbmRol.ABMRol();
            this.Hide();
            abmRol.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbmFactura.ABMFactura abmFactura = new AbmFactura.ABMFactura();
            this.Hide();
            abmFactura.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Sucursal.ABMSucursal abmSucursal = new Sucursal.ABMSucursal();
            this.Hide();
            abmSucursal.Show();
        }
    }
}
