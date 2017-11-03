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

            cargarGrids();
            string query = "SELECT rubro_desc FROM EL_JAPONES_SANGRANDO.Rubros";
            List<String> lista = BD.listaDeUnCampo(query);
            lista.Insert(0, "");
            comboboxEliminarEmpresa.DataSource = lista;
            comboBoxModEmpresa.DataSource = lista;
           
        }
        private void cargarGrids(){
            string query = "select DISTINCT fact_num,(select emp_nombre from EL_JAPONES_SANGRANDO.EMPRESAS where emp_CUIT = fact_empresa),fact_cliente from EL_JAPONES_SANGRANDO.Facturas";
            DataTable ds = BD.busqueda(query);
            datagridViewEliminar.Columns.Clear();
            dataGridViewModificarC.Columns.Clear();
            dataGridViewModificarC.DataSource = ds;
            query = "select DISTINCT fact_num,fact_empresa,fact_cliente from EL_JAPONES_SANGRANDO.Facturas where fact_estado = 1";
            DataTable ds2 = BD.busqueda(query);
            BD.nuevoBoton(dataGridViewModificarC, "Modificar", 8);

            datagridViewEliminar.DataSource = ds2;
            BD.nuevoBoton(datagridViewEliminar, "Eliminar", 3);
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



            formatoFecha.formatoFecha.SetMyCustomFormatYYYYMMDD(dateVenc);
            formatoFecha.formatoFecha.SetMyCustomFormatYYYYMMDD(dateAlta);
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
            cargarGrids();
        }

        private void datagridViewEliminar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                string numeroDeFactura = datagridViewEliminar.Rows[e.RowIndex].Cells["fact_num"].Value.ToString();

                if (BD.consultaDeUnSoloResultado("select * from EL_JAPONES_SANGRANDO.Facturas where fact_num = " + numeroDeFactura + "") == "")
                    MessageBox.Show("Factura inexistente", "no se pudo eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (BD.consultaDeUnSoloResultado("select pagfact_factura from EL_JAPONES_SANGRANDO.Facturas join EL_JAPONES_SANGRANDO.PagoFactura on (pagfact_factura = fact_num) WHERE fact_num = '" + numeroDeFactura + "'") == "")
                {
                   if((BD.ABM("UPDATE EL_JAPONES_SANGRANDO.Facturas SET fact_estado = 0 WHERE fact_num = '"+numeroDeFactura+"'")>0))
                   {
                    MessageBox.Show("Factura eliminada", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarGrids();
                    }
                   else{
                    MessageBox.Show("No se pudo eliminar la factura, revise los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   }

                }
                else {
                    MessageBox.Show("Ya estaba paga", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textEliminarNombre_TextChanged(object sender, EventArgs e)
        {
            String query = "SELECT  fact_num,fact_empresa,fact_cliente from EL_JAPONES_SANGRANDO.Facturas WHERE " +
                          "fact_cliente LIKE '" + textEliminarNumeroCliente.Text + "%' AND " +
                          "fact_num LIKE '" + textEliminarNumeroFactura.Text + "%'" +
                          condicionDeEmpresas();
            datagridViewEliminar.DataSource = BD.busqueda(query);
        }
        private String condicionDeEmpresas(){
            if(comboboxEliminarEmpresa.SelectedText=="")
                return "";
            return "AND fact_empresa = " + "(select emp_CUIT from EL_JAPONES_SANGRANDO.Empresas where emp_nombre = '" + comboboxEliminarEmpresa.Text + "')";
        }

       
        private String condicionDeEmpresas2()
        {
            if (comboboxEliminarEmpresa.SelectedText == "")
                return "";
            return "AND fact_empresa = " + "(select emp_CUIT from EL_JAPONES_SANGRANDO.Empresas where emp_nombre = '" + comboBoxModEmpresa.Text + "')";
        }

        private void textModNumeroFactura_TextChanged(object sender, EventArgs e)
        {
            String query = "SELECT  fact_num,fact_empresa,fact_cliente from EL_JAPONES_SANGRANDO.Facturas WHERE " +
                         "fact_cliente LIKE '" + textModCliente.Text + "%' AND " +
                         "fact_num LIKE '" + textModNumeroFactura.Text + "%'" +
                         condicionDeEmpresas2();
            dataGridViewModificarC.Columns.Clear();
            dataGridViewModificarC.DataSource = BD.busqueda(query);
            BD.nuevoBoton(dataGridViewModificarC,"Modificar",3);
            
        }

        private void dataGridViewModificarC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {

                new Eliminar_Modificar_Factura_Seleccionada(dataGridViewModificarC.Rows[e.RowIndex].Cells["fact_num"].Value.ToString()).Show();
            }
        }

        private void listaSeleccionados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateVenc_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateAlta_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtFactura_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
