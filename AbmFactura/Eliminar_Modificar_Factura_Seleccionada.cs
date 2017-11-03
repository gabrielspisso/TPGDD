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
    public partial class Eliminar_Modificar_Factura_Seleccionada : Form
    {
        public Eliminar_Modificar_Factura_Seleccionada(string numeroDeFactura)
        {
            InitializeComponent();

            DataTable tabla = BD.busqueda("select * from EL_JAPONES_SANGRANDO.Facturas where fact_num ='" + numeroDeFactura + "'");
            txtDni.Text = BD.devolverColumna(tabla, "fact_cliente");
            txtCantidad.Text = "";
            txtEmpresa.Text = BD.consultaDeUnSoloResultado("Select emp_nombre from EL_JAPONES_SANGRANDO.Empresas where emp_CUIT = '"+BD.devolverColumna(tabla, "fact_empresa")+"'");
            txtFactura.Text = BD.devolverColumna(tabla, "fact_num");
            txtMonto.Text = "";
            dateVenc.Text = BD.devolverColumna(tabla, "fact_fechavenc");
            dateAlta.Text = BD.devolverColumna(tabla, "fact_fechaalta");
            DataTable tabla2 = BD.busqueda("select * from EL_JAPONES_SANGRANDO.ItemFactura where itemfact_factura ='" + numeroDeFactura + "'");
            foreach (DataRow eachItem in tabla2.Rows)
            {
               
                string[] row = { eachItem["itemfact_cantidad"].ToString(), eachItem["itemfact_monto"].ToString()};
                var listViewItem = new ListViewItem(row);
                listaSeleccionados.Items.Add(listViewItem);
            }

            
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            string queryEliminarfacturas = "Delete from EL_JAPONES_SANGRANDO.ItemFactura where itemfact_factura = " + txtFactura.Text;
            double sum = 0;
            string query = "INSERT INTO EL_JAPONES_SANGRANDO.ItemFactura (itemfact_monto, itemfact_cantidad, itemfact_factura) VALUES "; 
            foreach (ListViewItem eachItem in listaSeleccionados.Items)
            {
                double cantidad = Double.Parse(eachItem.SubItems[1].Text);
                query += "(" + eachItem.SubItems[0].Text + "," + cantidad+ ",'" + txtFactura.Text + "'),";
                sum += Double.Parse(eachItem.SubItems[0].Text) * Double.Parse(eachItem.SubItems[1].Text);
            }
            query = query.Substring(0, query.Length - 1);

            string empresa = BD.consultaDeUnSoloResultado("(select TOP 1 emp_CUIT from EL_JAPONES_SANGRANDO.Empresas where emp_nombre = '" + txtEmpresa.Text + "')");

            string queryFactura = "UPDATE EL_JAPONES_SANGRANDO.Facturas SET fact_empresa = '" + empresa + "', fact_cliente = '" + txtDni.Text + "', fact_fechaalta = " + dateAlta.Text + ", fact_fechavenc = " + dateVenc.Text + ", fact_total ='"+ sum+"' where fact_num ='"
                                    + txtFactura.Text+"'";
                                    

            
                List<String> listaDeStrings = new List<string>();
                listaDeStrings.Add(queryFactura);
                listaDeStrings.Add(queryEliminarfacturas);
                listaDeStrings.Add(query);
                List<String> listaDeStrings2 = new List<string>();
                listaDeStrings2.Add("@query");
                listaDeStrings2.Add("@query2");
                listaDeStrings2.Add("@query3");
                if (BD.correrStoreProcedure("EL_JAPONES_SANGRANDO.cambiarItems",listaDeStrings2,listaDeStrings) > 0)
                {
                        MessageBox.Show("Todo bien papu");
                   
                }
                else
                {
                       MessageBox.Show("todo mal con los items");
                }
           
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listaSeleccionados.SelectedItems)
            {
                listaSeleccionados.Items.Remove(eachItem);
            }
            actualizarlabel(null, null);
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
            actualizarlabel(null,null);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {

        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {

        }

        private void cargarlabel(object sender, EventArgs e)
        {

        }

        private void actualizarlabel(object sender, EventArgs e)
        {
            double sum = 0;
           foreach (ListViewItem eachItem in listaSeleccionados.Items)
            {
               sum += Double.Parse(eachItem.SubItems[0].Text) * Double.Parse(eachItem.SubItems[1].Text);
            }
           label4.Text = "Total: "+sum.ToString();
        }

        private void listaSeleccionados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
