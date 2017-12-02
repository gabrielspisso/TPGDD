using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.Rendicion
{
    public partial class Rendicion : Form
    {
        public Rendicion()
        {
            InitializeComponent();
            comboPorcentaje.SelectedIndex = 0;
            DateTime fechaActual = BD.fechaActual();
            dateRendicion1.MinDate = new DateTime(fechaActual.Year, fechaActual.Month, 1);
            dateRendicion1.MaxDate = (new DateTime(fechaActual.Year, fechaActual.Month, 1)).AddMonths(1).AddDays(-1);
            dateRendicion1.Value = BD.fechaActual();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboEmpresa.Text == "")
            {
                MessageBox.Show("Debe seleccionar una empresa", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            String fecharendicion = dateRendicion1.Value.ToString("u");
            fecharendicion = fecharendicion.Substring(0, fecharendicion.Length - 1);
            if (BD.seRindioEsteMes(dateRendicion1.Value.Month, dateRendicion1.Value.Year, comboEmpresa.Text))
            {
                MessageBox.Show("Esta empresa ya rindio en este mes", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (dataGridRendiciones.Rows.Count == 1)//El data grid automaticamente rellena automaticamente una fila vacia al final
            {
                MessageBox.Show("No hay facturas para realizar la rendicion");
                return;
            }

            if (BD.actualizarFacturasRendicion(dateRendicion1, comboEmpresa.Text, lblImporte.Text, comboPorcentaje.Text, lblCantFacturas.Text, lblGanancia.Text, dataGridRendiciones))
            {
                MessageBox.Show("Rendicion registrada");
                comboEmpresa_SelectedIndexChanged(null, null);
                lblCantFacturas.Text = "0";
                lblGanancia.Text = "0";
                lblImporte.Text = "0";
            }
            else
            {
                MessageBox.Show("No se pudo realizar la rendicion");
            }
        }

        private void comboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCantFacturas.Text = "0";
            lblGanancia.Text = "0";
            lblImporte.Text = "0";
            if (comboEmpresa.Text == "")
            {
                dataGridRendiciones.DataSource = null;
                return;
            }

            DateTime fechaActual = BD.fechaActual();
            dataGridRendiciones.DataSource = BD.facturasCobradasDeEmpresa(fechaActual, comboEmpresa.Text);


            double porcentaje = double.Parse(comboPorcentaje.Text) / 100;
            DataTable dt = BD.facturasTotalGanancias(fechaActual, porcentaje, comboEmpresa.Text);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                lblCantFacturas.Text = row["cantidad_facturas"].ToString();
                lblImporte.Text = row["total"].ToString();
                lblGanancia.Text = row["ganancia"].ToString();
            }
        }

        private void Rendicion_Load(object sender, EventArgs e)
        {
            comboEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPorcentaje.DropDownStyle = ComboBoxStyle.DropDownList;
            List<string> empresas = BD.empresasActivasConNombre();
            empresas.Insert(0, "");
            comboEmpresa.DataSource = empresas;
        }
    }
}
