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
                
                this.Hide();
                string x =BD.consultaDeUnSoloResultado("select count(*) from EL_JAPONES_SANGRANDO.Usuario_Rol where Usuario_Rol_usuario = '"+ username+"'");
                if (Int32.Parse(x) > 0)
                {
                    BD.setUsuario(username);
                    new SeleccionarRol(username).Show();
                }
                else
                    MessageBox.Show("No tiene ningun rol activo");
            }

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
