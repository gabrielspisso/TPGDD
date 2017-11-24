using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.IniciarSesion
{
    public partial class SeleccionarSucursal : Form
    {
        public SeleccionarSucursal()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            BD.setSucursal(comboSucursales.SelectedValue.ToString());
            new AccionesAdmin("cobrador").Show();
            this.Hide();
            
        }

        private void SeleccionarSucursal_Load(object sender, EventArgs e)
        {
            comboSucursales.DataSource = BD.sucursalesDeUsuario();
            if (comboSucursales.Items.Count == 0)
            {
                MessageBox.Show("El usuario no tenia sucursales asignadas", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                new Login().Show();
                this.Close();
                
            }
        }
    }
}
