using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace PagoAgilFrba.AbmFactura
{
    public partial class ABMFactura : Form
    {
        public ABMFactura()
        {
            InitializeComponent();

            cargarGrids();
            string query = "SELECT empresa_nombre FROM EL_JAPONES_SANGRANDO.Empresas";
            List<String> lista = BD.listaDeUnCampo(query);
            lista.Insert(0, "");
            comboboxEliminarEmpresa.DataSource = lista;
            comboBoxModEmpresa.DataSource = lista;

        }
        private void cargarGrids()
        {
            string query = "select DISTINCT factura_numero,(select empresa_nombre from EL_JAPONES_SANGRANDO.EMPRESAS where empresa_cuit = factura_empresa),factura_cliente from EL_JAPONES_SANGRANDO.Facturas";
            DataTable ds = BD.busqueda(query);
            datagridViewEliminar.Columns.Clear();
            dataGridViewModificarC.Columns.Clear();

            query = "select DISTINCT factura_numero,factura_empresa,factura_cliente from EL_JAPONES_SANGRANDO.Facturas where factura_estado = 1";
            DataTable ds2 = BD.busqueda(query);
            dataGridViewModificarC.DataSource = ds2;
            BD.nuevoBoton(dataGridViewModificarC, "Modificar", 8);

            datagridViewEliminar.DataSource = ds2;
            BD.nuevoBoton(datagridViewEliminar, "Eliminar", 3);
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
            txtEmpresa.DataSource = BD.listaDeUnCampo("select empresa_nombre from EL_JAPONES_SANGRANDO.Empresas where empresa_estado = 1");
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
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"^[0-9]+$");

            if (!reg.IsMatch(txtDni.Text)){
                MessageBox.Show("El dni tiene caracteres invalidos");
                return;
            }

            if (!reg.IsMatch(txtFactura.Text))
            {
                MessageBox.Show("la factura contiene caracteres invalidos");
                return;
            }

            if (! reg.IsMatch(txtFactura.Text))
            {
                MessageBox.Show("la factura contiene caracteres invalidos");
                return;
            }

        //    formatoFecha.formatoFecha.SetMyCustomFormatYYYYMMDD(dateVenc);
         //   formatoFecha.formatoFecha.SetMyCustomFormatYYYYMMDD(dateAlta);

            String fechaVenc = dateVenc.Value.ToString("u");
            fechaVenc = fechaVenc.Substring(0, fechaVenc.Length - 1);

            String fechaAlta = dateAlta.Value.ToString("u");
            fechaAlta = fechaAlta.Substring(0, fechaAlta.Length - 1);

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
                                    + fechaAlta + "','"
                                    + fechaVenc + "',"
                                    + sum + ")";

            if (BD.ABM(queryFactura) > 0)
            {
                if (BD.ABM(query) > 0)
                {
                    MessageBox.Show("Factura creada correctamente");
                }
                else
                {
                    BD.ABM("DELETE FROM EL_JAPONES_SANGRANDO.Facturas where factura_numero = '" + txtFactura.Text + "'");
                    MessageBox.Show("Error al generar los items");
                }
            }
            else
            {
                MessageBox.Show("Error al crear la factura");
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
                    if ((BD.ABM("UPDATE EL_JAPONES_SANGRANDO.Facturas SET factura_estado = 0 WHERE factura_numero = '" + numeroDeFactura + "'") > 0))
                    {
                        MessageBox.Show("Factura eliminada", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarGrids();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la factura, revise los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Ya estaba paga", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textEliminarNombre_TextChanged(object sender, EventArgs e)
        {
            String query = "SELECT  factura_numero,factura_empresa,factura_cliente from EL_JAPONES_SANGRANDO.Facturas WHERE factura_estado = 1 AND " +
                          "factura_cliente LIKE '" + textEliminarNumeroCliente.Text + "%' AND " +
                          "factura_numero LIKE '" + textEliminarNumeroFactura.Text + "%'" +
                          condicionDeEmpresas();
            datagridViewEliminar.DataSource = BD.busqueda(query);
        }
        private String condicionDeEmpresas()
        {
            if (comboboxEliminarEmpresa.Text == "")
                return "";
            return "AND factura_empresa = " + "(select top 1 empresa_cuit from EL_JAPONES_SANGRANDO.Empresas where empresa_nombre = '" + comboboxEliminarEmpresa.Text + "')";
        }


        private String condicionDeEmpresas2()
        {
            if (comboBoxModEmpresa.Text == "")
                return "";
            return " AND factura_empresa =  (select top 1 empresa_cuit from EL_JAPONES_SANGRANDO.Empresas where empresa_nombre = '" + comboBoxModEmpresa.Text + "')";
        }

        private void textModNumeroFactura_TextChanged(object sender, EventArgs e)
        {
            String query = "SELECT  factura_numero,factura_empresa,factura_cliente from EL_JAPONES_SANGRANDO.Facturas WHERE " +
                         "factura_cliente LIKE '" + textModCliente.Text + "%' AND " +
                         "factura_numero LIKE '" + textModNumeroFactura.Text + "%'" +
                         condicionDeEmpresas2();
            dataGridViewModificarC.Columns.Clear();
            dataGridViewModificarC.DataSource = BD.busqueda(query);
            BD.nuevoBoton(dataGridViewModificarC, "Modificar", 3);

        }

        private void dataGridViewModificarC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                string factura = dataGridViewModificarC.Rows[e.RowIndex].Cells["factura_numero"].Value.ToString();
                string estado = BD.consultaDeUnSoloResultado("Select factura_estado from EL_JAPONES_SANGRANDO.Facturas where factura_numero = '" + factura + "'");
                if (estado == "2" || estado == "3")
                {
                    MessageBox.Show("No se pueden modificar facturas pagadas o rendidas");
                }
                else
                {
                    new Eliminar_Modificar_Factura_Seleccionada(factura).Show();
                }
            }
        }

        private void comboBoxModEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGrids();
        }

        private void txtFactura_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
