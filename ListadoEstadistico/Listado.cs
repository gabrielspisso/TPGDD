using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.ListadoEstadistico
{
    public partial class Listado : Form
    {
        public Listado()
        {
            InitializeComponent();

            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTrimestre.DropDownStyle = ComboBoxStyle.DropDownList;
            dataGridEstadisticas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            añoNUD.Value = BD.fechaActual().Year;
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
    }
}
