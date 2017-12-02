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
        public Eliminar_Modificar_Sucursal_Seleccionada(string CP)
        {
            InitializeComponent();
            sucursal suc = BD.devolverSucursal(CP);
            textDireccion.Text = suc.direccion;
            textNombre.Text = suc.nombre;
            CheckHabilitado.Checked = suc.habilitado;
            TextModificarCodigoPostal.Text = suc.codigoPostal.ToString();
            sucursalNombreViejo = suc.nombre;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool habilitado = CheckHabilitado.Checked;

            if (textDireccion.Text == "" || textNombre.Text == "" || TextModificarCodigoPostal.Text == "")
            {
                MessageBox.Show("Complete todos los campos");
                return;
            }
            if (BD.modificarSucursal(habilitado, textNombre.Text, textDireccion.Text, TextModificarCodigoPostal.Text))
            {
                MessageBox.Show("Se pudo modificar la sucursal", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

    }
}
