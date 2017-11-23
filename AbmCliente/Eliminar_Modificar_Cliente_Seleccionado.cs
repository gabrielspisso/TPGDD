using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmCliente
{
    public partial class Eliminar_Modificar_Cliente_Seleccionado : Form
    {
        
        public Eliminar_Modificar_Cliente_Seleccionado(string dni)
        {
            InitializeComponent();
            DataTable tabla = BD.busqueda("select * from EL_JAPONES_SANGRANDO.Clientes where cliente_DNI ='"+dni+"'");
            textDNI.Text = BD.devolverColumna(tabla, "cliente_DNI");
            textCodigoPostal.Text = BD.devolverColumna(tabla, "cliente_codigo_postal");
            textMailN.Text = BD.devolverColumna(tabla, "cliente_mail");
            textDireccionN.Text = BD.devolverColumna(tabla, "cliente_direccion");
            textNombreN.Text = BD.devolverColumna(tabla, "cliente_nombre");
            textApellidoN.Text = BD.devolverColumna(tabla, "cliente_apellido");
            txttelefono.Text = BD.devolverColumna(tabla, "cliente_telefono");
            CheckHabilitado.Checked = BD.devolverColumna(tabla, "cliente_estado") == "True";
            
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ABMCliente abmCliente = new ABMCliente();
            abmCliente.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textDNI.Text, @"^\d+$"))
            {
                MessageBox.Show("Sólo se permiten numeros en el DNI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txttelefono.Text, @"^\d+$"))
            {
                MessageBox.Show("Sólo se permiten numeros en el Telefono", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textNombreN.Text.Trim() == "" | textApellidoN.Text.Trim() == "" | txttelefono.Text.Trim() == "" | textDNI.Text.Trim() == "" | textDireccionN.Text.Trim() == ""  | dateTimePickerFechaNac.Text.Trim() == "" )
            {
                MessageBox.Show("Faltan completar campos obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            String fechaVenc = dateTimePickerFechaNac.Value.ToString("u");
            fechaVenc = fechaVenc.Substring(0, fechaVenc.Length - 1);

            if(BD.modificarCliente(txttelefono.Text, textDireccionN.Text, textCodigoPostal.Text, textMailN.Text, textNombreN.Text, textApellidoN.Text, fechaVenc, textDNI.Text, CheckHabilitado.Checked)){
                this.Close();
            }   
        }

        private void dateTimePickerFechaNac_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
