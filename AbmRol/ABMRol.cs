using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmRol
{
    public partial class ABMRol : Form
    {
        public ABMRol()
        {
            InitializeComponent();
            string query = "select * from EL_JAPONES_SANGRANDO.Funcionalidades";
            DataTable ds = BD.busqueda(query);
            funcionalidadesDGV.DataSource = ds;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void funcionalidadesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
