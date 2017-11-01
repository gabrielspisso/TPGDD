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
            DataTable tabla = BD.busqueda("select * from EL_JAPONES_SANGRANDO.Clientes where cli_DNI ='"+dni+"'");
            textDNI.Text = BD.devolverColumna(tabla, "cli_DNI");
            textCodigoPostal.Text = BD.devolverColumna(tabla, "cli_CP");
            textMailN.Text = BD.devolverColumna(tabla, "cli_mail");
            textDireccionN.Text = BD.devolverColumna(tabla, "cli_direccion");
            textNombreN.Text = BD.devolverColumna(tabla, "cli_nombre");
            textApellidoN.Text = BD.devolverColumna(tabla, "cli_apellido");
            CheckHabilitado.Checked = BD.devolverColumna(tabla, "cli_estado") == "True";
            
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ABMCliente abmCliente = new ABMCliente();
            abmCliente.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x = CheckHabilitado.Checked ? 1 : 0;
            if (BD.ABM("UPDATE EL_JAPONES_SANGRANDO.Clientes SET cli_direccion = '" + textDireccionN.Text +
                "',cli_CP = '" + textCodigoPostal.Text +
                "',cli_mail = '" + textMailN.Text +
                "',cli_nombre = '" + textNombreN.Text +
                "',cli_apellido = '" + textApellidoN.Text +
                "',cli_fechanac = '" + dateTimePickerFechaNac.Text +
                "',cli_estado = '" + x +
                "' WHERE cli_DNI = '" + textDNI.Text + "'") > 0){
                    this.Close();
                    MessageBox.Show("Se pudo modificar el rol", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            else{
                MessageBox.Show("Error en los datos", "Error en la modificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
        }


    }
}
