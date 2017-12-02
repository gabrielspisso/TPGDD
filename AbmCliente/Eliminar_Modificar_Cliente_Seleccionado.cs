using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmCliente
{
    public partial class Eliminar_Modificar_Cliente_Seleccionado : Form
    {
        string mailOriginal;
        public Eliminar_Modificar_Cliente_Seleccionado(string dni)
        {
            InitializeComponent();
            DataTable tabla = BD.cliente(dni);
            textDNI.Text = BD.devolverColumna(tabla, "cliente_DNI");
            textCodigoPostal.Text = BD.devolverColumna(tabla, "cliente_codigo_postal");
            
            textMailN.Text = BD.devolverColumna(tabla, "cliente_mail");
            mailOriginal = textMailN.Text;

            textDireccionN.Text = BD.devolverColumna(tabla, "cliente_direccion");
            textNombreN.Text = BD.devolverColumna(tabla, "cliente_nombre");
            textApellidoN.Text = BD.devolverColumna(tabla, "cliente_apellido");
            txttelefono.Text = BD.devolverColumna(tabla, "cliente_telefono");
            CheckHabilitado.Checked = BD.devolverColumna(tabla, "cliente_estado") == "True";
            string fecha = BD.devolverColumna(tabla, "cliente_fecha_nacimiento");
            dateTimePickerFechaNac.Value = Convert.ToDateTime(fecha);
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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
            if (!System.Text.RegularExpressions.Regex.IsMatch(textCodigoPostal.Text, @"^\d+$"))
            {
                MessageBox.Show("Sólo se permiten numeros en el codigo postal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Regex expEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!expEmail.IsMatch(textMailN.Text))
            {
                MessageBox.Show("El formato del mail es incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (BD.tieneMailRepetido(textMailN.Text) && textMailN.Text != mailOriginal)
            {
                MessageBox.Show("Ya existe un cliente con ese mail", "Error en seleccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
