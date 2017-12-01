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

namespace PagoAgilFrba.AbmFactura
{
    public partial class ABMFactura : Form
    {
        public ABMFactura()
        {
            InitializeComponent();

            cargarGrids();
            List<String> lista = BD.empresas();
            lista.Insert(0, "");
            comboboxEliminarEmpresa.DataSource = lista;
            comboBoxModEmpresa.DataSource = lista;
            dateAlta.Value = BD.fechaActual();
            dateVenc.Value = BD.fechaActual();

        }

        private void cargarGrids()
        {

            datagridViewEliminar.Columns.Clear();
            dataGridViewModificarC.Columns.Clear();

            dataGridViewModificarC.DataSource = BD.facturasModif();
            BD.nuevoBoton(dataGridViewModificarC, "Modificar", 8);

            datagridViewEliminar.DataSource = BD.facturasElim();
            BD.nuevoBoton(datagridViewEliminar, "Eliminar", 8);

            listaSeleccionados.Items.Clear();
            txtDni.Text = "";
            txtFactura.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listaSeleccionados.SelectedItems)
            {
                listaSeleccionados.Items.Remove(eachItem);
            }
        }

        private void ABMFactura_Load(object sender, EventArgs e)
        {
            txtEmpresa.DataSource = BD.empresasActivas();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtMonto.Text != "" && txtCantidad.Text != "")
            {
                try
                {
                    Double.Parse(txtMonto.Text);
                    Int32.Parse(txtCantidad.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ingrese valores numericos para el monto y la cantidad");
                    return;
                }
                string[] row = { txtMonto.Text.Replace(',', '.'), txtCantidad.Text };
                var listViewItem = new ListViewItem(row);
                listaSeleccionados.Items.Add(listViewItem);
                txtMonto.Text = "";
                txtCantidad.Text = "";
            }
            else
            {
                MessageBox.Show("Complete todos los campos");
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"^[0-9]+$");

            if (!reg.IsMatch(txtDni.Text)){
                MessageBox.Show("El dni tiene caracteres invalidos");
                return;
            }
            if(DateTime.Compare(dateAlta.Value, dateVenc.Value) < 1){
                MessageBox.Show("La fecha de vencimiento es posterior a la de alta");
                return;
            }
            if (!reg.IsMatch(txtFactura.Text))
            {
                MessageBox.Show("la factura contiene caracteres invalidos");
                return;
            }

            if (! reg.IsMatch(txtFactura.Text))
            {
                MessageBox.Show("la factura contiene caracteres invalidos");
                return;
            }
            String estado = BD.chequearExistenciaYEstadoDelCliente(txtDni.Text);
            if(estado!=""){
                MessageBox.Show("El cliente no "+estado +"en el sistema");
                return;
            }
            if (listaSeleccionados.Items.Count == 0)
            {
                MessageBox.Show("La factura no tiene items");
                return;
            }


            String fechaVenc = dateVenc.Value.ToString("u");
            fechaVenc = fechaVenc.Substring(0, fechaVenc.Length - 1);

            String fechaAlta = dateAlta.Value.ToString("u");
            fechaAlta = fechaAlta.Substring(0, fechaAlta.Length - 1);

            BD.cargarFactura(fechaVenc, fechaAlta, txtFactura.Text, txtDni.Text, txtEmpresa.Text, listaSeleccionados.Items);
            cargarGrids();
        }

        private void datagridViewEliminar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                string numeroDeFactura = datagridViewEliminar.Rows[e.RowIndex].Cells["factura_numero"].Value.ToString();

                if (BD.facturaUnSoloResultado(numeroDeFactura) == "")
                    MessageBox.Show("Factura inexistente", "no se pudo eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (BD.facturaNoPagada(numeroDeFactura))
                {
                    if (BD.eliminarFactura(numeroDeFactura))
                    {
                        MessageBox.Show("Factura eliminada", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarGrids();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la factura, revise los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Ya estaba paga", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textEliminarNombre_TextChanged(object sender, EventArgs e)
        {
            datagridViewEliminar.DataSource = BD.filtroFacturasElim(textEliminarNumeroCliente.Text, textEliminarNumeroFactura.Text, comboboxEliminarEmpresa.Text);
        }

        private void textModNumeroFactura_TextChanged(object sender, EventArgs e)
        {
            dataGridViewModificarC.Columns.Clear();
            dataGridViewModificarC.DataSource = BD.filtroFacturasModif(textModCliente.Text, textModNumeroFactura.Text, comboBoxModEmpresa.Text);
            BD.nuevoBoton(dataGridViewModificarC, "Modificar", 3);

        }

        private void dataGridViewModificarC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                string factura = dataGridViewModificarC.Rows[e.RowIndex].Cells["factura_numero"].Value.ToString();
                string estado = BD.estadoFactura(factura);
                if (estado == "2" || estado == "3")
                {
                    MessageBox.Show("No se pueden modificar facturas " + ((estado == "2")? "cobradas" : "rendidas"));
                }
                else
                {
                    new Eliminar_Modificar_Factura_Seleccionada(factura).ShowDialog();
                    cargarGrids();
                }
            }
        }

        private void comboBoxModEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGrids();
        }

    }
}
