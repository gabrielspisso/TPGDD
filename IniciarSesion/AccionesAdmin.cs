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
    public partial class AccionesAdmin : Form
    {
        public AccionesAdmin(string rol)
        {
            string rolSeleccionado = rol;
            InitializeComponent();
            string query = "select (select func_desc from EL_JAPONES_SANGRANDO.Funcionalidades where func_id = rolf_func ) from EL_JAPONES_SANGRANDO.RolFuncionalidades where rolf_rol = '" + rolSeleccionado + "'";
            List<String> lista = BD.listaDeUnCampo(query);
            comboAccion.DataSource = lista;
            Acciones.Controls.Remove(tabPage3);
            Acciones.Controls.Remove(tabPage4);
            Acciones.Controls.Remove(tabPage5);


        }
        public AccionesAdmin() {
            InitializeComponent();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string fact_num = textFacturaDev.Text;
            string motivo = richTextDev.Text;

            if (fact_num != "" && motivo != "")
            {
                DataTable dt = BD.busqueda("SELECT fact_estado FROM EL_JAPONES_SANGRANDO.Facturas WHERE fact_num = " + fact_num);
                int fact_estado = Int32.Parse(BD.devolverColumna(dt, "fact_estado"));
                if (fact_estado != 2)
                {
                    string razon = (fact_estado == 1) ? "no se ha pagado" : (fact_estado == 3) ? "ya se ha rendido" : "se ha eliminado";
                    MessageBox.Show("Esta factura no puede devolverse debido a que " + razon, "Al pique quique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    List<string> queries = new List<string>();
                    string insert = "INSERT INTO EL_JAPONES_SANGRANDO.Devoluciones (dev_desc,dev_fact)values('" + motivo + "'," + fact_num + ")";
                    string update = "UPDATE EL_JAPONES_SANGRANDO.Facturas SET fact_estado = 1 WHERE fact_num = " + fact_num;
                    queries.Add(insert);
                    queries.Add(update);
                    if (BD.correrStoreProcedure(queries) > 0)
                    {
                        MessageBox.Show("Factura devuelta", "Al pique quique", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo devolver la factura", "Al pique quique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe Completar ambos campos", "Al pique quique", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            string query = "";

            if (cmbTipo.Text == "Seleccione..." || cmbTrimestre.Text == "Seleccione...")
            {
                MessageBox.Show("Complete todos los campos", "Al pique quique", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                switch (tipo)
                {
                    case 0://Porcentaje de facturas cobradas por empresa
                        {
                            query = "SELECT TOP 5 emp_nombre, (select rubro_desc from EL_JAPONES_SANGRANDO.Rubros where rubro_id = emp_rubro) as empresa_rubro, emp_cuit,isnull((((select count(*) from EL_JAPONES_SANGRANDO.Facturas where fact_empresa = emp_cuit and fact_estado = 2 and YEAR(fact_fechaalta) = " + anio + " and (MONTH(fact_fechaalta) = (" + trimestre + " * 3) OR MONTH(fact_fechaalta) = (" + trimestre + " * 3) -1 OR MONTH(fact_fechaalta) = (" + trimestre + " * 3) -2)) *  100 / NULLIF((select count(*) from EL_JAPONES_SANGRANDO.Facturas where fact_empresa = emp_cuit and YEAR(fact_fechaalta) = " + anio + " and (MONTH(fact_fechaalta) = (" + trimestre + " * 3) OR MONTH(fact_fechaalta) = (" + trimestre + " * 3) -1 OR MONTH(fact_fechaalta) = (" + trimestre + " * 3) -2)), 0))),0) as \"Porcentaje de facturas cobradas\" FROM EL_JAPONES_SANGRANDO.Empresas group by emp_nombre, emp_rubro, emp_CUIT ORDER BY 4 DESC";
                        };
                        break;
                    case 1://Empresas con mayor monto rendido
                        {
                            query = "";
                        };
                        break;
                    case 2://Clientes con mas pagos
                        {
                            query = "";
                        };
                        break;
                    case 3://Clientes cumplidores
                        {
                            query = "";
                        };
                        break;
                }

                dataGridEstadisticas.DataSource = BD.busqueda(query);
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
           
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            switch (comboAccion.SelectedValue.ToString())
            {
                case "ABM_ROL":
                    {
                        this.Hide();
                        new AbmRol.ABMRol().Show();
                    } break;
                case "LISTADO_ESTADISTICO":
                    {
                        Acciones.Controls.Add(tabPage4);

                    } break;
                case "RENDICION_DE_FACTURAS_COBRADAS":
                    {
                        Acciones.Controls.Add(tabPage3);
                    } break;
                case "DEVOLUCION":
                    {

                        Acciones.Controls.Add(tabPage5);
                    } break;
                case "ABM_FACTURA":
                    {
                        this.Hide();
                        new AbmFactura.ABMFactura().Show();
                    } break;
                case "ABM_SUCURSAL":
                    {
                        this.Hide();
                        new Sucursal.ABMSucursal().Show();
                    } break;
                case "ABM_EMPRESA":
                    {
                        this.Hide();
                        new AbmEmpresa.ABMEmpresa().Show();
                    } break;
                case "REGISTRO_DE_PAGO_DE_FACTURAS":
                    {
                        this.Hide();
                        new RegistroPago.Pagos().Show();
                    } break;
                case "ABM_CLIENTE":
                    {
                        this.Hide();
                        new AbmCliente.ABMCliente().Show();
                    } break;
                default:
                    {
                        MessageBox.Show("no se creo la ventana pertinente", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } break;
            }
        }
    }
}
