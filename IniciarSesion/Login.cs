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
                if (BD.tieneRoles(username))
                {
                    this.Hide();
                    BD.setUsuario(username);
                    new SeleccionarRol(username).Show();
                }
                else
                    MessageBox.Show("No tiene ningun rol activo");
            }

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
