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
            DataTable tabla = BD.busqueda("select * from EL_JAPONES_SANGRANDO.Empresas where empresa_cuit ='" + cuit + "'");
            textNombre.Text = BD.devolverColumna(tabla, "empresa_nombre");
            textDireccion.Text = BD.devolverColumna(tabla, "empresa_direccion");
            comboBox1.Text = BD.devolverColumna(tabla, "empresa_rubro");
            String cuit2 = BD.devolverColumna(tabla, "empresa_cuit");
            textCuit.Text = cuit2.Substring(0, 1) + "-" +cuit2.Substring(1, cuit.Length-2) + " - "+ cuit2.Substring(cuit.Length-1,1) ;
            CheckHabilitado.Checked = BD.devolverColumna(tabla, "empresa_estado") == "True";
            
        }

        private void Eliminar_Modificar_Empresa_Seleccionada_Load(object sender, EventArgs e)
        {
            string query = "SELECT rubro_desc FROM EL_JAPONES_SANGRANDO.Rubros";
            comboBox1.DataSource = BD.listaDeUnCampo(query);
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (textNombre.Text == "" || textDireccion.Text == "" || comboBox1.Text == "" || textCuit.Text == "")
            {
                MessageBox.Show("Complete todos los campos");
                return;
            }
            int x = CheckHabilitado.Checked ? 1 : 0;
             
           if(!Regex.IsMatch(textNombre.Text, @"^[a-zA-Z]+$")){
            {
                MessageBox.Show("El nombre tiene caracteres invalidos.");
                return;
            }
            if (cambio && !CheckHabilitado.Checked && !BD.todasRendidas(textCuit.Text))
            {
                MessageBox.Show("La Empresa todavia tiene facturas por rendir", "Error en la modificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
            else
            {
                string subquery = "(SELECT rubro_id FROM EL_JAPONES_SANGRANDO.Rubros WHERE rubro_desc = '" + comboBox1.Text + "')";
                if (BD.ABM("UPDATE EL_JAPONES_SANGRANDO.Empresas SET " +
                    "empresa_nombre = '" + textNombre.Text +
                    "',empresa_direccion = '" + textDireccion.Text +
                    "',empresa_rubro = " + subquery +
                    ",empresa_estado = " + x +
                    " WHERE empresa_cuit = '" + textCuit.Text + "'") > 0)
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
