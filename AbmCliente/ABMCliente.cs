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

namespace PagoAgilFrba.AbmCliente
{
    public partial class ABMCliente : Form
    {
        public ABMCliente()
        {
            InitializeComponent();
            BD.actualizarVistasClientes(datagridEliminar, dataViewModificar);
            BD.nuevoBoton(dataViewModificar, "Modificar", 3);
            BD.nuevoBoton(datagridEliminar, "Eliminar", 3);
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            datagridEliminar.DataSource = BD.filtroClienteEliminar(textElimNombre.Text, textElimApellido.Text, textElimDNI.Text);
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            dataViewModificar.DataSource = BD.filtroClienteModificar(textModNombre.Text, textModApellido.Text, textModDNI.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                string x = datagridEliminar.Rows[e.RowIndex].Cells["cliente_DNI"].Value.ToString();
                BD.eliminarCliente(x, datagridEliminar, dataViewModificar);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textDni.Text, @"^\d+$"))
            {
                MessageBox.Show("Sólo se permiten numeros en el DNI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtTelefono.Text, @"^\d+$"))
            {
                MessageBox.Show("Sólo se permiten numeros en el telefono", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textNombre.Text.Trim() == "" | textApellido.Text.Trim() == "" | txtTelefono.Text.Trim() == "" | textDni.Text.Trim() == "" | textDireccion.Text.Trim() == "" | textDireccion.Text.Trim() == "" | dateTimePickerFechaNac.Text.Trim() == "" | txtTelefono.Text.Trim() == "" )
            {
                MessageBox.Show("Faltan completar campos obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                String nombre = textNombre.Text;
                String apellido = textApellido.Text;
                String dni = textDni.Text;
                String mail = textMail.Text;
                String direccion = textDireccion.Text;
                String fechanacimiento = dateTimePickerFechaNac.Value.ToString("u");
                fechanacimiento = fechanacimiento.Substring(0, fechanacimiento.Length - 1);
                if (BD.crearCliente(nombre, apellido, dni, mail, direccion, fechanacimiento, textCodigoPostal.Text,txtTelefono.Text))
                {
                    MessageBox.Show("Se ingreso correctamente el cliente", "Insertado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textNombre.Text = "";
                    textApellido.Text = "";
                    textDni.Text = "";
                    textMail.Text = "";
                    textCodigoPostal.Text = "";
                    textDireccion.Text = "";
                    dateTimePickerFechaNac.Text = "";
                    txtTelefono.Text = "";
                    BD.actualizarVistasClientes(datagridEliminar,dataViewModificar);
                }
                else
                {
                    string x = BD.cantidadDeClientesCon(textDni.Text);
                    if (Int32.Parse(x) > 0)
                    {
                        MessageBox.Show("Ya existe un cliente con ese DNI");
                        return;
                    }
                    MessageBox.Show("Ya existe un cliente con ese mail", "Error en seleccion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dataViewModificar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                new Eliminar_Modificar_Cliente_Seleccionado(dataViewModificar.Rows[e.RowIndex].Cells["cliente_DNI"].Value.ToString()).Show();
                BD.actualizarVistasClientes(datagridEliminar, dataViewModificar);
            }
        }
    }
}