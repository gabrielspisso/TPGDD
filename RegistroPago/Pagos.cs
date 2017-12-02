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
    public partial class Pagos : Form, seleccionarCliente,seleccionarFactura
    {
        public Pagos()
        {
            InitializeComponent();
           
        }

        private void Pagos_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("factura_numero");
            dt.Columns.Add("factura_cliente");
            dt.Columns.Add("empresa_nombre");
            dt.Columns.Add("factura_fecha");
            dt.Columns.Add("factura_fecha_vencimiento");
            dt.Columns.Add("factura_total");

            lblImporte.Text = "0";

            dataGridFacturas.DataSource = dt;

            BD.nuevoBoton(dataGridFacturas, "Quitar", 7);

            List<string> lista = BD.listaDeUnCampo("select empresa_nombre from EL_JAPONES_SANGRANDO.Empresas where empresa_estado = 1");
            lista.Insert(0,"");
            comboMedioDePago.DataSource = BD.listaDeUnCampo("select formaDePago_desc from EL_JAPONES_SANGRANDO.Formas_De_Pago");
                comboSucursal.Hide();
                labelSucursal.Text = BD.getSucursal();
                comboSucursal.Text = BD.getSucursal();
            
            comboSucursal.DataSource = BD.listaDeUnCampo("select sucursal_nombre from EL_JAPONES_SANGRANDO.Sucursales");
        }


       public void setCliente(String Dni){
           textPagador.Text = Dni;
       }

       public void setFactura(String num)
       {
           foreach (DataGridViewRow row in dataGridFacturas.Rows)
            {
                string esto = Convert.ToString(row.Cells["factura_numero"].Value);
              if (esto == num)
              {
                  MessageBox.Show("Ya elegiste esa factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  return;
              }
            }
           DataTable dt = (DataTable)dataGridFacturas.DataSource;
           SqlCommand query = new SqlCommand("SELECT factura_numero, cliente_nombre, empresa_nombre, factura_fecha, factura_fecha_vencimiento, factura_total FROM EL_JAPONES_SANGRANDO.Facturas JOIN EL_JAPONES_SANGRANDO.Clientes on factura_cliente = cliente_DNI JOIN EL_JAPONES_SANGRANDO.Empresas ON factura_empresa = empresa_cuit WHERE factura_numero = " + num);
           DataTable aux = BD.busqueda(query);
           DataRow row2 = aux.Rows[0];
           dt.Rows.Add(row2.ItemArray);
           DataRow rowfinal = dt.Rows[dt.Rows.Count - 1];
           lblImporte.Text = (Decimal.Parse(lblImporte.Text) + Decimal.Parse(row2["factura_total"].ToString())).ToString();
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
            string estado = BD.chequearExistenciaYEstadoDelCliente(textPagador.Text);
            if (estado != "")
            {
                MessageBox.Show(" El pagador no "+estado+" en el sistema");
                return;
            }

            
            if (lblImporte.Text != "0")
            {
                insertarPago();
                textPagador.Text = "";
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

            String fecha = BD.fechaActual().ToString("u");
            fecha = fecha.Substring(0, fecha.Length - 1);

            string insert2 = "INSERT INTO EL_JAPONES_SANGRANDO.Pagos (pago_nro, pago_sucursal,pago_importe,pago_formaDePago,pago_fecha,pago_cliente) VALUES(" + idPago + "," + sucursal + "," + lblImporte.Text.Replace(",",".") + "," + medio + ",'" + fecha + "',"+textPagador.Text+")";
            List<String> lista = new List<string>();
            lista.Add(insert2);
            foreach (DataGridViewRow row in dataGridFacturas.Rows)
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
            
                
                        string w = BD.consultaDeUnSoloResultado("select factura_fecha_vencimiento from EL_JAPONES_SANGRANDO.Facturas where factura_numero = '"+factura+"' ");
                        DateTime fechaVencimiento = Convert.ToDateTime(w);
              
                        if (DateTime.Compare(BD.fechaActual(),fechaVencimiento) == 1)
                        {
                             MessageBox.Show("La factura Numero  "+ factura +" esta vencida");
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

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            new elegirCliente(this).Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new IniciarSesion.elegirFactura(this, false).ShowDialog();
        }

        private void dataGridFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                lblImporte.Text = (Double.Parse(lblImporte.Text)-Double.Parse(dataGridFacturas.Rows[e.RowIndex].Cells["factura_total"].Value.ToString())).ToString();
                dataGridFacturas.Rows.RemoveAt(e.RowIndex);
            }
        }

    }
}
