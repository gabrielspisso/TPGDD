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
            string query = "select (select funcionalidad_descripcion from EL_JAPONES_SANGRANDO.Funcionalidades where funcionalidad_id = rol_Funcionalidad_funcionalidad ) from EL_JAPONES_SANGRANDO.Rol_Funcionalidad where rol_Funcionalidad_rol = '" + rolSeleccionado + "'";
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
            string factura_numero = textFacturaDev.Text;
            string motivo = richTextDev.Text;

            if (factura_numero != "" && motivo != "")
            {
                DataTable dt = BD.busqueda("SELECT factura_estado FROM EL_JAPONES_SANGRANDO.Facturas WHERE factura_numero = " + factura_numero);
                int factura_estado = Int32.Parse(BD.devolverColumna(dt, "factura_estado"));
                if (factura_estado != 2)
                {
                    string razon = (factura_estado == 1) ? "no se ha pagado" : (factura_estado == 3) ? "ya se ha rendido" : "se ha eliminado";
                    MessageBox.Show("Esta factura no puede devolverse debido a que " + razon, "Al pique quique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    List<string> queries = new List<string>();
                    string insert = "INSERT INTO EL_JAPONES_SANGRANDO.Devoluciones (devolucion_descripcion,devolucion_factura)values('" + motivo + "'," + factura_numero + ")";
                    string update = "UPDATE EL_JAPONES_SANGRANDO.Facturas SET factura_estado = 1 WHERE factura_numero = " + factura_numero;
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
                            query = "SELECT TOP 5 empresa_nombre, (select rubro_desc from EL_JAPONES_SANGRANDO.Rubros where rubro_id = empresa_rubro) as empresa_rubro, empresa_cuit,isnull((((select count(*) from EL_JAPONES_SANGRANDO.Facturas where factura_empresa = empresa_cuit and factura_estado = 2 and YEAR(factura_fecha) = " + anio + " and (MONTH(factura_fecha) = (" + trimestre + " * 3) OR MONTH(factura_fecha) = (" + trimestre + " * 3) -1 OR MONTH(factura_fecha) = (" + trimestre + " * 3) -2)) *  100 / NULLIF((select count(*) from EL_JAPONES_SANGRANDO.Facturas where factura_empresa = empresa_cuit and YEAR(factura_fecha) = " + anio + " and (MONTH(factura_fecha) = (" + trimestre + " * 3) OR MONTH(factura_fecha) = (" + trimestre + " * 3) -1 OR MONTH(factura_fecha) = (" + trimestre + " * 3) -2)), 0))),0) as \"Porcentaje de facturas cobradas\" FROM EL_JAPONES_SANGRANDO.Empresas group by empresa_nombre, empresa_rubro, empresa_cuit ORDER BY 4 DESC";
                        };
                        break;
                    case 1://Empresas con mayor monto rendido
                        {
                            query = "SELECT TOP 5 empresa_nombre, (select rubro_desc from EL_JAPONES_SANGRANDO.Rubros where rubro_id = empresa_rubro) as empresa_rubro, empresa_cuit, SUM(rendicion_importe) as Monto_total_rendido FROM EL_JAPONES_SANGRANDO.Empresas join EL_JAPONES_SANGRANDO.Rendiciones ON rendicion_empresa = empresa_cuit where YEAR(rendicion_fecha) = " + anio + " and (MONTH(rendicion_fecha) = (" + trimestre + " * 3) OR MONTH(rendicion_fecha) = (" + trimestre + " * 3) -1 	OR MONTH(rendicion_fecha) = (" + trimestre + " * 3) -2) GROUP BY empresa_cuit, empresa_nombre, empresa_rubro ORDER BY 4 DESC";
                        };
                        break;
                    case 2://Clientes con mas pagos
                        {
                            query = "SELECT TOP 5 cliente_nombre, cliente_apellido, cliente_DNI, cliente_mail, (SELECT COUNT(*) FROM EL_JAPONES_SANGRANDO.Pagos  WHERE pago_cliente = cliente_DNI 	and YEAR(pago_fecha) = " + anio + "and (MONTH(pago_fecha) = (" + trimestre + " * 3) OR MONTH(pago_fecha) = (" + trimestre + " * 3) -1 	OR MONTH(pago_fecha) = (" + trimestre + " * 3) -2)) as Cantidad_de_Pagos FROM EL_JAPONES_SANGRANDO.Clientes GROUP BY cliente_nombre, cliente_apellido, cliente_DNI, cliente_mail ORDER BY 5 DESC;";
                        };
                        break;
                    case 3://Clientes cumplidores
                        {
                            query = "SELECT TOP 5 empresa_nombre, (select rubro_desc from EL_JAPONES_SANGRANDO.Rubros where rubro_id = empresa_rubro), empresa_cuit, SUM(rendicion_importeFinal) as Monto_total_rendido FROM EL_JAPONES_SANGRANDO.Empresas join EL_JAPONES_SANGRANDO.Rendiciones ON rendicion_empresa = empresa_cuit where YEAR(rendicion_fecha) = " + anio + "	and (MONTH(rendicion_fecha) = (" + trimestre + " * 3) 	OR MONTH(rendicion_fecha) = (" + trimestre + " * 3) -1 OR MONTH(rendicion_fecha) = (" + trimestre + " * 3) -2) GROUP BY empresa_nombre, empresa_rubro, empresa_cuit ORDER BY 4 DESC";
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
