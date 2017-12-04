using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace PagoAgilFrba.IniciarSesion
{
    public partial class elegirFactura : Form
    {
        DataTable dt;
        seleccionarFactura reg;
        Boolean pagada;
        public elegirFactura(seleccionarFactura reg,Boolean esto)
        {
            InitializeComponent();
            pagada = esto;
            this.reg = reg;
            SqlCommand query = new SqlCommand("SELECT empresa_nombre, empresa_cuit FROM EL_JAPONES_SANGRANDO.Empresas WHERE empresa_estado = 1 ORDER BY empresa_cuit");
            DataTable dt = BD.busqueda(query);
            DataRow dr = dt.NewRow();
            dr[0] = "";
            dr[1] = "-1";
            dt.Rows.InsertAt(dr, 0);
            filtroEmpresa.DisplayMember = "empresa_nombre";
            filtroEmpresa.DataSource = dt;
            this.filtrar(null,null);
        }

        private void cargarTabla(SqlCommand query)
        {
            dt = BD.busqueda(query);
            listadoClientes.DataSource = dt;
            foreach (DataColumn c in dt.Columns)
                c.ReadOnly = true;

        }

        public void filtrar(object sender, EventArgs e)
        {
            String fecha = BD.fechaActual().ToString("u");
            fecha = fecha.Substring(0, fecha.Length - 1);
            SqlCommand query;
            if (pagada == false)
                query = new SqlCommand("SELECT factura_numero, cliente_nombre, cliente_apellido, empresa_nombre, factura_fecha, factura_fecha_vencimiento, factura_total  FROM EL_JAPONES_SANGRANDO.Facturas JOIN EL_JAPONES_SANGRANDO.Clientes ON factura_cliente = cliente_DNI JOIN EL_JAPONES_SANGRANDO.Empresas ON factura_empresa = empresa_cuit WHERE factura_estado = 1 AND empresa_estado = 1 AND (factura_numero LIKE '%" + filtroNumero.Text + "%' OR '" + filtroNumero.Text + "' = '') AND (CONCAT(cliente_nombre, ' ',cliente_apellido) LIKE '%" + filtroCliente.Text + "%' OR '" + filtroCliente.Text + "' = '') AND (empresa_nombre LIKE '%" + filtroEmpresa.Text + "%' OR '" + filtroEmpresa.Text + "' = '') and (year(factura_fecha_vencimiento) > year('" + fecha + "') OR (year(factura_fecha_vencimiento) = year('" + fecha + "') AND month(factura_fecha_vencimiento) > month('" + fecha + "')) OR (year(factura_fecha_vencimiento) = year('" + fecha + "') AND Month(factura_fecha_vencimiento) = Month('" + fecha + "') AND DAY(factura_fecha_vencimiento) >= DAY('" + fecha + "')  )) ORDER BY factura_numero");
            else
                query = new SqlCommand("SELECT factura_numero, cliente_nombre, cliente_apellido, empresa_nombre, factura_fecha, factura_fecha_vencimiento, factura_total  FROM EL_JAPONES_SANGRANDO.Facturas JOIN EL_JAPONES_SANGRANDO.Clientes ON factura_cliente = cliente_DNI JOIN EL_JAPONES_SANGRANDO.Empresas ON factura_empresa = empresa_cuit WHERE factura_estado = 2 AND (factura_numero LIKE '%" + filtroNumero.Text + "%' OR '" + filtroNumero.Text + "' = '') AND (CONCAT(cliente_nombre, ' ',cliente_apellido) LIKE '%" + filtroCliente.Text + "%' OR '" + filtroCliente.Text + "' = '') AND (empresa_nombre LIKE '%" + filtroEmpresa.Text + "%' OR '" + filtroEmpresa.Text + "' = '') ORDER BY factura_numero");
            this.cargarTabla(query);
        }

        private void btnFiltrar_Click_1(object sender, EventArgs e)
        {
            this.filtrar(null,null);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            filtroCliente.Text = "";
            filtroEmpresa.SelectedIndex = 0;
            filtroNumero.Text = "";
            this.filtrar(null,null);
        }

        private void listadoClientes_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView tabla = (DataGridView)sender;
            if (tabla.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                String nro = tabla.Rows[e.RowIndex].Cells[1].Value.ToString();
                DateTime fechaVenc = (DateTime)tabla.Rows[e.RowIndex].Cells[6].Value;
                if (fechaVenc.CompareTo(BD.fechaActual()) < 0 && !pagada)
                {
                    MessageBox.Show("La factura esta vencida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    reg.setFactura(nro);
                    if (pagada)
                        this.Close();
                }

            }
        }


    }
}
