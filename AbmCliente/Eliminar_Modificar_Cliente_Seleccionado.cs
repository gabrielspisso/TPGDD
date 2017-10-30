using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmCliente
{
    public partial class Eliminar_Modificar_Cliente_Seleccionado : Form
    {
        public Eliminar_Modificar_Cliente_Seleccionado()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ABMCliente abmCliente = new ABMCliente();
            abmCliente.Show();
        }
    }
}
