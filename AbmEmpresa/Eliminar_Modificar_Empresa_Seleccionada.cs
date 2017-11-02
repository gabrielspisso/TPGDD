using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class Eliminar_Modificar_Empresa_Seleccionada : Form
    {
        bool cambio = false;
        public Eliminar_Modificar_Empresa_Seleccionada(string cuit)
        {
            InitializeComponent();
            DataTable tabla = BD.busqueda("select * from EL_JAPONES_SANGRANDO.Empresas where emp_CUIT ='" + cuit + "'");
            textNombre.Text = BD.devolverColumna(tabla, "emp_nombre");
            textDireccion.Text = BD.devolverColumna(tabla, "emp_direccion");
            comboBox1.Text = BD.devolverColumna(tabla, "emp_rubro");
            textCuit.Text = BD.devolverColumna(tabla, "emp_CUIT");
            CheckHabilitado.Checked = BD.devolverColumna(tabla, "emp_estado") == "True";
            
        }

        private void Eliminar_Modificar_Empresa_Seleccionada_Load(object sender, EventArgs e)
        {
            string query = "SELECT rubro_desc FROM EL_JAPONES_SANGRANDO.Rubros";
            comboBox1.DataSource = BD.listaDeUnCampo(query);
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int x = CheckHabilitado.Checked ? 1 : 0;
            if (cambio && !CheckHabilitado.Checked && !BD.todasRendidas(textCuit.Text))
            {
                MessageBox.Show("La Empresa todavia tiene facturas por rendir", "Error en la modificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
            else
            {
                string subquery = "(SELECT rubro_id FROM EL_JAPONES_SANGRANDO.Rubros WHERE rubro_desc = '" + comboBox1.Text + "')";
                if (BD.ABM("UPDATE EL_JAPONES_SANGRANDO.Empresas SET " +
                    "emp_nombre = '" + textNombre.Text +
                    "',emp_direccion = '" + textDireccion.Text +
                    "',emp_rubro = " + subquery +
                    ",emp_estado = " + x +
                    " WHERE emp_CUIT = '" + textCuit.Text + "'") > 0)
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
