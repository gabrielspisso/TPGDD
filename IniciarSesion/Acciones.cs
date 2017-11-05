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
    public partial class Acciones : Form
    {
        public Acciones()
        {
            InitializeComponent();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            AbmEmpresa.ABMEmpresa abmEmpresa = new AbmEmpresa.ABMEmpresa();
            this.Hide();
            abmEmpresa.Show();
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            AbmFactura.ABMFactura abmFactura = new AbmFactura.ABMFactura();
            this.Hide();
            abmFactura.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbmCliente.ABMCliente abmCliente = new AbmCliente.ABMCliente();
            this.Hide();
            abmCliente.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AbmRol.ABMRol abmRol = new AbmRol.ABMRol();
            this.Hide();
            abmRol.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Sucursal.ABMSucursal abmSucursal = new Sucursal.ABMSucursal();
            this.Hide();
            abmSucursal.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string factura_numero = textFacturaDev.Text;
            string motivo = richTextMotivo.Text;

            if (factura_numero != "" && motivo != "")
            {
                DataTable dt = BD.busqueda("SELECT factura_estado FROM EL_JAPONES_SANGRANDO.Facturas WHERE factura_numero = " + factura_numero);
                int factura_estado = Int32.Parse(BD.devolverColumna(dt, "factura_estado"));
                if (factura_estado != 2)
                {
                    string razon = (factura_estado == 1) ? "no se ha pagado" : (factura_estado == 3) ? "ya se ha rendido" : "se ha eliminado";
                    MessageBox.Show("Esta factura no puede devolverse debido a que " + razon, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    List<string> queries = new List<string>();
                    string insert ="INSERT INTO EL_JAPONES_SANGRANDO.Devoluciones (devolucion_descripcion,devolucion_factura)values('" + motivo + "'," + factura_numero + ")";
                    string update = "UPDATE EL_JAPONES_SANGRANDO.Facturas SET factura_estado = 1 WHERE factura_numero = " + factura_numero;
                    queries.Add(insert);
                    queries.Add(update);
                    if ( BD.correrStoreProcedure(queries)> 0)
                    {
                        MessageBox.Show("Factura devuelta", "Factura devuelta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe Completar ambos campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            int tipo = cmbTipo.SelectedIndex;
            int trimestre = cmbTrimestre.SelectedIndex;
            string anio = añoNUD.Value.ToString();

            string query = "";

            switch (tipo)
            {
                case 0://Porcentaje de facturas cobradas por empresa
                    {
                        query = "SELECT TOP 5 empresa_nombre, empresa_rubro, empresa_cuit,isnull((((select count(*) from EL_JAPONES_SANGRANDO.Facturas where factura_empresa = empresa_cuit and factura_estado = 2 and YEAR(factura_fecha) = " + anio + " and (MONTH(factura_fecha) = (" + trimestre + " * 3) OR MONTH(factura_fecha) = (" + trimestre + " * 3) -1 OR MONTH(factura_fecha) = (" + trimestre + " * 3) -2)) *  100 / NULLIF((select count(*) from EL_JAPONES_SANGRANDO.Facturas where factura_empresa = empresa_cuit and YEAR(factura_fecha) = " + anio + " and (MONTH(factura_fecha) = (" + trimestre + " * 3) OR MONTH(factura_fecha) = (" + trimestre + " * 3) -1 OR MONTH(factura_fecha) = (" + trimestre + " * 3) -2)), 0))),0) as \"Porcentaje de facturas cobradas\" FROM EL_JAPONES_SANGRANDO.Empresas group by empresa_nombre, empresa_rubro, empresa_cuit ORDER BY 4 DESC";
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

        private void Acciones_Load(object sender, EventArgs e)
        {
           
        }

    }
}
