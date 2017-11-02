using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmFactura
{
    public partial class ABMFactura : Form
    {
        public ABMFactura()
        {
            InitializeComponent();
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            IniciarSesion.AccionesAdmin accion_ADMIN = new IniciarSesion.AccionesAdmin();
            IniciarSesion.Acciones accion = new IniciarSesion.Acciones();
            accion_ADMIN.Show();
            accion.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            IniciarSesion.AccionesAdmin accion_ADMIN = new IniciarSesion.AccionesAdmin();
            IniciarSesion.Acciones accion = new IniciarSesion.Acciones();
            accion_ADMIN.Show();
            accion.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            IniciarSesion.AccionesAdmin accion_ADMIN = new IniciarSesion.AccionesAdmin();
            IniciarSesion.Acciones accion = new IniciarSesion.Acciones();
            accion_ADMIN.Show();
            accion.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listaSeleccionados.SelectedItems)
            {
                listaSeleccionados.Items.Remove(eachItem);
            }
        }

        private void ABMFactura_Load(object sender, EventArgs e)
        {
            txtEmpresa.DataSource = BD.listaDeUnCampo("select emp_nombre from EL_JAPONES_SANGRANDO.Empresas");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtMonto.Text != "" && txtCantidad.Text != "")
            {
                string[] row = { txtMonto.Text, txtCantidad.Text };
                var listViewItem = new ListViewItem(row);
                listaSeleccionados.Items.Add(listViewItem);
                txtMonto.Text = "";
                txtCantidad.Text = "";
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {




            double sum = 0;
            string query = "INSERT INTO EL_JAPONES_SANGRANDO.ItemFactura (itemfact_monto, itemfact_cantidad, itemfact_factura) VALUES "; 
            foreach (ListViewItem eachItem in listaSeleccionados.Items)
            {
                query += "(" + eachItem.SubItems[0].Text + "," + eachItem.SubItems[1].Text + ",'" + txtFactura.Text + "'),";
                sum += Double.Parse(eachItem.SubItems[0].Text) * Double.Parse(eachItem.SubItems[1].Text);
            }
            query = query.Substring(0, query.Length - 1);

            string empresa = BD.consultaDeUnSoloResultado("(select TOP 1 emp_CUIT from EL_JAPONES_SANGRANDO.Empresas where emp_nombre = '" + txtEmpresa.Text + "')");

            string queryFactura = "INSERT INTO EL_JAPONES_SANGRANDO.Facturas (fact_num,fact_empresa, fact_cliente, fact_fechaalta, fact_fechavenc, fact_total) values ('"
                                    + txtFactura.Text + "','"
                                    + empresa + "','"
                                    + txtDni.Text + "','"
                                    + dateAlta.Text + "','"
                                    + dateVenc.Text + "',"
                                    + sum + ")";

            if (BD.ABM(queryFactura) > 0)
            {
                if (BD.ABM(query) > 0)
                {
                    MessageBox.Show("Todo bien papu");
                }
                else
                {
                    BD.ABM("DELETE FROM EL_JAPONES_SANGRANDO.Facturas where fact_num = '" + txtFactura.Text + "'");
                    MessageBox.Show("todo mal con los items");
                }
            }
            else
            {
                MessageBox.Show("todo mal con las facturas");
            }
        }
    }
}
