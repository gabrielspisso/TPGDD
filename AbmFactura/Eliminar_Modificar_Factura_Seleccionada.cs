using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagoAgilFrba.formatoFecha;
namespace PagoAgilFrba.AbmFactura
{
    public partial class Eliminar_Modificar_Factura_Seleccionada : Form
    {
        public Eliminar_Modificar_Factura_Seleccionada(string numeroDeFactura)
        {
            InitializeComponent();

            DataTable tabla = BD.busqueda("select * from EL_JAPONES_SANGRANDO.Facturas where factura_numero ='" + numeroDeFactura + "'");
            txtDni.Text = BD.devolverColumna(tabla, "factura_cliente");
            txtCantidad.Text = "";
            CheckHabilitado.Checked = BD.devolverColumna(tabla, "factura_estado") == "1";
            txtEmpresa.DataSource = BD.listaDeUnCampo("Select empresa_nombre from EL_JAPONES_SANGRANDO.Empresas where empresa_estado = 1 ");
            txtEmpresa.SelectedItem = BD.consultaDeUnSoloResultado("Select empresa_nombre from EL_JAPONES_SANGRANDO.Empresas where empresa_cuit = '" + BD.devolverColumna(tabla, "factura_empresa") + "'");
            txtFactura.Text = BD.devolverColumna(tabla, "factura_numero");
            txtMonto.Text = "";
            dateVenc.Text = BD.devolverColumna(tabla, "factura_fecha_vencimiento");
            dateAlta.Text = BD.devolverColumna(tabla, "factura_fecha");
            DataTable tabla2 = BD.busqueda("select * from EL_JAPONES_SANGRANDO.Item_Factura where item_factura ='" + numeroDeFactura + "'");
            foreach (DataRow eachItem in tabla2.Rows)
            {
               
                string[] row = { eachItem["item_cantidad"].ToString(), eachItem["item_monto"].ToString()};
                var listViewItem = new ListViewItem(row);
                listaSeleccionados.Items.Add(listViewItem);
            }
            actualizarlabel(null,null);

            
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            string queryEliminarfacturas = "Delete from EL_JAPONES_SANGRANDO.Item_Factura where item_factura = " + txtFactura.Text;
            double sum = 0;
            string query = "INSERT INTO EL_JAPONES_SANGRANDO.Item_Factura (item_monto, item_cantidad, item_factura) VALUES "; 
            foreach (ListViewItem eachItem in listaSeleccionados.Items)
            {
                double cantidad = Double.Parse(eachItem.SubItems[1].Text);
                query += "(" + eachItem.SubItems[0].Text + "," + cantidad+ ",'" + txtFactura.Text + "'),";
                sum += Double.Parse(eachItem.SubItems[0].Text) * Double.Parse(eachItem.SubItems[1].Text);
            }
            query = query.Substring(0, query.Length - 1);
            formatoFecha.formatoFecha.SetMyCustomFormatYYYYMMDD(dateAlta);
            formatoFecha.formatoFecha.SetMyCustomFormatYYYYMMDD(dateVenc);
            string empresa = BD.consultaDeUnSoloResultado("(select TOP 1 empresa_cuit from EL_JAPONES_SANGRANDO.Empresas where empresa_nombre = '" + txtEmpresa.Text + "')");
            int x = CheckHabilitado.Checked ? 1 : 0;

            string queryFactura = "UPDATE EL_JAPONES_SANGRANDO.Facturas SET factura_estado = '"+ x + "', factura_Empresa = '" + empresa + "', factura_cliente = '" + txtDni.Text + "', factura_fecha = '" + dateAlta.Text + "', factura_fecha_vencimiento = '" + dateVenc.Text + "', factura_total ='"+ sum+"' where factura_numero ='"
                                    + txtFactura.Text+"'";
                                    

            
                List<String> listaDeStrings = new List<string>();
                listaDeStrings.Add(queryFactura);
                listaDeStrings.Add(queryEliminarfacturas);
                listaDeStrings.Add(query);
                if (BD.correrStoreProcedure(listaDeStrings) > 0)
                {
                        MessageBox.Show("Se modifico correctamente");
                   
                }
                else
                {
                       MessageBox.Show("No se pudo modificar la factura, revise los datos ingresados");
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
                try
                {
                    Int32.Parse(txtMonto.Text);
                    Int32.Parse(txtCantidad.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ingrese valores numericos para el monto y la cantidad");
                    return;
                }
                string[] row = { txtMonto.Text, txtCantidad.Text };
                var listViewItem = new ListViewItem(row);
                listaSeleccionados.Items.Add(listViewItem);
                txtMonto.Text = "";
                txtCantidad.Text = "";
            }
            else
            {
                MessageBox.Show("Complete todos los campos");
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

        private void txtEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
