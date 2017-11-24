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
using System.Text.RegularExpressions;

namespace PagoAgilFrba.RegistroPago
{
    public partial class Pagos : Form
    {
        bool primeraVez;
        public Pagos()
        {
            InitializeComponent();
        }

        string queryf = "Select factura_numero, empresa_nombre as Empresa, factura_cliente,factura_fecha,factura_fecha_vencimiento,factura_total from EL_JAPONES_SANGRANDO.Facturas join EL_JAPONES_SANGRANDO.Empresas on (factura_empresa = empresa_cuit) where factura_estado  = 1 AND empresa_estado = 1";

        private void Pagos_Load(object sender, EventArgs e)
        {
            primeraVez = true;
            List<string> lista = BD.listaDeUnCampo("select empresa_nombre from EL_JAPONES_SANGRANDO.Empresas where empresa_estado = 1");
            lista.Insert(0,"");
            comboEmpresas.DataSource = lista;
            comboMedioDePago.DataSource = BD.listaDeUnCampo("select formaDePago_desc from EL_JAPONES_SANGRANDO.Formas_De_Pago");
            if (BD.getSucursal() != "")
            {
                comboSucursal.Hide();
                labelSucursal.Text = BD.getSucursal();
                comboSucursal.Text = BD.getSucursal();
                return;
            }
            dataGridFacturas.DataSource = BD.busqueda(queryf);
            dateVenc.Value = BD.fechaActual();
            comboSucursal.DataSource = BD.listaDeUnCampo("select sucursal_nombre from EL_JAPONES_SANGRANDO.Sucursales");
        }


       

        private bool los4estanvacios()
        {
            return txtDni.Text == "" && primeraVez && txtFactura.Text == "" && comboEmpresas.Text == "";
        }

        string conAnd(string cadena)
        {
            return " AND " + cadena + " ";
        }

        private string queryFactura()
        {
            return txtFactura.Text == "" ? "" : ("factura_numero like '" + txtFactura.Text+"%'");
        }
        private string queryVencimiento()
        {
            return dateVenc.Text == "" ? "" : ("YEAR(factura_fecha_vencimiento) = "+ dateVenc.Value.Year +"and MONTH(factura_fecha_vencimiento) = "+dateVenc.Value.Month+" and DAY(factura_fecha_vencimiento) = " + dateVenc.Value.Day +" ");
        }
        private string queryDni()
        {
            return txtDni.Text == "" ? "" : ("factura_cliente like '" + txtDni.Text+"%'");
        }

        private string queryEmpresa()
        {
            if (comboEmpresas.Text != "")
            {
                string empresaCuit = BD.consultaDeUnSoloResultado("select empresa_cuit from EL_JAPONES_SANGRANDO.Empresas where empresa_nombre='" + comboEmpresas.Text + "'");
                return "factura_empresa = '" + empresaCuit + "'";
            }
            return "";
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            string query2 = "";
            if (txtDni.Text != "")
            {
                query2 = queryf + " AND " + this.queryDni();
            }
            else
                query2 = queryf + " AND 1 = 1";
               if (!primeraVez)
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
                query2 = queryf + " AND " + this.queryFactura();
            }
            else{
                query2 +=queryf +"AND 1 = 1";
            }
                if (!primeraVez)
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
                query2 = queryf + " AND " + this.queryEmpresa();
            }
            else{ 
                    query2 = queryf + " AND 1 = 1"; 
                }
                if (!primeraVez)
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
            if (!primeraVez)
            {
                query2 = queryf + " AND " + this.queryVencimiento();
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
            else primeraVez = false;
        }

        private void dataGridFacturas_SelectionChanged(object sender, EventArgs e)
        {
            double valor = 0;
            foreach (DataGridViewRow row in dataGridFacturas.SelectedRows)
            {
                valor += double.Parse(row.Cells["factura_total"].Value.ToString());
            }
            lblImporte.Text = valor.ToString();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            Regex reg = new Regex("^[0-9]+$"); 
          
            if(textPagador.Text == "")
            {
                MessageBox.Show("Falta completar el DNI");
                return;
            }
         
            if (!reg.IsMatch(textPagador.Text))
            {
                MessageBox.Show(" El dni del pagador contiene caracteres invalidos");
                return;
            }

            
            if (lblImporte.Text != "0")
            {
                insertarPago();
                txtDni.Text = "";
            }
            else
            {

                MessageBox.Show("Hay campos sin rellenar");
            }
        }
        private void insertarPago()
        {

            if(textPagador.Text == ""){
                MessageBox.Show("No selecciono pagador");
                return;
            }
           
            string idPago = BD.consultaDeUnSoloResultado("select top 1 pago_nro+1 from EL_JAPONES_SANGRANDO.Pagos ORDER BY pago_nro desc");
            string sucursal = BD.consultaDeUnSoloResultado("SELECT sucursal_codigo_postal from EL_JAPONES_SANGRANDO.Sucursales where sucursal_nombre='" + comboSucursal.Text +"'");
            string medio = BD.consultaDeUnSoloResultado("SELECT formaDePago_id from EL_JAPONES_SANGRANDO.Formas_De_Pago where formaDePago_desc='" + comboMedioDePago.Text + "'");
            String fecha = dateVenc.Value.ToString("u");
            fecha = fecha.Substring(0, fecha.Length - 1);
            
           
            string insert2 = "INSERT INTO EL_JAPONES_SANGRANDO.Pagos (pago_nro, pago_sucursal,pago_importe,pago_formaDePago,pago_fecha,pago_cliente) VALUES(" + idPago + "," + sucursal + "," + lblImporte.Text.Replace(",",".") + "," + medio + ",'" + fecha + "',38270412)";
            List<String> lista = new List<string>();
            lista.Add(insert2);
            foreach (DataGridViewRow row in dataGridFacturas.SelectedRows)
            {
                string factura = row.Cells["factura_numero"].Value.ToString();                
                String insert = "INSERT INTO EL_JAPONES_SANGRANDO.Pago_Factura(pago_Factura_factura,pago_Factura_pago) values ('" + factura + "'," + idPago + ")";
                String update = "UPDATE EL_JAPONES_SANGRANDO.Facturas SET factura_estado = 2 where factura_numero = '" + factura+"'";
                string x =BD.consultaDeUnSoloResultado("select count(*) from EL_JAPONES_SANGRANDO.Facturas where factura_numero = '"+factura+"' AND factura_estado = 1");
                if (Int32.Parse(x) == 0)
                {
                     MessageBox.Show("La factura Numero  "+ factura +"no esta disponible para pagar");
                     return;
                }
                lista.Add(insert);
                lista.Add(update);
            }
            if(BD.correrStoreProcedure(lista)>0){
                MessageBox.Show("Se concreto el pago");
                Pagos_Load(null,null);
            }
            else{
                MessageBox.Show("Datos erroneos");
            }
        }

    }
}
