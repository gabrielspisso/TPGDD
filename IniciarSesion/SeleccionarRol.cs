﻿using System;
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
    public partial class SeleccionarRol : Form
    {
        public SeleccionarRol(string username)
        {
            InitializeComponent();
            comboRoles.DataSource = BD.roles(username);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            switch (comboRoles.SelectedValue.ToString())
            {
                case "administrador":
                    {
                        this.Hide();
                        new AccionesAdmin(comboRoles.SelectedValue.ToString()).Show();
                    } break;
                case "cobrador":
                    {
                        this.Hide();
                        new SeleccionarSucursal().ShowDialog(); ;
                    } break;
                default:
                    {
                        MessageBox.Show("no se creo la ventana pertinente", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }break;
            }
        }

        private void comboRoles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
