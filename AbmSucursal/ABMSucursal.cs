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
namespace PagoAgilFrba.Sucursal
{
    public partial class ABMSucursal : Form
    {
        public ABMSucursal()
        {

          

            
            InitializeComponent();
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
            dataGridViewModificarC.DataSource = BD.busqueda("select suc_nombre,suc_CP,suc_dir from EL_JAPONES_SANGRANDO.Sucursales");
            DatagridViewEliminar.DataSource = BD.busqueda("select suc_nombre,suc_CP,suc_dir from EL_JAPONES_SANGRANDO.Sucursales where suc_estado = 1");
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
            if (BD.ABM("INSERT INTO [EL_JAPONES_SANGRANDO].[Sucursales](suc_CP,suc_dir,suc_nombre)values('" + codigo_postal + "','" + nombre + "','" + direccion + "')") != 0)
            {
                MessageBox.Show("La sucursal fue creada", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                new Eliminar_Modificar_Sucursal_Seleccionada(dataGridViewModificarC.Rows[e.RowIndex].Cells["suc_nombre"].Value.ToString()).Show();
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
                string sucursalNombre = DatagridViewEliminar.Rows[e.RowIndex].Cells["suc_nombre"].Value.ToString();
                if (BD.ABM("UPDATE EL_JAPONES_SANGRANDO.Sucursales SET suc_estado = 0 WHERE suc_nombre ='" + sucursalNombre + "'") > 0)
                {
                    MessageBox.Show("Se elimino la sucursal " + sucursalNombre, "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DatagridViewEliminar.DataSource = BD.busqueda("select suc_nombre,suc_CP,suc_dir from EL_JAPONES_SANGRANDO.Sucursales where suc_estado = 1");
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la sucursal " + sucursalNombre, "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
    }
}
