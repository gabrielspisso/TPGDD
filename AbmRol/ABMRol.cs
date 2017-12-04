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
            txtRol.Text = "";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            String rol = txtRolAgregar.Text;
            if(rol==""){

                MessageBox.Show("No ingreso nombre del nuevo rol", "Error en seleccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }      

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

            if (BD.crearRol(rol, funcionalidades))
            {
                MessageBox.Show("Rol cargado correctamente", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                actualizarTodo();
            }
            else
            {
                MessageBox.Show("Ya existe un rol con ese nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void actualizarTodo()
        {
            funcionalidadesDGV.Columns.Clear();
            dataGridFuncModificar.Columns.Clear();
            funcionalidadesDGV.DataSource = BD.funcionalidades();
            dataGridFuncModificar.DataSource = BD.funcionalidades();
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
            txtRolAgregar.Text = "";

            dataGridFuncModificar.Columns[0].ReadOnly = true;
            dataGridFuncModificar.Columns[1].ReadOnly = true;
            dataGridFuncModificar.Columns[2].ReadOnly = false;


            comboEliminar.DataSource = BD.rolesActivos();


            comboModificar.DataSource = BD.roles();
            comboModificar.SelectedItem = null;

            txtRol.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (BD.eliminarRol(comboEliminar.SelectedValue.ToString()))
            {
               MessageBox.Show("Se elimino el rol");
               actualizarTodo();
           }
           else{
               MessageBox.Show("no se pudo eliminar el rol");
           }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            int valor = checkBox2.Checked ? 1 : 0;
            if (comboModificar.SelectedItem == null)
            {
                MessageBox.Show("No selecciono ningun rol");
                return;
            }
            if (txtRol.Text.Trim() == "")
            {
                MessageBox.Show("El campo del nuevo nombre no puede estar vacio");
                return;
            }
            string rol = comboModificar.SelectedValue.ToString();
            if (rol != txtRol.Text)
            {
                if (BD.existeRol(txtRol.Text))
                {
                    MessageBox.Show("Ya existe un rol con ese nombre");
                    return;
                }

            }

            string funcionalidades = "";
            foreach (DataGridViewRow r in dataGridFuncModificar.Rows)
            {
                if (r != null)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)r.Cells["habilitado"];

                    if (chk.Value != null && chk.Value.ToString() == "T")
                    {
                        string funcionalidadId = r.Cells["funcionalidad_id"].Value.ToString();
                        funcionalidades += "('" + txtRol.Text + "'," + funcionalidadId + "),";
                    }
                }
            }
            if (BD.modificarRol(valor, rol, funcionalidades, txtRol.Text))
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
            if(comboModificar.SelectedItem != null){

                List<String> c = BD.funcionalidadesDeRol(comboModificar.SelectedValue.ToString());
                
            foreach (DataGridViewRow r in dataGridFuncModificar.Rows)
            {
                if (c.Contains(r.Cells["funcionalidad_id"].Value.ToString()))
                {
                    r.Cells["habilitado"].Value = "T";
                }
                else
                    r.Cells["habilitado"].Value = "F";
            }
            string w = BD.estadoDeRol(comboModificar.SelectedValue.ToString());
            txtRol.Text = comboModificar.SelectedValue.ToString();
            checkBox2.Checked = w == "True";
            }
        }

        private void dataGridFuncModificar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
