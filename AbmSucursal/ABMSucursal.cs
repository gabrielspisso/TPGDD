using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagoAgilFrba.Sucursal;
using System.Text.RegularExpressions;
namespace PagoAgilFrba.Sucursal
{
    public partial class ABMSucursal : Form
    {
        public ABMSucursal()
        {

          

            
            InitializeComponent();
            actualizar();
        }

        private void actualizar()
        {
            DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
            {
                buttons.HeaderText = "Modificar";
                buttons.Text = "Modificar";
                buttons.UseColumnTextForButtonValue = true;
                buttons.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                buttons.FlatStyle = FlatStyle.Standard;
                buttons.CellTemplate.Style.BackColor = Color.Honeydew;
                buttons.DisplayIndex = 3;
            }
            DataGridViewButtonColumn buttons2 = new DataGridViewButtonColumn();
            {
                buttons2.HeaderText = "Eliminar";
                buttons2.Text = "Eliminar";
                buttons2.UseColumnTextForButtonValue = true;
                buttons2.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                buttons2.FlatStyle = FlatStyle.Standard;
                buttons2.CellTemplate.Style.BackColor = Color.Honeydew;
                buttons2.DisplayIndex = 3;
            }
            dataGridViewModificarC.Columns.Clear();
            DatagridViewEliminar.Columns.Clear();
            dataGridViewModificarC.DataSource = BD.busqueda("select sucursal_nombre,sucursal_codigo_postal,sucursal_direccion from EL_JAPONES_SANGRANDO.Sucursales");
            
            DatagridViewEliminar.DataSource = BD.busqueda("select sucursal_nombre,sucursal_codigo_postal,sucursal_direccion from EL_JAPONES_SANGRANDO.Sucursales where sucursal_estado = 1");
            DatagridViewEliminar.Columns.Add(buttons2);

            dataGridViewModificarC.Columns.Add(buttons);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
           
            string codigo_postal = textAgregarCodigoPostal.Text;
            string nombre = textAgregarNombre.Text;
            string direccion = textAgregarDireccion.Text;
            Regex reg = new Regex("[0-9]");

            if(codigo_postal == "" || nombre == "" || direccion == ""){
                MessageBox.Show("Complete todos los campos");
                return;
            }
            if (!reg.IsMatch(codigo_postal))
            {
                MessageBox.Show("Codigo Posta tiene que ser numerico");
                return;
            }

            if (BD.ABM("INSERT INTO [EL_JAPONES_SANGRANDO].[Sucursales](sucursal_codigo_postal,sucursal_direccion,sucursal_nombre)values('" + codigo_postal + "','" + nombre + "','" + direccion + "')") != 0)
            {
                MessageBox.Show("La sucursal fue creada", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                actualizar();
            }
            else{
                 MessageBox.Show("Ya existe una sucursal con el mismo codigo postal o nombre", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void textNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewModificarC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                new Eliminar_Modificar_Sucursal_Seleccionada(dataGridViewModificarC.Rows[e.RowIndex].Cells["sucursal_nombre"].Value.ToString()).ShowDialog();
                actualizar();
                //string rol = dataGridViewModificarC.Rows[e.ColumnIndex].Cells[2].Value.ToString();
                //BD.ABM("UPDATE EL_JAPONES_SANGRANDO.Roles SET rol_estado = 0 WHERE rol_nombre ='" +rol+ "'");
            }
        }

        private void DatagridViewEliminar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                string sucursalNombre = DatagridViewEliminar.Rows[e.RowIndex].Cells["sucursal_nombre"].Value.ToString();
                string update = "UPDATE EL_JAPONES_SANGRANDO.Sucursales SET sucursal_estado = 0 WHERE sucursal_nombre ='" + sucursalNombre + "'";
                string idSucursal = BD.consultaDeUnSoloResultado("select sucursal_codigo_postal from EL_JAPONES_SANGRANDO.Sucursales where sucursal_nombre ='" + sucursalNombre + "'");
                //string delete = "Delete EL_JAPONES_SANGRANDO.Usuario_Rol where usuario_Rol_usuario IN (select usuario_Sucursal_usuario from EL_JAPONES_SANGRANDO.Usuario_Sucursal where usuario_Sucursal_sucursal = " + idSucursal + ")";
                List<String> lista = new List<String>();
                lista.Add(update);
                //lista.Add(delete);
                if (BD.correrStoreProcedure(lista) > 0)
                {
                    MessageBox.Show("Se elimino la sucursal " + sucursalNombre, "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    actualizar();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la sucursal " + sucursalNombre, "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void ABMSucursal_Load(object sender, EventArgs e)
        {

        }

        private void textAgregarCodigoPostal_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
