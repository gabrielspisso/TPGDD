using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class ABMEmpresa : Form
    {
        public ABMEmpresa()
        {
            InitializeComponent();

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            volverEmpresas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            volverEmpresas();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            volverEmpresas();
        }

        private void volverEmpresas()
        {
            this.Hide();
            IniciarSesion.AccionesAdmin accion_ADMIN = new IniciarSesion.AccionesAdmin();
            IniciarSesion.Acciones accion = new IniciarSesion.Acciones();
            accion_ADMIN.Show();
            accion.Show();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string rubro = comboNuevoRubro.Text;
            string nombre = textNuevoNombre.Text;
            string direccion = textNuevoDirec.Text;
            string cuit = textNuevoCuit.Text+ "-" + textBox1.Text + "-" + textBox2.Text;
            
            if( rubro == "" ||nombre == ""|| direccion == "" ||cuit == ""){
                MessageBox.Show("Complete todos los campos");
                return;
            }
            Regex reg = new Regex("^[0-9]{2}-[0-9]{8}-[0-9]{1}$");
            if (!reg.IsMatch(cuit))
            {
                MessageBox.Show("No se respeta la correcta composicion del CUIT");
                return;
            }
            if(!Regex.IsMatch(nombre, @"^[a-zA-Z]+$")){
                MessageBox.Show("El nombre tiene caracteres invalidos.");
                return;               
            }

            if (BD.crearEmpresa(rubro, nombre, direccion, cuit))
            {
                MessageBox.Show("La empresa fue creada", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarGrids();
            }
            else
            {
                MessageBox.Show("Ya existe una empresa con el mismo cuit ", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ABMEmpresa_Load(object sender, EventArgs e)
        {
            BD.nuevoBoton(dataGridViewModificarC, "Modificar", 5);
            BD.nuevoBoton(dataGridEliminar, "Eliminar", 5);
            cargarGrids();
        }

        private void cargarGrids()
        {
            List<String> lista = BD.rubros();
            comboNuevoRubro.DataSource = lista;
            lista.Insert(0, "");
            comboModRubro.DataSource = lista;
            comboElimRubro.DataSource = lista;

            dataGridViewModificarC.Columns.Clear();
            dataGridViewModificarC.DataSource = BD.actualizarEmpresasModif();
            BD.nuevoBoton(dataGridViewModificarC, "Modificar", 5);

            dataGridEliminar.Columns.Clear();
            dataGridEliminar.DataSource = BD.actualizarEmpresasElim();
            BD.nuevoBoton(dataGridEliminar, "Eliminar", 5);


        }

        private void textElimNombre_TextChanged(object sender, EventArgs e)
        {
            dataGridEliminar.DataSource = BD.filtroEmpresasElim(textElimNombre.Text, textElimCuit.Text, comboElimRubro.Text);
        }

        private void textModNombre_TextChanged(object sender, EventArgs e)
        {
            dataGridViewModificarC.DataSource = BD.filtroEmpresasModif(textModNombre.Text, textModCuit.Text, comboModRubro.Text);

        }

        private void dataGridEliminar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                string x = dataGridEliminar.Rows[e.RowIndex].Cells["empresa_cuit"].Value.ToString();
                if (BD.todasRendidas(x))
                {
                    if (BD.eliminarEmpresa(x))
                    {
                        MessageBox.Show("Empresa eliminada", "Empresa eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarGrids();
                    }
                }
                else
                {
                    MessageBox.Show("La Empresa todavia tiene facturas por rendir", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
        }

        private void dataGridViewModificarC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                string cuit = dataGridViewModificarC.Rows[e.RowIndex].Cells["empresa_cuit"].Value.ToString();
                this.Hide();
                new Eliminar_Modificar_Empresa_Seleccionada(cuit).ShowDialog();
                this.Show();
                cargarGrids();
            }
        }
    }
}
