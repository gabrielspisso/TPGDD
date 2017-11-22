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

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class ABMEmpresa : Form
    {
        public ABMEmpresa()
        {
            InitializeComponent();

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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            IniciarSesion.AccionesAdmin accion_ADMIN = new IniciarSesion.AccionesAdmin();
            IniciarSesion.Acciones accion = new IniciarSesion.Acciones();
            accion_ADMIN.Show();
            accion.Show();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string rubro = comboNuevoRubro.Text;
            string nombre = textNuevoNombre.Text;
            string direccion = textNuevoDirec.Text;
            string cuit = textNuevoCuit.Text+ textBox1.Text + textBox2.Text;
            
            if( rubro == "" ||nombre == ""|| direccion == "" ||cuit == ""){
                MessageBox.Show("Complete todos los campos");
                return;
            }
            Regex reg = new Regex("[0-9]");
            if (!reg.IsMatch(cuit))
            {
                MessageBox.Show("Cuit tiene caracteres invalidos");
                return;
            }
            if(cuit.Length != 11){
                MessageBox.Show("El Cuit no tiene la longitud correcta.");
                return;               
            }
            Regex reg2 = new Regex("[a-Z]");
            if(!reg2.IsMatch(nombre)){
                MessageBox.Show("El nombre tiene caracteres invalidos.");
                return;               
            }

            string subquery = "(SELECT rubro_id FROM EL_JAPONES_SANGRANDO.Rubros WHERE rubro_desc = '" + rubro + "')";
            int x = BD.insert("Empresas", "(empresa_rubro,empresa_cuit,empresa_nombre,empresa_direccion)values(" +
                subquery + ", '" +
                cuit + "', '" +
                nombre + "', '" +
                direccion + "')"
                );
            if (x != 0)
            {
                MessageBox.Show("La empresa fue creada", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarGrids();
            }
            else
            {
                MessageBox.Show("Ya existe una empresa con el mismo cuit o nombre", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ABMEmpresa_Load(object sender, EventArgs e)
        {
            BD.nuevoBoton(dataGridViewModificarC, "Modificar", 5);
            BD.nuevoBoton(dataGridEliminar, "Eliminar", 5);
            cargarGrids();
        }

        private void cargarGrids()
        {
            string query = "SELECT rubro_desc FROM EL_JAPONES_SANGRANDO.Rubros";
            List<String> lista = BD.listaDeUnCampo(query);
            comboNuevoRubro.DataSource = lista;
            lista.Insert(0, "");
            comboModRubro.DataSource = lista;
            comboElimRubro.DataSource = lista;

            string queryModificar = "SELECT empresa_nombre,rubro_desc,empresa_cuit,empresa_direccion FROM EL_JAPONES_SANGRANDO.Empresas join EL_JAPONES_SANGRANDO.Rubros on empresa_rubro = rubro_id ";
            DataTable dt = BD.busqueda(queryModificar + "ORDER BY 1");
            dataGridViewModificarC.Columns.Clear();
            dataGridViewModificarC.DataSource = dt;
            BD.nuevoBoton(dataGridViewModificarC, "Modificar", 5);

            string queryEliminar = queryModificar + " WHERE empresa_estado = 1 ORDER BY 1";
            DataTable dt2 = BD.busqueda(queryEliminar);
            dataGridEliminar.Columns.Clear();
            dataGridEliminar.DataSource = dt2;
            BD.nuevoBoton(dataGridEliminar, "Eliminar", 5);


        }

        private void textElimNombre_TextChanged(object sender, EventArgs e)
        {
            String query = "SELECT empresa_nombre,rubro_desc,empresa_cuit FROM EL_JAPONES_SANGRANDO.Empresas join EL_JAPONES_SANGRANDO.Rubros on empresa_rubro = rubro_id WHERE " +
                         "empresa_estado = 1 AND " +
                         "empresa_nombre LIKE '" + textElimNombre.Text + "%' AND " +
                         "empresa_cuit LIKE '" + textElimCuit.Text + "%' " +
                         condicionRubro(comboElimRubro.Text);
            dataGridEliminar.DataSource = BD.busqueda(query);
        }

        private void textModNombre_TextChanged(object sender, EventArgs e)
        {
            actualizarGrid(dataGridViewModificarC, textModNombre.Text, textModCuit.Text, comboModRubro.Text);

        }

        private void actualizarGrid(DataGridView dgv , string nombre, string cuit, string rubro)
        {
            String query = "SELECT empresa_nombre,rubro_desc,empresa_cuit FROM EL_JAPONES_SANGRANDO.Empresas join EL_JAPONES_SANGRANDO.Rubros on empresa_rubro = rubro_id WHERE " +
                         "empresa_nombre LIKE '" + nombre + "%' AND " +
                         "empresa_cuit LIKE '" + cuit + "%' " +
                         condicionRubro(rubro);
            dgv.DataSource = BD.busqueda(query);
        }

        public String condicionRubro(string rubro)
        {
            return (rubro == "") ? "" : "AND rubro_desc = '" + rubro + "'";
        }

        private void dataGridEliminar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                string x = dataGridEliminar.Rows[e.RowIndex].Cells["empresa_cuit"].Value.ToString();
                if (BD.todasRendidas(x))
                {
                    if (BD.ABM("UPDATE EL_JAPONES_SANGRANDO.Empresas SET empresa_estado = 0 WHERE empresa_cuit = '" + x + "'") > 0)
                    {
                        MessageBox.Show("Empresa eliminada", "Empresa eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarGrids();
                    }
                }
                else
                {
                    MessageBox.Show("La Empresa todavia tiene facturas por rendir", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
        }

        private void dataGridViewModificarC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                string cuit = dataGridViewModificarC.Rows[e.RowIndex].Cells["empresa_cuit"].Value.ToString();
                this.Hide();
                new Eliminar_Modificar_Empresa_Seleccionada(cuit).ShowDialog();
                this.Show();
                cargarGrids();
            }
        }

        private void comboNuevoRubro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textNuevoCuit_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

    }
}
