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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = txtUsername.Text;
            String password = txtPassword.Text;

            if (BD.autenticacionCorrecta(username, password))
            {
                MessageBox.Show("todo bien", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Hide();
                new SeleccionarRol(username).Show();
            }
            else
                MessageBox.Show("Invalid username", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
