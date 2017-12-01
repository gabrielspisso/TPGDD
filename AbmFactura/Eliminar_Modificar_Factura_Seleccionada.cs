using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            DataTable tabla = BD.factura(numeroDeFactura);
            txtDni.Text = BD.devolverColumna(tabla, "factura_cliente");
            txtCantidad.Text = "";
            CheckHabilitado.Checked = BD.devolverColumna(tabla, "factura_estado") == "1";
            txtEmpresa.DataSource = BD.empresasActivas();
            txtEmpresa.SelectedItem = BD.nombreEmpresa(BD.devolverColumna(tabla, "factura_empresa"));
            txtFactura.Text = BD.devolverColumna(tabla, "factura_numero");
            txtMonto.Text = "";
            dateVenc.Text = BD.devolverColumna(tabla, "factura_fecha_vencimiento");
            dateAlta.Text = BD.devolverColumna(tabla, "factura_fecha");
            DataTable tabla2 = BD.items(numeroDeFactura);
            foreach (DataRow eachItem in tabla2.Rows)
            {
               
                string[] row = { eachItem["item_cantidad"].ToString(), eachItem["item_monto"].ToString()};
                var listViewItem = new ListViewItem(row);
                listaSeleccionados.Items.Add(listViewItem);
            }
            actualizarlabel(null,null);

            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"^[0-9]+$");

            if (!reg.IsMatch(txtDni.Text))
            {
                MessageBox.Show("El dni tiene caracteres invalidos");
                return;
            }
            if (DateTime.Compare(dateAlta.Value, dateVenc.Value) < 1)
            {
                MessageBox.Show("La fecha de vencimiento es posterior a la de alta");
                return;
            }
            if (!reg.IsMatch(txtFactura.Text))
            {
                MessageBox.Show("la factura contiene caracteres invalidos");
                return;
            }

            if (!reg.IsMatch(txtFactura.Text))
            {
                MessageBox.Show("la factura contiene caracteres invalidos");
                return;
            }
            String estado = BD.chequearExistenciaYEstadoDelCliente(txtDni.Text);
            if (estado != "")
            {
                MessageBox.Show("El cliente no " + estado + "en el sistema");
                return;
            }
            if (listaSeleccionados.Items.Count == 0)
            {
                MessageBox.Show("La factura no tiene items");
                return;
            }



            String fechaVenc = dateVenc.Value.ToString("u");
            fechaVenc = fechaVenc.Substring(0, fechaVenc.Length - 1);

            String fechaAlta = dateAlta.Value.ToString("u");
            fechaAlta = fechaAlta.Substring(0, fechaAlta.Length - 1);

            BD.modificarFactura(txtFactura.Text, listaSeleccionados.Items, CheckHabilitado.Checked, txtEmpresa.Text, txtDni.Text, fechaAlta, fechaVenc);
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

        private void actualizarlabel(object sender, EventArgs e)
        {
            double sum = 0;
           foreach (ListViewItem eachItem in listaSeleccionados.Items)
            {
               sum += Double.Parse(eachItem.SubItems[0].Text) * Double.Parse(eachItem.SubItems[1].Text);
            }
           label4.Text = "Total: "+sum.ToString();
        }
    }
}
