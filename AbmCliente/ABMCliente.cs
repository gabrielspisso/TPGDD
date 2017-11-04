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
using System.Data;
using System.Data.SqlClient;

namespace PagoAgilFrba.AbmCliente
{
    public partial class ABMCliente : Form
    {
        public ABMCliente()
        {
            InitializeComponent();
            string query = "select cliente_nombre,cliente_apellido,cliente_DNI from EL_JAPONES_SANGRANDO.Clientes";
            DataTable ds = BD.busqueda(query);
            dataViewModificar.DataSource = ds;
            BD.nuevoBoton(dataViewModificar, "Modificar", 3);

            query = "select cliente_nombre,cliente_apellido,cliente_DNI from EL_JAPONES_SANGRANDO.Clientes where cliente_estado = 1";
            datagridEliminar.DataSource = BD.busqueda(query);
            BD.nuevoBoton(datagridEliminar, "Eliminar", 3);
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            String query = "SELECT cliente_nombre,cliente_apellido,cliente_DNI FROM EL_JAPONES_SANGRANDO.Clientes WHERE " +
                           "cliente_nombre LIKE '" + textElimNombre.Text + "%' AND " +
                           "cliente_apellido LIKE '" + textElimApellido.Text + "%' " +
                           condicionDNI(textElimDNI.Text);
            datagridEliminar.DataSource = BD.busqueda(query);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                string x = datagridEliminar.Rows[e.RowIndex].Cells["cliente_DNI"].Value.ToString();
                if (BD.ABM("UPDATE EL_JAPONES_SANGRANDO.Clientes SET cliente_estado = 0 WHERE cliente_DNI = '" + x + "'") > 0)
                {
                    MessageBox.Show("cliente eliminado", "Al pique quique", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    String query = "select cliente_nombre,cliente_apellido,cliente_DNI from EL_JAPONES_SANGRANDO.Clientes where cliente_estado = 1";
                    datagridEliminar.DataSource = BD.busqueda(query);
                    query = "select cliente_nombre,cliente_apellido,cliente_DNI from EL_JAPONES_SANGRANDO.Clientes";
                    DataTable ds = BD.busqueda(query);
                    dataViewModificar.DataSource = ds;
                }

                //string rol = dataGridViewModificarC.Rows[e.ColumnIndex].Cells[2].Value.ToString();
                //BD.ABM("UPDATE EL_JAPONES_SANGRANDO.Roles SET rol_estado = 0 WHERE rol_nombre ='" +rol+ "'");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            IniciarSesion.AccionesAdmin accion_ADMIN = new IniciarSesion.AccionesAdmin();
            IniciarSesion.Acciones accion = new IniciarSesion.Acciones();
            accion_ADMIN.Show();
            accion.Show();
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textDni.Text, @"^\d+$"))
            {
                MessageBox.Show("Sólo se permiten numeros en el DNI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textNombre.Text.Trim() == "" | textApellido.Text.Trim() == "" | textDni.Text.Trim() == "" | textDireccion.Text.Trim() == "" | textDireccion.Text.Trim() == "" | dateTimePickerFechaNac.Text.Trim() == "")
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
                String fechanacimiento = dateTimePickerFechaNac.Text;
                if (BD.ABM("INSERT INTO EL_JAPONES_SANGRANDO.Clientes(cliente_DNI,cliente_nombre,cliente_apellido,cliente_fecha_nacimiento,cliente_mail,cliente_direccion,cliente_codigo_postal)values('" + dni + "','" + nombre + "','" + apellido + "','" + fechanacimiento + "','" + mail + "','" + direccion + "','" + textCodigoPostal.Text + "')") > 0)
                {
                    MessageBox.Show("Se ingreso correctamente el cliente", "Insertado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textNombre.Text = "";
                    textApellido.Text = "";
                    textDni.Text = "";
                    textMail.Text = "";
                    textCodigoPostal.Text = "";
                    textDireccion.Text = "";
                    dateTimePickerFechaNac.Text = "";
                    string query = "select cliente_nombre,cliente_apellido,cliente_DNI from EL_JAPONES_SANGRANDO.Clientes";
                    DataTable ds = BD.busqueda(query);
                    dataViewModificar.DataSource = ds;
                    query = "select cliente_nombre,cliente_apellido,cliente_DNI from EL_JAPONES_SANGRANDO.Clientes where cliente_estado = 1";
                    datagridEliminar.DataSource = BD.busqueda(query);
                }
                else
                {
                    MessageBox.Show("Datos erroneos el cliente", "Error en seleccion", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }


            }


        }

        private void dataViewModificar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                new Eliminar_Modificar_Cliente_Seleccionado(dataViewModificar.Rows[e.RowIndex].Cells["cliente_DNI"].Value.ToString()).Show();
                string query = "select cliente_nombre,cliente_apellido,cliente_DNI from EL_JAPONES_SANGRANDO.Clientes";
                DataTable ds = BD.busqueda(query);
                dataViewModificar.DataSource = ds;
                query = "select cliente_nombre,cliente_apellido,cliente_DNI from EL_JAPONES_SANGRANDO.Clientes where cliente_estado = 1";
                datagridEliminar.DataSource = BD.busqueda(query);
                //string rol = dataGridViewModificarC.Rows[e.ColumnIndex].Cells[2].Value.ToString();
                //BD.ABM("UPDATE EL_JAPONES_SANGRANDO.Roles SET rol_estado = 0 WHERE rol_nombre ='" +rol+ "'");
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            String query = "SELECT cliente_nombre,cliente_apellido,cliente_DNI FROM EL_JAPONES_SANGRANDO.Clientes WHERE " +
                           "cliente_nombre LIKE '" + textModNombre.Text + "%' AND " +
                           "cliente_apellido LIKE '" + textModApellido.Text + "%' " +
                           condicionDNI(textModDNI.Text);
            dataViewModificar.DataSource = BD.busqueda(query);
        }

        public static String condicionDNI(String dni)
        {
            return (dni == "") ? "" : "AND cliente_DNI = '" + dni + "'";
        }
    }

}