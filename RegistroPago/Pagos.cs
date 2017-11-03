using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PagoAgilFrba.RegistroPago
{
    public partial class Pagos : Form
    {
        public Pagos()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }


        private void Pagos_Load(object sender, EventArgs e)
        {
            List<string> lista = BD.listaDeUnCampo("select emp_nombre from EL_JAPONES_SANGRANDO.Empresas");
            lista.Insert(0,"");
            comboEmpresas.DataSource = lista;
            comboMedioDePago.DataSource = BD.listaDeUnCampo("select medio_desc from EL_JAPONES_SANGRANDO.MediosDePago");
            comboSucursal.DataSource = BD.listaDeUnCampo("select suc_nombre from EL_JAPONES_SANGRANDO.Sucursales");
        }
        /// <summary>
        /// 
        /// 
        /// 
        /// HAY QUE AGREGAR EL FILTRO DE LAS FACTURAS SOLO PAGADAS
        /// 
        /// 
        /// 
        /// </summary>
        string queryf = "Select * from EL_JAPONES_SANGRANDO.Facturas ";
        string queryBusqueda;

        private bool los4estanvacios()
        {
            return txtDni.Text == "" && dateVenc.Text == "1/1/2017" && txtFactura.Text == "" && comboEmpresas.Text == "";
        }

        string conAnd(string cadena)
        {
            return " AND " + cadena + " ";
        }

        private string queryFactura()
        {
            return txtFactura.Text == "" ? "" : ("fact_num =" + txtFactura.Text);
        }
        private string queryVencimiento()
        {
            return dateVenc.Text == "" ? "" : ("YEAR(fact_fechavenc) = "+ dateVenc.Value.Year +"and MONTH(fact_fechavenc) = "+dateVenc.Value.Month+" and DAY(fact_fechavenc) = " + dateVenc.Value.Day +" ");
        }
        private string queryDni()
        {
            return txtDni.Text == "" ? "" : ("fact_cliente =" + txtDni.Text);
        }

        private string queryEmpresa()
        {
            if (comboEmpresas.Text != "")
            {
                string empresaCuit = BD.consultaDeUnSoloResultado("select emp_CUIT from EL_JAPONES_SANGRANDO.Empresas where emp_nombre='" + comboEmpresas.Text + "'");
                return "fact_empresa = '" + empresaCuit + "'";
            }
            return "";
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            string query2 = "";
            if (txtDni.Text != "")
            {
                query2 = queryf + " WHERE " + this.queryDni();
            }
            else
                query2 = queryf + " WHERE 1 = 1";
               if (dateVenc.Text != "1/1/2017")
               {
                   query2 += conAnd(queryVencimiento());
               }
               if (txtFactura.Text != "")
               {
                   query2 += conAnd(queryFactura());
               }
               if (comboEmpresas.Text != "")
               {
                   query2 += conAnd(queryEmpresa());
               }

               dataGridFacturas.DataSource = BD.busqueda(query2);
            


        }


        private void txtFactura_TextChanged(object sender, EventArgs e)
        {
            string query2 = "";
            if (txtFactura.Text != "")
            {
                query2 = queryf + " WHERE " + this.queryFactura();
            }
            else{
                query2 +=queryf +"WHERE 1 = 1";
            }
                if (dateVenc.Text != "1/1/2017")
                {
                    query2 += conAnd(queryVencimiento());
                }
                if (txtDni.Text != "")
                {
                    query2 += conAnd(queryDni());
                }
                if (comboEmpresas.Text != "")
                {
                    query2 += conAnd(queryEmpresa());
                }

                dataGridFacturas.DataSource = BD.busqueda(query2);
            



        }


        private void comboEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query2 = "";
            if (comboEmpresas.Text != "")
            {
                query2 = queryf + " WHERE " + this.queryEmpresa();
            }
            else{ 
                    query2 = queryf + " WHERE 1 = 1"; 
                }
                if (dateVenc.Text != "1/1/2017")
                {
                    query2 += conAnd(queryVencimiento());
                }
                if (txtFactura.Text != "")
                {
                    query2 += conAnd(queryFactura());
                }
                if (txtDni.Text != "")
                {
                    query2 += conAnd(queryDni());
                }

                dataGridFacturas.DataSource = BD.busqueda(query2);

            
        }

        private void dateVenc_ValueChanged(object sender, EventArgs e)
        {
            string query2 = "";
            if (dateVenc.Text != "1/1/2017")
            {
                query2 = queryf + " WHERE " + this.queryVencimiento();
                if (txtDni.Text != "")
                {
                    query2 += conAnd(queryDni());
                }
                if (txtFactura.Text != "")
                {
                    query2 += conAnd(queryFactura());
                }
                if (comboEmpresas.Text != "")
                {
                    query2 += conAnd(queryEmpresa());
                }

                dataGridFacturas.DataSource = BD.busqueda(query2);

            }
        }

        private void dataGridFacturas_SelectionChanged(object sender, EventArgs e)
        {
            double valor = 0;
            foreach (DataGridViewRow row in dataGridFacturas.SelectedRows)
            {
                valor += double.Parse(row.Cells["fact_total"].Value.ToString());
            }
            lblImporte.Text = valor.ToString();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (lblImporte.Text != "0")
            {
                insertarPago();

                MessageBox.Show("Se cargo correctamente");
                txtDni.Text = "";
            }
            else
            {

                MessageBox.Show("Hay campos sin rellenar");
            }
        }
        private void insertarPago()
        {
            string idPago = BD.consultaDeUnSoloResultado("select top 1 pago_nro+1 from EL_JAPONES_SANGRANDO.Pagos ORDER BY pago_nro desc");
            string sucursal = BD.consultaDeUnSoloResultado("SELECT suc_CP from EL_JAPONES_SANGRANDO.Sucursales where suc_nombre='" + comboSucursal.Text +"'");
            string medio = BD.consultaDeUnSoloResultado("SELECT medio_id from EL_JAPONES_SANGRANDO.MediosDePago where medio_desc='" + comboMedioDePago.Text + "'");
            string fecha = dateVenc.Value.Date.ToString("MM/dd/yyyy");
            SqlConnection con = BD.getConnection();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO EL_JAPONES_SANGRANDO.Pagos (pago_nro, pago_suc,pago_importe,pago_medio,pago_fecha) VALUES(@idpago,@sucursal,@importe,@medio,@fecha)", con))
            {
                cmd.Parameters.AddWithValue("@idpago", idPago);
                cmd.Parameters.AddWithValue("@sucursal", sucursal);
                cmd.Parameters.AddWithValue("@importe", lblImporte.Text);
                cmd.Parameters.AddWithValue("@medio", medio);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                con.Open();

                ///LA LINEA MAS LINDA
                cmd.ExecuteScalar();

                con.Close();
            }
            MessageBox.Show(idPago.ToString());
            foreach (DataGridViewRow row in dataGridFacturas.SelectedRows)
            {
                string factura = row.Cells["fact_num"].Value.ToString();
                BD.ABM("INSERT INTO EL_JAPONES_SANGRANDO.PagoFactura(pagfact_factura,pagfact_pago) values (" + factura + "," + idPago+")");



            }

        }
    }
}
