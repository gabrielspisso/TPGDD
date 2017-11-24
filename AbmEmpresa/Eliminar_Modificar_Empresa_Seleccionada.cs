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
    public partial class Eliminar_Modificar_Empresa_Seleccionada : Form
    {
        bool cambio = false;
        public Eliminar_Modificar_Empresa_Seleccionada(string cuit)
 
        {
            InitializeComponent();
            DataTable tabla = BD.empresa(cuit);
            textNombre.Text = BD.devolverColumna(tabla, "empresa_nombre");
            textDireccion.Text = BD.devolverColumna(tabla, "empresa_direccion");
            comboBox1.Text = BD.devolverColumna(tabla, "empresa_rubro");
            textCuit.Text = BD.devolverColumna(tabla, "empresa_cuit");
            CheckHabilitado.Checked = BD.devolverColumna(tabla, "empresa_estado") == "True";
        }

        private void Eliminar_Modificar_Empresa_Seleccionada_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = BD.rubros();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (textNombre.Text == "" || textDireccion.Text == "" || comboBox1.Text == "" || textCuit.Text == "")
            {
                MessageBox.Show("Complete todos los campos");
                return;
            }
            int x = CheckHabilitado.Checked ? 1 : 0;
             
            if (cambio && !CheckHabilitado.Checked && !BD.todasRendidas(textCuit.Text))
            {
                MessageBox.Show("La Empresa todavia tiene facturas por rendir", "Error en la modificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
            else
            {
                if (BD.modificarEmpresa(x, textNombre.Text, textDireccion.Text, textCuit.Text, comboBox1.Text))
                {
                    this.Close();
                    MessageBox.Show("Se pudo modificar la Empresa", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error en los datos", "Error en la modificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
          
           }  
        }

        private void CheckHabilitado_CheckedChanged(object sender, EventArgs e)
        {
            cambio = !cambio;
        }
    }
}
