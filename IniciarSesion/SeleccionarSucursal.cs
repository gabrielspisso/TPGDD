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
        private string rol;
        public SeleccionarSucursal(string rol2)
        {
            InitializeComponent();
            rol = rol2;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            BD.setSucursal(comboSucursales.SelectedValue.ToString());
            new AccionesAdmin(rol).Show();
            this.Hide();
            
        }

        private void SeleccionarSucursal_Load(object sender, EventArgs e)
        {
            comboSucursales.DataSource = BD.sucursalesDeUsuario();
            if (comboSucursales.Items.Count == 0)
            {
                MessageBox.Show("El usuario no tiene sucursales asignadas", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                new Login().Show();
                this.Close();
            }
            if (comboSucursales.Items.Count == 1)
            {
                BD.setSucursal(comboSucursales.SelectedValue.ToString());
                new AccionesAdmin(rol).Show();
                this.Close();
            }
        }
    }
}
