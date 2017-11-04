using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.Sucursal
{
    public partial class Eliminar_Modificar_Sucursal_Seleccionada : Form
    {
        private string sucursalNombreViejo;
        public Eliminar_Modificar_Sucursal_Seleccionada(string sucursalNombre)
        {
            InitializeComponent();
            sucursal suc = BD.devolverSucursal(sucursalNombre);
            textDireccion.Text = suc.direccion;
            textNombre.Text = suc.nombre;
            CheckHabilitado.Checked = suc.habilitado;
            TextModificarCodigoPostal.Text = suc.codigoPostal.ToString();
            sucursalNombreViejo = sucursalNombre;

        }

        private void textHabilitado_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Boolean habilitado = CheckHabilitado.Checked;
            
            if(BD.ABM("UPDATE EL_JAPONES_SANGRANDO.Sucursales SET sucursal_nombre = '"+textNombre.Text+"',sucursal_direccion = '"+textDireccion.Text+"',sucursal_estado = '"+habilitado+"' WHERE sucursal_nombre = '" + sucursalNombreViejo + "'") > 0)
                MessageBox.Show("Se pudo modificar el rol por datos erroneos", "Error en seleccion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        }


        private void textNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextModificarCodigoPostal_Click(object sender, EventArgs e)
        {

        }
    }
}
