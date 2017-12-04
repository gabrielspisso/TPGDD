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
namespace PagoAgilFrba.RegistroPago
{
    public partial class elegirCliente : Form
    {
        private DataTable dt;
        public seleccionarCliente abm;

        public elegirCliente(seleccionarCliente abm)
        {
            this.abm = abm;
            InitializeComponent();
            this.filtrar(null,null);
        }

        private void cargarTabla(SqlCommand query)
        {
            dt = BD.busqueda(query);
            dt.Columns.Remove("cliente_estado");
            listadoClientes.DataSource = dt;


            foreach (DataColumn c in dt.Columns)
                c.ReadOnly = true;
        }

        public void filtrar(object sender, EventArgs e)
        {

            SqlCommand query = new SqlCommand("SELECT * FROM EL_JAPONES_SANGRANDO.Clientes WHERE cliente_estado = 1 AND (cliente_DNI LIKE '%" + filtroDNI.Text + "%' OR '" + filtroDNI.Text + "' = '') AND (cliente_apellido LIKE '%" + filtroApellido.Text + "%' OR '" + filtroApellido.Text + "' = '') AND (cliente_nombre LIKE '%" + filtroNombre.Text + "%' OR '" + filtroNombre.Text + "' = '') ORDER BY cliente_apellido");
            this.cargarTabla(query);
        }

        


        private void listadoClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView tabla = (DataGridView)sender;
            if (tabla.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                String dni = tabla.Rows[e.RowIndex].Cells[1].Value.ToString();
                abm.setCliente(dni);
                this.Close();

            }
        }
    

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            filtroApellido.Text = "";
            filtroDNI.Text = "";
            filtroNombre.Text = "";
            this.filtrar(null,null);
        }

        private void elegirCliente_Load(object sender, EventArgs e)
        {

        }

    
    }
}
