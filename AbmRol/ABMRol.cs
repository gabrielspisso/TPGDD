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
            actualizarTodo();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            String rol = txtRolAgregar.Text;
            if(rol==""){

                MessageBox.Show("No selecciono rol", "Error en seleccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
}      
            //BD.crearRol(rol);

            string queryInsert = "INSERT INTO EL_JAPONES_SANGRANDO.Roles (rol_nombre) values ('" + rol +"')";
            string queryUpdate = "INSERT INTO EL_JAPONES_SANGRANDO.Rol_Funcionalidad (rol_Funcionalidad_rol,rol_Funcionalidad_funcionalidad) values ";
            string funcionalidades = "";
            foreach (DataGridViewRow r in funcionalidadesDGV.Rows){
               if(r != null)
                   {
                       DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)r.Cells["habilitado"];

                       if (chk.Value != null && chk.Value.ToString() == "T")
                {
                    string funcionalidadId = r.Cells["funcionalidad_id"].Value.ToString();
                    funcionalidades += "('"+rol+"',"+funcionalidadId+"),";
                }
                   }
            }
            if(funcionalidades == ""){
                MessageBox.Show("No selecciono funcionalidades", "Error en seleccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
            funcionalidades = funcionalidades.Substring(0, funcionalidades.Length - 1);
            queryUpdate += funcionalidades;
            List<string> queries = new List<string>();
            queries.Add(queryInsert);
            queries.Add(queryUpdate);
            if (BD.correrStoreProcedure(queries) > 0)
            {
                MessageBox.Show("Rol cargado correctamente", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                actualizarTodo();
            }
            else
            {
                MessageBox.Show("Error al cargar el rol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void funcionalidadesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void actualizarTodo()
        {
            funcionalidadesDGV.Columns.Clear();
            dataGridFuncModificar.Columns.Clear();
            funcionalidadesDGV.DataSource = BD.busqueda("select * from EL_JAPONES_SANGRANDO.Funcionalidades");
            dataGridFuncModificar.DataSource = BD.busqueda("select * from EL_JAPONES_SANGRANDO.Funcionalidades");
            DataGridViewCheckBoxColumn col1 = new DataGridViewCheckBoxColumn();
            col1.TrueValue = "T";
            col1.FalseValue = "F";
            funcionalidadesDGV.Columns.Add(col1);
            col1.Name = "habilitado";

            col1.HeaderText = "habilitado";

            DataGridViewCheckBoxColumn col2 = new DataGridViewCheckBoxColumn();
            col2.TrueValue = "T";
            col2.FalseValue = "F";
            dataGridFuncModificar.Columns.Add(col2);
            col2.Name = "habilitado";

            col2.HeaderText = "habilitado";


            dataGridFuncModificar.Columns[0].ReadOnly = true;
            dataGridFuncModificar.Columns[1].ReadOnly = true;
            dataGridFuncModificar.Columns[2].ReadOnly = false;


            comboEliminar.DataSource = BD.listaDeUnCampo("Select rol_nombre from EL_JAPONES_SANGRANDO.Roles where rol_estado=1");


            comboModificar.DataSource = BD.listaDeUnCampo("Select rol_nombre from EL_JAPONES_SANGRANDO.Roles");
            comboModificar.SelectedText = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
           if( BD.ABM("UPDATE EL_JAPONES_SANGRANDO.Roles SET rol_estado = 0 WHERE rol_nombre = '" + comboEliminar.SelectedValue.ToString() + "'")>0){
               MessageBox.Show("Se elimino el rol");
               actualizarTodo();
           }
           else{
               MessageBox.Show("no se pudo eliminar el rol");
           }
        }

        


        private void dataGridFuncModificar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int valor = checkBox2.Checked ? 1 : 0;
            string rol = comboModificar.SelectedValue.ToString();

            string queryUpdate = "INSERT INTO EL_JAPONES_SANGRANDO.Rol_Funcionalidad (rol_Funcionalidad_rol,rol_Funcionalidad_funcionalidad) values ";

            string funcionalidades = "";
            foreach (DataGridViewRow r in dataGridFuncModificar.Rows)
            {
                if (r != null)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)r.Cells["habilitado"];

                    if (chk.Value != null && chk.Value.ToString() == "T")
                    {
                        string funcionalidadId = r.Cells["funcionalidad_id"].Value.ToString();
                        funcionalidades += "('" + rol + "'," + funcionalidadId + "),";
                    }
                }
            }
            if(funcionalidades ==""){
                queryUpdate= "";
             }
            else
            {
            funcionalidades = funcionalidades.Substring(0, funcionalidades.Length - 1);
            }
            List<String> lista = new List<string>();
            string update = "UPDATE EL_JAPONES_SANGRANDO.Roles SET rol_estado = " + valor + " WHERE rol_nombre = '" + rol + "'";
            string delete = "DELETE FROM EL_JAPONES_SANGRANDO.Rol_Funcionalidad where rol_Funcionalidad_rol = '" + rol + "'";
            lista.Add(update);
            lista.Add(delete);
            lista.Add(queryUpdate + funcionalidades);
            if (BD.correrStoreProcedure(lista) > 0)
            {
                MessageBox.Show("Rol Actualizado", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                actualizarTodo();
            }
            else
            {
                MessageBox.Show("No se pudo modificar el rol, verifique sus selecciones", "Error en seleccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboModificar_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<String> c = BD.listaDeUnCampo("select rol_Funcionalidad_funcionalidad from EL_JAPONES_SANGRANDO.Rol_Funcionalidad where  rol_funcionalidad_rol = '" + comboModificar.SelectedValue.ToString() + "'");
                
            foreach (DataGridViewRow r in dataGridFuncModificar.Rows)
            {
                if (c.Contains(r.Cells["funcionalidad_id"].Value.ToString()))
                {

                    r.Cells["habilitado"].Value = "T";
                }
                else
                    r.Cells["habilitado"].Value = "F";
            }
            string w = BD.consultaDeUnSoloResultado("select rol_estado from EL_JAPONES_SANGRANDO.Roles where rol_nombre = '" + comboModificar.SelectedValue.ToString() + "'");

            checkBox2.Checked = w == "True";
        }

        private void ABMRol_Load(object sender, EventArgs e)
        {

        }

    }
}
