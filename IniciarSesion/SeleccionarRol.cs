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
    public partial class SeleccionarRol : Form
    {
        public SeleccionarRol(string username)
        {
            InitializeComponent();
            comboRoles.DataSource = BD.roles(username);
            if(comboRoles.Items.Count == 0){
                MessageBox.Show("Este rol no tiene funcionalidades asignadas");
                BD.setUsuario("");
                this.Close();
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string rol = comboRoles.SelectedValue.ToString();


            this.Hide();
            
            new SeleccionarSucursal(rol).Show();
            
        }
    }
}
