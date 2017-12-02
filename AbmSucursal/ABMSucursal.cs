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
                buttons.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                buttons.FlatStyle = FlatStyle.Standard;
                buttons.CellTemplate.Style.BackColor = Color.Honeydew;
                buttons.DisplayIndex = 3;
            }
            DataGridViewButtonColumn buttons2 = new DataGridViewButtonColumn();
            {
                buttons2.HeaderText = "Eliminar";
                buttons2.Text = "Eliminar";
                buttons2.UseColumnTextForButtonValue = true;
                buttons2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                buttons2.FlatStyle = FlatStyle.Standard;
                buttons2.CellTemplate.Style.BackColor = Color.Honeydew;
                buttons2.DisplayIndex = 3;
            }
            dataGridViewModificarC.Columns.Clear();
            DatagridViewEliminar.Columns.Clear();
            dataGridViewModificarC.DataSource = BD.sucursales();

            DatagridViewEliminar.DataSource = BD.sucursalesActivas();
            DatagridViewEliminar.Columns.Add(buttons2);

            dataGridViewModificarC.Columns.Add(buttons);

            DatagridViewEliminar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewModificarC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
           
            string codigo_postal = textAgregarCodigoPostal.Text;
            string nombre = textAgregarNombre.Text;
            string direccion = textAgregarDireccion.Text;
            Regex reg = new Regex(@"^[0-9]+$");

            if(codigo_postal == "" || nombre == "" || direccion == ""){
                MessageBox.Show("Complete todos los campos");
                return;
            }
            if (!reg.IsMatch(codigo_postal))
            {
                MessageBox.Show("Codigo Postal tiene que ser numerico");
                return;
            }

            if (BD.crearSucursal(codigo_postal, nombre, direccion))
            {
                MessageBox.Show("La sucursal fue creada", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                actualizar();
            }
            else{
                 MessageBox.Show("Ya existe una sucursal con el mismo codigo postal o nombre", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewModificarC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                new Eliminar_Modificar_Sucursal_Seleccionada(dataGridViewModificarC.Rows[e.RowIndex].Cells["sucursal_nombre"].Value.ToString()).ShowDialog();
                actualizar();
            }
        }

        private void DatagridViewEliminar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                string sucursalNombre = DatagridViewEliminar.Rows[e.RowIndex].Cells["sucursal_nombre"].Value.ToString();
                if (BD.eliminarSucursal(sucursalNombre))
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

    }
}
