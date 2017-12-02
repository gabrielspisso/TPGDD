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
    public partial class AccionesAdmin : Form,seleccionarFactura
    {
        string rolSeleccionado;
        public AccionesAdmin(string rol)
        {
            rolSeleccionado = rol;
            InitializeComponent();
            
        }
        public AccionesAdmin() {
            InitializeComponent();
        }

        public void setFactura(string factura)
        {
            textFacturaDev.Text = factura;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbmCliente.ABMCliente abmCliente = new AbmCliente.ABMCliente();
            this.Hide();
            abmCliente.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbmEmpresa.ABMEmpresa abmEmpresa = new AbmEmpresa.ABMEmpresa();
            this.Hide();
            abmEmpresa.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AbmRol.ABMRol abmRol = new AbmRol.ABMRol();
            this.Hide();
            abmRol.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbmFactura.ABMFactura abmFactura = new AbmFactura.ABMFactura();
            this.Hide();
            abmFactura.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Sucursal.ABMSucursal abmSucursal = new Sucursal.ABMSucursal();
            this.Hide();
            abmSucursal.Show();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            RegistroPago.Pagos pagos = new RegistroPago.Pagos();
            this.Hide();
            pagos.Show();
        }

        private void AccionesAdmin_Load(object sender, EventArgs e)
        {

            List<string> acciones = BD.funcionalidadesDeRolConDescripcion(rolSeleccionado);

            if (acciones.Count == 0)
            {
                MessageBox.Show("Este rol no tiene funcionalidades asignadas");

                this.Close();
            }
            foreach (Control c in this.tabPage1.Controls)
            {
                if (c is Button)
                {
                    string accion = c.Text.Replace(' ', '_');
                    c.Visible = acciones.Contains(accion);
                }
            }


            

            Acciones.Controls.Remove(tabPage3);
            Acciones.Controls.Remove(tabPage4);
            Acciones.Controls.Remove(tabPage5);


            DateTime fechaActual = BD.fechaActual();
            comboPorcentaje.SelectedIndex = 0;
            
            dateRendicion1.MinDate = new DateTime(fechaActual.Year, fechaActual.Month, 1);
            dateRendicion1.MaxDate = (new DateTime(fechaActual.Year, fechaActual.Month, 1)).AddMonths(1).AddDays(-1);
            dateRendicion1.Value = BD.fechaActual();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            switch (((Button)sender).Text)
            {
                case "ABM ROL":
                    {
                        this.Hide();
                        new AbmRol.ABMRol().ShowDialog();
                        List<string> acciones = BD.funcionalidadesDeRolConDescripcion(rolSeleccionado);

                        if (acciones.Count == 0)
                        {
                            MessageBox.Show("Este rol no tiene funcionalidades asignadas");

                            this.Close();
                        }
                        foreach (Control c in this.tabPage1.Controls)
                        {
                            if (c is Button)
                            {
                                string accion = c.Text.Replace(' ', '_');
                                c.Visible = acciones.Contains(accion);
                            }
                        }

                        this.Show();
                    } break;
                case "LISTADO ESTADISTICO":
                    {
                        this.Hide();
                        new ListadoEstadistico.Listado().ShowDialog();
                        this.Show();

                    } break;
                case "RENDICION DE FACTURAS":
                    {
                        this.Hide();
                        new Rendicion.Rendicion().ShowDialog();
                        this.Show();
                    } break;
                case "DEVOLUCIONES":
                    {
                        this.Hide();
                        new Devolucion.Devolucion().ShowDialog();
                        this.Show();
                    } break;
                case "ABM FACTURA":
                    {
                        this.Hide();
                        new AbmFactura.ABMFactura().ShowDialog();
                        this.Show();
                    } break;
                case "ABM SUCURSAL":
                    {
                        this.Hide();
                        new Sucursal.ABMSucursal().ShowDialog();
                        this.Show();
                    } break;
                case "ABM EMPRESA":
                    {
                        this.Hide();
                        new AbmEmpresa.ABMEmpresa().ShowDialog();
                        new AccionesAdmin(rolSeleccionado).Show();
                    } break;
                case "PAGO DE FACTURAS":
                    {
                        this.Hide();
                        new RegistroPago.Pagos().ShowDialog();
                        this.Show();
                    } break;
                case "ABM CLIENTE":
                    {
                        this.Hide();
                        new AbmCliente.ABMCliente().ShowDialog();
                        this.Show();
                    } break;
                default:
                    {
                        MessageBox.Show("no se creo la ventana pertinente", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } break;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void AccionesAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            new Login().Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            new elegirFactura(this,true).ShowDialog();
        }

        private void lblGanancia_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridRendiciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblCantFacturas_Click(object sender, EventArgs e)
        {

        }

        private void lblImporte_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void dateRendicion1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

    }
}
