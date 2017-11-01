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
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            String rol = txtRolAgregar.Text;
            if(rol=="")
                MessageBox.Show("No selecciono rol", "Error en seleccion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            BD.crearRol(rol);
            
            foreach (DataGridViewRow r in funcionalidadesDGV.SelectedRows){
                string funcionalidadId = r.Cells[0].Value.ToString();
                BD.asignarFuncionalidadAlRol(rol, funcionalidadId);
            }

        }

        private void funcionalidadesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ABMRol_Load(object sender, EventArgs e)
        {
            funcionalidadesDGV.DataSource = BD.busqueda("select * from EL_JAPONES_SANGRANDO.Funcionalidades");
            dataGridFuncModificar.DataSource = funcionalidadesDGV.DataSource;//PERFORMANCEEEE

            comboEliminar.DataSource = BD.listaDeUnCampo("Select rol_nombre from EL_JAPONES_SANGRANDO.Roles where rol_estado=1");

            comboModificar.DataSource = BD.listaDeUnCampo("Select rol_nombre from EL_JAPONES_SANGRANDO.Roles");


        }

        private void button3_Click(object sender, EventArgs e)
        {
            BD.ABM("UPDATE EL_JAPONES_SANGRANDO.Roles SET rol_estado = 0 WHERE rol_nombre = '" + comboEliminar.SelectedValue.ToString() + "'");
            comboEliminar.DataSource = BD.listaDeUnCampo("Select rol_nombre from EL_JAPONES_SANGRANDO.Roles where rol_estado=1");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int valor = checkBox2.Checked ? 1 : 0;
            string rol = comboModificar.SelectedValue.ToString();
            BD.ABM("UPDATE EL_JAPONES_SANGRANDO.Roles SET rol_estado = " + valor + " WHERE rol_nombre = '" + rol+ "'");
            BD.ABM("DELETE FROM EL_JAPONES_SANGRANDO.RolFuncionalidades where rolf_rol = '" + rol + "'");

            foreach (DataGridViewRow r in dataGridFuncModificar.SelectedRows)
            {
                string funcionalidadId = r.Cells[0].Value.ToString();
                BD.asignarFuncionalidadAlRol(rol, funcionalidadId);
            }
        }

    }
}
