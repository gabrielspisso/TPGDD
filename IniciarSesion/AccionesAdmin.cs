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
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTrimestre.DropDownStyle = ComboBoxStyle.DropDownList;
            comboEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPorcentaje.DropDownStyle = ComboBoxStyle.DropDownList;
            dataGridEstadisticas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            string factura_numero = textFacturaDev.Text;
            string motivo = richTextDev.Text;

            if (factura_numero != "" && motivo != "")
            {
                string x = BD.estadoFactura(factura_numero);
                if (x == "")
                {
                    MessageBox.Show("Esta factura no existe","", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int factura_estado = Int32.Parse(x);
                if (factura_estado != 2)
                {
                    string razon = (factura_estado == 1) ? "no se ha pagado" : (factura_estado == 3) ? "ya se ha rendido" : "se ha eliminado";
                    MessageBox.Show("Esta factura no puede devolverse debido a que " + razon, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (BD.devolverFactura(factura_numero, motivo))
                    {
                        MessageBox.Show("Factura devuelta", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textFacturaDev.Text = "";
                        richTextDev.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("No se pudo devolver la factura", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else
            {
                MessageBox.Show("Debe Completar ambos campos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


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
            int tipo = cmbTipo.SelectedIndex;
            int trimestre = cmbTrimestre.SelectedIndex + 1;
            string anio = añoNUD.Value.ToString();

            if (cmbTipo.Text == "Seleccione..." || cmbTrimestre.Text == "Seleccione")
            {
                MessageBox.Show("Complete todos los campos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                switch (tipo)
                {
                    case 0://Porcentaje de facturas cobradas por empresa
                        {
                            dataGridEstadisticas.DataSource = BD.porcentajeDeFacturasTop(trimestre, anio);
                        };
                        break;
                    case 1://Empresas con mayor monto rendido
                        {
                            dataGridEstadisticas.DataSource = BD.mayorMontoRendidoTop(trimestre, anio);
                        };
                        break;
                    case 2://Clientes con mas pagos
                        {
                            dataGridEstadisticas.DataSource = BD.clientesConMasPagosTop(trimestre, anio);
                        };
                        break;
                    case 3://Clientes cumplidores
                        {
                            dataGridEstadisticas.DataSource = BD.clientesCumplidoresTop(trimestre, anio);
                        };
                        break;
                }
            }
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            RegistroPago.Pagos pagos = new RegistroPago.Pagos();
            this.Hide();
            pagos.Show();
        }

        private void AccionesAdmin_Load(object sender, EventArgs e)
        {

            List<String> lista = BD.funcionalidadesDeRolConDescripcion(rolSeleccionado);

            if (lista.Count == 0)
            {
                MessageBox.Show("Este rol no tiene funcionalidades asignadas");

                this.Close();
            }
            comboAccion.DropDownStyle = ComboBoxStyle.DropDownList;
            comboAccion.DataSource = lista;
            Acciones.Controls.Remove(tabPage3);
            Acciones.Controls.Remove(tabPage4);
            Acciones.Controls.Remove(tabPage5);


            DateTime fechaActual = BD.fechaActual();
            comboPorcentaje.SelectedIndex = 0;
            List<string> empresas = BD.empresasActivasConNombre();
            empresas.Insert(0, "");
            comboEmpresa.DataSource = empresas;
            dateRendicion1.MinDate = new DateTime(fechaActual.Year, fechaActual.Month, 1);
            dateRendicion1.MaxDate = (new DateTime(fechaActual.Year, fechaActual.Month, 1)).AddMonths(1).AddDays(-1);
            dateRendicion1.Value = BD.fechaActual();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            switch (comboAccion.SelectedValue.ToString())
            {
                case "ABM_ROL":
                    {
                        this.Hide();
                        new AbmRol.ABMRol().ShowDialog();
                        comboAccion.DataSource = BD.funcionalidadesDeRolConDescripcion(rolSeleccionado);
                        if (comboAccion.Items.Count == 0)
                        {
                            MessageBox.Show("Este rol no tiene funcionalidades asignadas");

                            this.Close();
                        }
                        else
                            this.Show();
                    } break;
                case "LISTADO_ESTADISTICO":
                    {
                        Acciones.Controls.Remove(tabPage4);
                        Acciones.Controls.Add(tabPage4);
                        Acciones.SelectTab(tabPage4);

                    } break;
                case "RENDICION_DE_FACTURAS_COBRADAS":
                    {
                        Acciones.Controls.Remove(tabPage3);
                        Acciones.Controls.Add(tabPage3);
                        Acciones.SelectTab(tabPage3);
                    } break;
                case "DEVOLUCION":
                    {
                        Acciones.Controls.Remove(tabPage5);
                        Acciones.Controls.Add(tabPage5);
                        Acciones.SelectTab(tabPage5);
                    } break;
                case "ABM_FACTURA":
                    {
                        this.Hide();
                        new AbmFactura.ABMFactura().ShowDialog();
                        this.Show();
                    } break;
                case "ABM_SUCURSAL":
                    {
                        this.Hide();
                        new Sucursal.ABMSucursal().ShowDialog();
                        this.Show();
                    } break;
                case "ABM_EMPRESA":
                    {
                        this.Hide();
                        new AbmEmpresa.ABMEmpresa().ShowDialog();
                        new AccionesAdmin(rolSeleccionado).Show();
                    } break;
                case "REGISTRO_DE_PAGO_DE_FACTURAS":
                    {
                        this.Hide();
                        new RegistroPago.Pagos().ShowDialog();
                        this.Show();
                    } break;
                case "ABM_CLIENTE":
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
            if (comboEmpresa.Text == "")
            {
                MessageBox.Show("Debe seleccionar una empresa", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            String fecharendicion = dateRendicion1.Value.ToString("u");
            fecharendicion = fecharendicion.Substring(0, fecharendicion.Length - 1);
            if (BD.seRindioEsteMes(dateRendicion1.Value.Month, dateRendicion1.Value.Year, comboEmpresa.Text))
            {
                MessageBox.Show("Esta empresa ya rindio en este mes", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (dataGridRendiciones.Rows.Count == 1)//El data grid automaticamente rellena automaticamente una fila vacia al final
            {
                MessageBox.Show("No hay facturas para realizar la rendicion");
                return;
            }

            if (BD.actualizarFacturasRendicion(dateRendicion1, comboEmpresa.Text, lblImporte.Text, comboPorcentaje.Text, lblCantFacturas.Text, lblGanancia.Text, dataGridRendiciones))
            {
                MessageBox.Show("Rendicion registrada");
                comboBox1_SelectedIndexChanged(null, null);
                lblCantFacturas.Text = "0";
                lblGanancia.Text = "0";
                lblImporte.Text = "0";
           }
            else{
                MessageBox.Show("No se pudo realizar la rendicion");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCantFacturas.Text = "0";
            lblGanancia.Text = "0";
            lblImporte.Text = "0";
            if (comboEmpresa.Text == "")
            {
                dataGridRendiciones.DataSource = null;
                return;
            }

            DateTime fechaActual = BD.fechaActual();
            dataGridRendiciones.DataSource = BD.facturasCobradasDeEmpresa(fechaActual, comboEmpresa.Text);
          

            double porcentaje = double.Parse(comboPorcentaje.Text)/100;
            DataTable dt = BD.facturasTotalGanancias(fechaActual, porcentaje, comboEmpresa.Text);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                lblCantFacturas.Text = row["cantidad_facturas"].ToString();
                lblImporte.Text = row["total"].ToString();
                lblGanancia.Text = row["ganancia"].ToString();
            }
        }

        private void AccionesAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            new Login().Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            new elegirFactura(this,true).ShowDialog();
        }

    }
}
