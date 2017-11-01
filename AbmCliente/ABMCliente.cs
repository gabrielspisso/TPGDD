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
            string query = "select * from EL_JAPONES_SANGRANDO.Clientes";
            DataTable ds = BD.busqueda(query);
            dataViewModificar.DataSource = ds;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            IniciarSesion.AccionesAdmin accion_ADMIN = new IniciarSesion.AccionesAdmin();
            IniciarSesion.Acciones accion = new IniciarSesion.Acciones();
            accion_ADMIN.Show();
            accion.Show();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
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
                if(BD.ABM("INSERT INTO EL_JAPONES_SANGRANDO.Clientes(cli_DNI,cli_nombre,cli_apellido,cli_fechanac,cli_mail,cli_direccion,cli_CP)values('"+dni+"','"+nombre+"','"+apellido+"','"+fechanacimiento+"','"+mail+"','"+direccion+"','"+textCodigoPostal.Text+"')")>0){
                    MessageBox.Show("Se ingreso correctamente el cliente", "Insertado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textNombre.Text = "";
                    textApellido.Text = "";
                    textDni.Text = "";
                    textMail.Text = "";
                    textCodigoPostal.Text = "";
                    textDireccion.Text = "";
                    dateTimePickerFechaNac.Text = "";
                }
                else{
                    MessageBox.Show("Datos erroneos el cliente", "Error en seleccion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    

                }
               

            }
            
           
        }
    
        }

      
    }

