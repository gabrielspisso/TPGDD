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
            string query = "select DISTINCT factura_numero,(select empresa_nombre from EL_JAPONES_SANGRANDO.EMPRESAS where empresa_cuit = factura_empresa),factura_cliente from EL_JAPONES_SANGRANDO.Facturas";
            DataTable ds = BD.busqueda(query);
            datagridViewEliminar.Columns.Clear();
            dataGridViewModificarC.Columns.Clear();
            dataGridViewModificarC.DataSource = ds;
            query = "select DISTINCT factura_numero,factura_empresa,factura_cliente from EL_JAPONES_SANGRANDO.Facturas where factura_estado = 1";
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
            txtEmpresa.DataSource = BD.listaDeUnCampo("select empresa_nombre from EL_JAPONES_SANGRANDO.Empresas");
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
            string query = "INSERT INTO EL_JAPONES_SANGRANDO.Item_Factura (item_monto, item_cantidad, item_factura) VALUES "; 
            foreach (ListViewItem eachItem in listaSeleccionados.Items)
            {
                query += "(" + eachItem.SubItems[0].Text + "," + eachItem.SubItems[1].Text + ",'" + txtFactura.Text + "'),";
                sum += Double.Parse(eachItem.SubItems[0].Text) * Double.Parse(eachItem.SubItems[1].Text);
            }
            query = query.Substring(0, query.Length - 1);

            string empresa = BD.consultaDeUnSoloResultado("(select TOP 1 empresa_cuit from EL_JAPONES_SANGRANDO.Empresas where empresa_nombre = '" + txtEmpresa.Text + "')");

            string queryFactura = "INSERT INTO EL_JAPONES_SANGRANDO.Facturas (factura_numero,factura_empresa, factura_cliente, factura_fecha, factura_fecha_vencimiento, factura_total) values ('"
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
                    BD.ABM("DELETE FROM EL_JAPONES_SANGRANDO.Facturas where factura_numero = '" + txtFactura.Text + "'");
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
                string numeroDeFactura = datagridViewEliminar.Rows[e.RowIndex].Cells["factura_numero"].Value.ToString();

                if (BD.consultaDeUnSoloResultado("select * from EL_JAPONES_SANGRANDO.Facturas where factura_numero = " + numeroDeFactura + "") == "")
                    MessageBox.Show("Factura inexistente", "no se pudo eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (BD.consultaDeUnSoloResultado("select pago_Factura_factura from EL_JAPONES_SANGRANDO.Facturas join EL_JAPONES_SANGRANDO.Pago_Factura on (pago_Factura_factura = factura_numero) WHERE factura_numero = '" + numeroDeFactura + "'") == "")
                {
                   if((BD.ABM("UPDATE EL_JAPONES_SANGRANDO.Facturas SET factura_estado = 0 WHERE factura_numero = '"+numeroDeFactura+"'")>0))
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
            String query = "SELECT  factura_numero,factura_empresa,factura_cliente from EL_JAPONES_SANGRANDO.Facturas WHERE " +
                          "factura_cliente LIKE '" + textEliminarNumeroCliente.Text + "%' AND " +
                          "factura_numero LIKE '" + textEliminarNumeroFactura.Text + "%'" +
                          condicionDeEmpresas();
            datagridViewEliminar.DataSource = BD.busqueda(query);
        }
        private String condicionDeEmpresas(){
            if(comboboxEliminarEmpresa.SelectedText=="")
                return "";
            return "AND factura_empresa = " + "(select empresa_cuit from EL_JAPONES_SANGRANDO.Empresas where empresa_nombre = '" + comboboxEliminarEmpresa.Text + "')";
        }

       
        private String condicionDeEmpresas2()
        {
            if (comboboxEliminarEmpresa.SelectedText == "")
                return "";
            return "AND factura_empresa = " + "(select empresa_cuit from EL_JAPONES_SANGRANDO.Empresas where empresa_nombre = '" + comboBoxModEmpresa.Text + "')";
        }

        private void textModNumeroFactura_TextChanged(object sender, EventArgs e)
        {
            String query = "SELECT  factura_numero,factura_empresa,factura_cliente from EL_JAPONES_SANGRANDO.Facturas WHERE " +
                         "factura_cliente LIKE '" + textModCliente.Text + "%' AND " +
                         "factura_numero LIKE '" + textModNumeroFactura.Text + "%'" +
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
                string factura = dataGridViewModificarC.Rows[e.RowIndex].Cells["factura_numero"].Value.ToString();
                string estado = BD.consultaDeUnSoloResultado("Select factura_estado from EL_JAPONES_SANGRANDO.Facturas where factura_numero = '"+factura+"'");
                if(estado =="2" || estado =="3"){
                    MessageBox.Show("No se pueden modificar facturas pagadas o rendidas");
                }
                else{
                    new Eliminar_Modificar_Factura_Seleccionada(factura).Show();
                }
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

        private void btnModificarCliente_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
